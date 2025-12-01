using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using System.Security.Cryptography;
using System.Text;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IPaymentService _paymentService;

        public PaymentController(IConfiguration config, IPaymentService paymentService)
        {
            _config = config;
            _paymentService = paymentService;
        }


        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                if (request == null || request.Amount <= 0)
                    return BadRequest(new { message = "Invalid payment request" });

                string razorKey = _config["RazorPay:Key"];
                if (string.IsNullOrEmpty(razorKey))
                    return BadRequest(new { message = "Razorpay Key not configured" });

                PaymentDetailModel payment = new PaymentDetailModel
                {
                    Currency = "INR",
                    GrandTotal = request.Amount * 100,
                    RazorpayKey = razorKey,
                    Receipt = Guid.NewGuid().ToString()
                };

                payment.OrderId = _paymentService.CreateOrder(payment.Receipt, request.Amount);

                if (string.IsNullOrEmpty(payment.OrderId))
                    return BadRequest(new { message = "Failed to create Razorpay order" });

                return Ok(new
                {
                    orderId = payment.OrderId,
                    currency = payment.Currency,
                    grandTotal = payment.GrandTotal,
                    razorpayKey = payment.RazorpayKey,
                    receipt = payment.Receipt
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // POST: api/Payment/verify

        [HttpPost("verify")]
        public IActionResult VerifyPayment([FromBody] OrderModel model)
        {
            try
            {
                Console.WriteLine("----- RAZORPAY VERIFICATION START -----");
                Console.WriteLine("OrderId: " + model.rzp_OrderId);
                Console.WriteLine("PaymentId: " + model.rzp_PaymentId);
                Console.WriteLine("Signature (Client): " + model.rzp_Signature);

                string secret = _config["RazorPay:Secret"];


                string payload = $"{model.rzp_OrderId}|{model.rzp_PaymentId}";

                using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
                string generatedSignature = BitConverter
                    .ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(payload)))
                    .Replace("-", "")
                    .ToLower();

                Console.WriteLine("Signature (Server Generated): " + generatedSignature);

                // CASE INSENSITIVE COMPARISON
                if (!string.Equals(generatedSignature, model.rzp_Signature, StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest(new { message = "Invalid signature" });
                }

                // Fetch payment details from Razorpay
                var paymentDetails = _paymentService.GetPaymentDetail(model.rzp_PaymentId);

                var payModel = new PaymentDetails
                {
                    UserId = model.UserId,
                    OrderId = model.rzp_OrderId,
                    PaymentId = model.rzp_PaymentId,
                    Signature = model.rzp_Signature,
                    Amount = paymentDetails["amount"],
                    Status = paymentDetails["status"],
                    CreatedAt = DateTime.Now
                };

                _paymentService.InsertPaymentDetail(payModel);

                return Ok(new { message = "Payment verified successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}










   
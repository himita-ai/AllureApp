using AllureApp.Core.Entities;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using AllureApp.Models;
using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using System.Security.Cryptography;
using System.Text;


public class PaymentService : IPaymentService
{
    private readonly IPaymentRepo _paymentRepo;
    private readonly IConfiguration _configuration;
    private readonly RazorpayClient _client;

    public PaymentService(IPaymentRepo paymentRepo, IConfiguration configuration)
    {
        _paymentRepo = paymentRepo;
        _configuration = configuration;

        Console.WriteLine("🔑 RazorPay:Key = " + configuration["RazorPay:Key"]);
        Console.WriteLine("🔑 RazorPay:Secret = " + configuration["RazorPay:Secret"]);

        _client = new RazorpayClient(configuration["RazorPay:Key"], configuration["RazorPay:Secret"]);
    }


    public string CreateOrder(string receipt, decimal amount)
    {
        var amt = Convert.ToInt64(Math.Ceiling(amount * 100)); // amount in paise
        var options = new Dictionary<string, object>
        {
            ["receipt"] = receipt,
            ["amount"] = amt,
            ["currency"] = "INR"
        };
        var order = _client.Order.Create(options);
        return order["id"].ToString();
    }

    public Payment GetPaymentDetail(string paymentId)
    {
        return _client.Payment.Fetch(paymentId);
    }

    public bool IsSignatureVerified(string paymentId, string orderId, string signature)
    {
        string payload = $"{orderId}|{paymentId}";

        string secretKey = _configuration["RazorPay:Secret"]; // ✔ FIXED SECRET

        var actualSign = GetActualSignature(payload, secretKey);

        return actualSign.Equals(signature, StringComparison.OrdinalIgnoreCase);
    }


    private static string GetActualSignature(string payload, string secretKey)
    {
        var secretBytes = Encoding.UTF8.GetBytes(secretKey);
        using var hmac = new HMACSHA256(secretBytes);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    public int InsertPaymentDetail(PaymentDetails model)
    {
        return _paymentRepo.InsertPaymentDetail(model);
    }
}
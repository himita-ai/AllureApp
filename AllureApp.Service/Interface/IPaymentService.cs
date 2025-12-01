using AllureApp.Core.Entities;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Interface
{
    public interface IPaymentService
    {
        string CreateOrder(string receipt, decimal amount);
        Payment GetPaymentDetail(string paymentId);
        bool IsSignatureVerified(string paymentId, string orderId, string signature);
        int InsertPaymentDetail(PaymentDetails model);







    }
}

using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Implementation
{
    public class PaymentRepo : Repository<PaymentDetails>, IPaymentRepo
    {
        private readonly AllureAppContext _context;

        public PaymentRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }
      
      

        public int InsertPaymentDetail(PaymentDetails model)
        {
            _context.PaymentDetails.Add(model);
            return _context.SaveChanges();
        }
    }
}

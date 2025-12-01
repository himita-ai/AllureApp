using AllureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
    public interface IPaymentRepo
    {
        int InsertPaymentDetail(PaymentDetails model);
    }
}

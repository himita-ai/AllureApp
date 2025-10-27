using AllureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Interface
{
   public interface IProductService
    {

        List<ProductModel> GetAllProduct();
    }
}

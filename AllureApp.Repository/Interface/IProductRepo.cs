using AllureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
    public interface IProductRepo
    {
        List<ProductModel> GetAllProduct();
    }
}

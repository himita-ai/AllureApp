using AllureApp.Models;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
           _productRepo = productRepo;
        }

        public List<CategoryModel> GetAllCategories()
        {
            return _productRepo.GetAllCategories();
        }

        public List<ProductModel> GetAllProduct()
        {
            return _productRepo.GetAllProduct();
        }

        public List<ProductModel> GetFrontPageProducts()
        {
            return _productRepo.GetFrontPageProducts();
        }

        public int InsertOrUpdateProduct(ProductModel model)
        {
            return _productRepo.InsertOrUpdateProduct(model);
        }
    }
}

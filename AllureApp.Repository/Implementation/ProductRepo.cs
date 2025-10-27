using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Implementation
{
    public class ProductRepo :Repository<Product>, IProductRepo
    {
        private readonly AllureAppContext _context;

        public ProductRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductModel> GetAllProduct()
        {
            try
            {
                var product = _context.Products.Where(x => x.IsDeleted == false).Select(pd => new ProductModel
                {
                    Id = pd.Id,
                    ProductName = pd.ProductName,
                    ProductDescription = pd.ProductDescription,
                    UnitPrice = pd.UnitPrice,
                    Quantity = pd.Quantity,
                    Currency = pd.Currency,
                    ImageUrl = pd.ImageUrl,
                    ImageFile = GetImages(pd.ImageUrl),
                }).ToList();
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static byte[] GetImages(string imagePath)
        {
            try
            {
                if(!System.IO.File.Exists(imagePath)) return null;
                var imageByte= System.IO.File.ReadAllBytes(imagePath);
                return imageByte;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

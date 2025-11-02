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
    public class ProductRepo : Repository<Product>, IProductRepo
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
                    SubCatId=pd.SubCatId,
                    CatId=pd.SubCategory.CatId
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
                if (!System.IO.File.Exists(imagePath)) return null;
                var imageByte = System.IO.File.ReadAllBytes(imagePath);
                return imageByte;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertOrUpdateProduct(ProductModel model)
        {
            int result = 0;
            try
            {
                var productExist = _context.Products.FirstOrDefault(x => x.Id == model.Id);
                if (productExist == null)
                {
                    var addProduct = new Product
                    {
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        UnitPrice = model.UnitPrice,
                        Quantity = model.Quantity,
                        Currency = model.Currency,
                        SubCatId = model.SubCatId,
                        IsDeleted = false,
                    };
                    _context.Products.Add(addProduct);
                    _context.SaveChanges();
                    result = 1;
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
                var categories = _context.Categories.Where(x => x.Deleted == false).Select(ct => new CategoryModel
                {
                    Id = ct.Id,
                    Name = ct.Cat_Name,

                    SubCategories = ct.SubCategories.Where(sc => sc.Deleted == false).Select(sc => new SubCategoryModel
                    {
                        Id = sc.Id,
                        Name = sc.SubCat_Name,

                    }).ToList()
                }).ToList();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductModel> GetFrontPageProducts()
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
    }
}

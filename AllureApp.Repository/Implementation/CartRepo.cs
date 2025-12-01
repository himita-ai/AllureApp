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
    public class CartRepo : Repository<CartItem>, ICartRepo
    {
        private readonly AllureAppContext _context;

        public CartRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }

      
        public IEnumerable<CartItemModel> GetCart(int UserId)
        {
            var cartItems = (from item in _context.CartItems
                             join product in _context.Products
                             on item.ProductId equals product.Id
                             where item.UserId == UserId
                             select new CartItemModel
                             {
                                 Id = item.Id,
                                 UserId = item.UserId,
                                 ProductId = item.ProductId,
                                 Quantity = item.Quantity,
                                 UnitPrice = item.UnitPrice,
                                 ProductName = product.ProductName,
                                 ProductDescription = product.ProductDescription,
                                
                                 ImageFile=GetImages(product.ImageUrl)
                                 
                             }).ToList();

            return cartItems;
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

        public bool AddToCart(CartItemModel model)
        {
            try
            {
                var existingItem = _context.CartItems
                    .FirstOrDefault(x => x.ProductId == model.ProductId && x.UserId == model.UserId);

                if (existingItem != null)
                {
                  
                    existingItem.Quantity += model.Quantity;
                }
                else
                {
                   
                    var newItem = new CartItem
                    {
                        ProductId = model.ProductId,
                        UserId = model.UserId,
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        Quantity = model.Quantity,
                        UnitPrice = model.UnitPrice,
                       
                    };

                    _context.CartItems.Add(newItem);
                }

                
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddToCart Error: {ex.Message} | {ex.InnerException?.Message}");
                return false;
            }
        }



        public bool UpdateCartItemQuantity(int Id, int change)
        {
            var item = _context.CartItems.FirstOrDefault(x => x.Id == Id);
            if (item == null) return false;

            item.Quantity += change;
            if (item.Quantity <= 0)
                _context.CartItems.Remove(item);

            _context.SaveChanges();
            return true;
        }

        public bool DeleteItem(int Id)
        {
            try
            {
                var item = _context.CartItems.FirstOrDefault(x => x.Id == Id);
                if (item == null) return false;
                _context.CartItems.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

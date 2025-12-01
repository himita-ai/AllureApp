using AllureApp.Models;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        public CartService(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public bool AddToCart(CartItemModel cartItemModel)
        {
             return _cartRepo.AddToCart(cartItemModel);
        }

        public bool DeleteItem(int Id)
        {
          return _cartRepo.DeleteItem(Id);
        }

        public IEnumerable<CartItemModel> GetCart(int UserId)
        {
          return _cartRepo.GetCart(UserId);
        }

        public bool UpdateCartItemQuantity(int Id, int change)
        {
           return _cartRepo.UpdateCartItemQuantity(Id,change);
        }
    }
}

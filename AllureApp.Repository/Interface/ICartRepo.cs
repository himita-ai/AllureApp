using AllureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
   public interface ICartRepo
    {
        IEnumerable<CartItemModel> GetCart( int UserId);
        bool AddToCart(CartItemModel cartItemModel);
        bool UpdateCartItemQuantity(int Id, int change);
        bool DeleteItem(int Id);
    }
}

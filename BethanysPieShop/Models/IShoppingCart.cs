using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie, int amount);
        void RemoveFromCart(Pie pie);
        void ClearCart();
        decimal GetShoppingCartTotal();
        IEnumerable<ShoppingCartItem> GetShoppingCartItems();
        IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

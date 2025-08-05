﻿using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }
    }
}

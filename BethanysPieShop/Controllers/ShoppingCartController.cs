using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;
        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var sellectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (sellectedPie != null)
            {
                _shoppingCart.AddToCart(sellectedPie, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var sellectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (sellectedPie != null)
            {
                _shoppingCart.RemoveFromCart(sellectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}

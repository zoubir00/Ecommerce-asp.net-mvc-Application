using EticketsWebApp.Data.Cart;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EticketsWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var Items = _shoppingCart.GetShoppingCartItem();
            _shoppingCart.ShoppingCarteItems = Items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                shoppingcartTotal = _shoppingCart.GetShoppingCartTotal()
            }; 
            return View(response);
        }
    }
}

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
        public IActionResult ShoppingCart()
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

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _movieService.GetMovieBYIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieService.GetMovieBYIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}

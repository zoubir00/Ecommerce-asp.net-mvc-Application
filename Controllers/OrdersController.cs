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
        private readonly IOrderService _orderService;

        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
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

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItem();
            string userId = "";
            string userEmailAddress = "";

            await _orderService.storeOrder(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");


        }
    }
}

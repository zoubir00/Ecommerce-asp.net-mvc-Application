using EticketsWebApp.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace EticketsWebApp.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItem();
            return View(items.Count);
        }
    }
}

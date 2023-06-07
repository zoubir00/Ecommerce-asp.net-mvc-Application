using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Data.Cart
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCarteItem> ShoppingCarteItems { get; set; }

        public List<ShoppingCarteItem> GetShoppingCartItem()
        {
            return ShoppingCarteItems ?? (ShoppingCarteItems = _context.ShoppingCarteItems
                .Where(n => n.ShoppingCarteId == ShoppingCartId)
                .Include(m => m.Movie).ToList());
        }
        public double GetShoppingCartTotal() => _context.ShoppingCarteItems.Where(n => n.ShoppingCarteId == ShoppingCartId)
                                                                .Select(n => n.Movie.Price * n.Amount).Sum();
        
    }
}

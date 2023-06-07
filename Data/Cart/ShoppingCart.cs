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

        // Add Item to the car

        public void AddItemToCart(Movie movie)
        {
            var ShoppingCartItem = _context.ShoppingCarteItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCarteId == ShoppingCartId);
            if (ShoppingCartItem == null)
            {
                ShoppingCartItem =new ShoppingCarteItem()
                {
                    ShoppingCarteId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCarteItems.Add(ShoppingCartItem);
            }
            else
            {
                ShoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

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

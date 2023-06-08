using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrderByUserIdAsync(string userId);
        Task storeOrder(List<ShoppingCarteItem> items, string userId, string userEmailAddress);
    }
}

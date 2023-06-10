using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId,string role);
        Task storeOrder(List<ShoppingCarteItem> items, string userId, string userEmailAddress);
    }
}

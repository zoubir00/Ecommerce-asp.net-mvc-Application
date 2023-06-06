namespace EticketsWebApp.Models
{
    public class ShoppingCarteItem
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCarteId { get; set; }
    }
}

using EticketsWebApp.Data;

namespace EticketsWebApp.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public string CinemaName { get; set; }
        public string MovieActors { get; set; }
        public MovieCategory MovieCategory { get; set; }
    }
}

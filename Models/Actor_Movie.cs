namespace EticketsWebApp.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int Actorid { get; set; }
        public Actor Actor { get; set; } 
    }
}

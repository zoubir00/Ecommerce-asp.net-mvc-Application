using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        public string profilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}

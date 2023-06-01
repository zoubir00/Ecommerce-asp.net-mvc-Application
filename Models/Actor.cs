using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Display(Name ="Profile picture")]
        public string profilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "BIO")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}

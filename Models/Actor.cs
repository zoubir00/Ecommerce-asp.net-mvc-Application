using EticketsWebApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string profilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is required")]

        public string FullName { get; set; }

        [Display(Name = "BIO")]
        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}

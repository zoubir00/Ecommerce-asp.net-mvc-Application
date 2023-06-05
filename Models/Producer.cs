using EticketsWebApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get ; set ; }

        [Display(Name = "Profile picture")]
        [Required(ErrorMessage ="The image is required")]
        public string profilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="the digits are not enough")]
        public string FullName { get; set; }

        [Display(Name = "BIO")]
        [Required(ErrorMessage = "The biography is required")]
        public string Bio { get; set; }

        //rlationShips
        public List<Movie>? Movies { get; set; }
       
    }
}

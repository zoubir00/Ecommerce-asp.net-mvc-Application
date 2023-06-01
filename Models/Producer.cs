using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Display(Name = "Profile picture")]
        public string profilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "BIO")]
        public string Bio { get; set; }

        //rlationShips
        public List<Movie> Movies { get; set; }
    }
}

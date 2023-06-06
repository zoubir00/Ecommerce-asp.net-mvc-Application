using EticketsWebApp.Data.Enums;
using EticketsWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EticketsWebApp.Data.ViewModels
{
    public class NewMovieVM

    {
        public int Id { get; set; }
        [Display(Description = "Movie name")]
        [Required(ErrorMessage ="Field is required")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Field is required")]

        public string Description { get; set; }

        [Display(Name = "Movie price")]
        [Required(ErrorMessage = "Field is required")]

        public double Price { get; set; }
        [Display(Name = "Movie image")]
        [Required(ErrorMessage = "Field is required")]

        public string ImageUrl { get; set; }
        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Field is required")]

        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End date")]
        [Required(ErrorMessage = "Field is required")]

        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Field is required")]

        public MovieCategory MovieCategory { get; set; }

        //RelationShips

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select Cinema(s)")]
        [Required(ErrorMessage = "Cinema(s) is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select Producer(s)")]
        [Required(ErrorMessage = "Producer(s) is required")]
        public int ProducerId { get; set; }
 
    }
}

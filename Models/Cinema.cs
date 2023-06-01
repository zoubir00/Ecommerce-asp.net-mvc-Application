using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaId { get; set; }
        [Display(Name ="Cinema logo")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]

        public string Name { get; set; }

        [Display(Name = "Cinema Description")]

        public string Description { get; set; }

        //RelationShips

        public List<Movie> Movies { get; set; }
    }
}

using EticketsWebApp.Data.Base;
using EticketsWebApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EticketsWebApp.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Movie name")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]

        public string Description { get; set; }

        [Display(Name = "Movie price")]

        public double Price { get; set; }

        [Display(Name = "Movie image")]

        public string ImageUrl { get; set; }

        [Display(Name = "Movie start date")]

        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End date")]

        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]

        public MovieCategory MovieCategory { get; set; }

        //RelationShips

        public List<Actor_Movie> Actors_Movies { get; set; }

        // Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        // producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}

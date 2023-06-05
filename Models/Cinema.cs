using EticketsWebApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "the digits are not enough")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Description { get; set; }

        //RelationShips

        public List<Movie>? Movies { get; set; }
    }
}

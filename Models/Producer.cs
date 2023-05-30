using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        public string profilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
    }
}

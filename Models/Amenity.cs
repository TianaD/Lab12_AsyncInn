using System.ComponentModel.DataAnnotations;

namespace Lab12_AsyncInn.Models
{
    public class Amenity
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

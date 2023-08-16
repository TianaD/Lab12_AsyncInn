using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab12_AsyncInn.Models
{
    public class Amenity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Room_Amenity> RoomAmenities { get; set; }

    }
}

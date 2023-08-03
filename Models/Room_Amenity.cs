using System.ComponentModel.DataAnnotations;
namespace Lab12_AsyncInn.Models
{
    public class Room_Amenity
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public int RoomID { get; set; }

        [Required]
        public int AmenityID { get; set; }
    }
}

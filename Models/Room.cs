using System.ComponentModel.DataAnnotations;

namespace Lab12_AsyncInn.Models
{
    public class Room
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Layout { get; set; }

        public List<Hotel_Room> Hotel_Rooms { get; set; }

        public List<Room_Amenity> Room_Amenities { get; set; }


    }
}

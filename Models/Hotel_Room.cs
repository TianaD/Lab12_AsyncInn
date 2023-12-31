﻿using System.ComponentModel.DataAnnotations;

namespace Lab12_AsyncInn.Models
{
    public class Hotel_Room
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public int RoomID { get; set; }

        [Required]

        public int HotelID { get; set; }
        [Required]
        public double Price { get; set; }

        // navigation properties
        public Hotel Hotel { get; set;  } // hotel room class model 

        public Room Room { get; set; }

    }
}

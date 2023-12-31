﻿using System.ComponentModel.DataAnnotations;
namespace Lab12_AsyncInn.Models
{
    public class Hotel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<Hotel_Room> Hotel_Rooms { get; set; }
    }
}

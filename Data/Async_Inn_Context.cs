using Lab12_AsyncInn;
using Lab12_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12_AsyncInn.Data
{
    public class Async_Inn_Context: DbContext
    {
        public DbSet<Amenity>Amenities;
        public DbSet<Room_Amenity>Room_Amenities;
        public DbSet<Room>Rooms;
        public DbSet<Hotel_Room>Hotel_Rooms;
        public DbSet<Hotel>Hotels;

        public Async_Inn_Context(DbContextOptions<Async_Inn_Context> options): base(options) 
        { 
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //information tables
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 1, Name = "A/C" });
            modelBuilder.Entity<Room>().HasData(new Room { ID = 1, Layout = 0, Name = "Basic Room" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Address = "123 Sesame St", City = "Memphis", State = "TN", Name = "Elmo's World", Phone = "555-555-5555" });


            //lookup tables
            modelBuilder.Entity<Room_Amenity>().HasData(new Room_Amenity { ID = 1, AmenityID = 1, RoomID = 1 });
            modelBuilder.Entity<Hotel_Room>().HasData(new Hotel_Room { ID = 1, HotelID = 1, RoomID = 1, Price = 100.99 });
        }


        public DbSet<Lab12_AsyncInn.Models.Hotel> Hotel { get; set; } = default!;


        public DbSet<Lab12_AsyncInn.Models.Amenity> Amenity { get; set; } = default!;


        public DbSet<Lab12_AsyncInn.Models.Room> Room { get; set; } = default!;

        public DbSet<Lab12_AsyncInn.Models.Hotel_Room> Hotel_Room { get; set; } = default!;

        public DbSet<Lab12_AsyncInn.Models.Room_Amenity> RoomAmenity { get; set; } = default!;
    }
}

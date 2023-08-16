using Lab12_AsyncInn.Data;
using Lab12_AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab12_AsyncInn.Models.Services
{
    public class HotelService : iHotel
    {

        private Async_Inn_Context _context;
        public HotelService(Async_Inn_Context context)
        {
            _context = context;
        }

        public async Task<ActionResult> DeleteHotel(int id)
        {

            // former hotel controller funcationality
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            // end
            return null; // controller returns no content to user ; return null
        }

        // Get All Hotels
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {

            return await _context.Hotels.ToListAsync();
        }

        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            return await _context.Hotel.FindAsync(id);
        }

        public bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {

            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            //update model with new hotel data
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                // save data changes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)


            {
                throw;
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Lab12_AsyncInn.Models;
using Lab12_AsyncInn.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab12_AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly Async_Inn_Context _context;

        public HotelRoomsController(Async_Inn_Context context)
        {
            _context = context;
        }

        // GET: api/<HotelRoomsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel_Room>>> GetHotelRooms()
        {
            if (_context.Hotel_Rooms == null)
            {
                return NotFound();
            }
            return await _context.Hotel_Rooms
                .Include(hotel => hotel.Hotel)
                .Include(hotel => hotel.Room)
                .ToListAsync();
        }

        // GET api/<HotelRoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel_Room>> GetHotelRoom(int id)
        {
            if (_context.Hotel_Rooms == null)
            {
                return NotFound();
            }
            var hotelRoom = await _context.Hotel_Rooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // POST api/<HotelRoomsController>
        [HttpPost]
        public async Task<ActionResult<Hotel_Room>> PostHotelRoom(Hotel_Room hotelRoom)
        {
            {
                if (_context.Hotel_Rooms == null)
                {
                    return Problem("Entity set 'AsyncInnContext.HotelRooms'  is null.");
                }
                _context.Hotel_Rooms.Add(hotelRoom);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.ID }, hotelRoom);
            }

        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, Hotel_Room hotelRoom)
        {
            if (id != hotelRoom.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Hotel_RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<HotelRoomsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int id)
        {
            if (_context.Hotel_Rooms == null)
            {
                return NotFound();
            }
            var hotelRoom = await _context.Hotel_Rooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.Hotel_Rooms.Remove(hotelRoom);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Hotel_RoomExists(int id)
        {
            return (_context.Hotel_Rooms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

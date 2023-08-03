using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_AsyncInn.Data;
using Lab12_AsyncInn.Models;

namespace Lab12_AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly Async_Inn_Context _context;

        public HotelsController(Async_Inn_Context context)
        {
            _context = context;
        }

        // GET: api/Hotels
        // function returns all hotels in database
        // IEnumerable returns a collection of data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
          if (_context.Hotel == null)
          {
              return NotFound();
          }
            return await _context.Hotel.ToListAsync();
        }

        // GET: api/Hotels/5
        // function returns specific hotels
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
          if (_context.Hotel == null)
          {
              return NotFound();
          }
            var hotel = await _context.Hotel.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Put method updates information in table
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // task returning an ActionResult (what is returned should be in the shape of the hotel class) not an IActionResult
        // Post makes a new hotel: somewhere in code I'll create a new hotel object and pass it into this function
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
          if (_context.Hotel == null)
          {
              return Problem("Entity set 'Async_Inn_Context.Hotel'  is null.");
          }
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            //create good success status code
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        // generic what it returns like PUT function/method. It will likely return nothing since it is deleting something.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_context.Hotel == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return (_context.Hotel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

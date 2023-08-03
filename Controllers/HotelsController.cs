using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_AsyncInn.Data;
using Lab12_AsyncInn.Models;
using Lab12_AsyncInn.Models.Interfaces;
using Lab12_AsyncInn.Models.Services;

namespace Lab12_AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly Async_Inn_Context _context;
        private readonly iHotel _hotel;

        public HotelsController(Async_Inn_Context context, iHotel hotel)
        {
            _context = context;
            _hotel = hotel;
        }

        // GET: api/Hotels
        // function returns all hotels in database
        // IEnumerable returns a collection of data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {

            return await _hotel.GetHotel();
        }

        // GET: api/Hotels/5
        // function returns specific hotels
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            return await _hotel.GetHotel(id);
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

            await _hotel.PutHotel(id, hotel);

            return NoContent();


        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // task returning an ActionResult (what is returned should be in the shape of the hotel class) not an IActionResult
        // Post makes a new hotel: somewhere in code I'll create a new hotel object and pass it into this function
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await _hotel.PostHotel(hotel);      

            //create good success status code
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        // generic what it returns like PUT function/method. It will likely return nothing since it is deleting something.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _hotel.HotelExists(id);
        }
    }
}

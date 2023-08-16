using Microsoft.AspNetCore.Mvc;

namespace Lab12_AsyncInn.Models.Interfaces
{
    public interface iHotel
    {

        Task<ActionResult<IEnumerable<Hotel>>> GetHotel();

        Task<ActionResult<Hotel>> GetHotel(int id);

        Task<IActionResult> PutHotel(int id, Hotel hotel);

        Task<ActionResult<Hotel>> PostHotel(Hotel hotel);


        Task<ActionResult> DeleteHotel(int id);

        bool HotelExists(int id);

    }
}

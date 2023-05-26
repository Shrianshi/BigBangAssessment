using BigBangAssessment.Models;
using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly HotelInterfaceRepo _repo;

        public BookingsController(HotelInterfaceRepo repo)
        {
            _repo = repo;
        }

        [HttpGet, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetBookings()
        {
            try
            {
                return Ok(_repo.GetBook());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<Bookings>> PostBook(Bookings book)
        {
            try
            {
                return Ok(_repo.AddBookings(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                return Ok(_repo.DeleteBookings(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UpdateBook(int id, Bookings b)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _repo.UpdateBookings(b, id);

            return Ok("Updated");
        }
    }
}

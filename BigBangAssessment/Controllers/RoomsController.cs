using BigBangAssessment.Models;
using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly HotelInterfaceRepo _repo;

        public RoomsController(HotelInterfaceRepo repo)
        {
            _repo = repo;
        }

        [HttpGet, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetR()
        {
            try
            {
                return Ok(_repo.GetRooms());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<Rooms>> PostHotel(Rooms rooms)
        {
            try
            {
                return Ok(_repo.AddRooms(rooms));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                return Ok(_repo.DeleteRooms(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UpdateRoom(int id, Rooms r)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _repo.UpdateRooms(r, id);

            return Ok("Updated");
        }
    }
}

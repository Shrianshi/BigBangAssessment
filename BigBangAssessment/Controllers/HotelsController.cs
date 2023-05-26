using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BigBangAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using BigBangAssessment.Repository;
using System.Diagnostics;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelInterfaceRepo _repo;

        public HotelsController(HotelInterfaceRepo repo)
        {
            _repo = repo;
        }

        [HttpGet, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            try
            {
                return Ok(_repo.GetHotel());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Rooms")]
        public async Task<IActionResult> GetRooms()
        {
            try
            {
                return Ok(_repo.GetHotelRooms());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost, Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            try
            {

                return Ok(_repo.AddHotel(hotel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                return Ok(_repo.DeleteHotel(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin,admin")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UpdateHot(int id, Hotel h)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _repo.UpdateHotel(h, id);

            return Ok("Updated");
        }
        


    }
}

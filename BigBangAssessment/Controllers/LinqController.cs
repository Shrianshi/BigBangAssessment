using BigBangAssessment.Models;
using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {

        private readonly HotelRoomsContext _context;
        public LinqController(HotelRoomsContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Filter")]
        public ActionResult<IEnumerable<Rooms>> GetInput1(int id)
        {
            try { 
            var name = from n in _context.Rooms.Where(n => n.HotelId == id)
                       select "Room Id: " + n.RId + " Price: " + n.RPrice + " Hotel Name:" + n.Hotel.HName;

            return Ok(name.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Count")]
        public string Get(int id)
        {
            try
            {
                var count = (from c in _context.Rooms.Where(n => n.HotelId == id)
                             select c).Count();
                return ("Number of records available in room's table: " + count);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}

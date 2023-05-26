using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Models
{
    public class HotelRoomsContext:DbContext
    {
        public HotelRoomsContext(DbContextOptions options) : base(options) { }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
    }
}

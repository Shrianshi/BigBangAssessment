using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace BigBangAssessment.Models
{
    public class Rooms
    {
        [Key]
        public int RId { get; set; }
        public string? RType { get; set; }
        public int RPrice { get; set; }
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
        public ICollection<Bookings> Bookings { get; set; }

    }
}

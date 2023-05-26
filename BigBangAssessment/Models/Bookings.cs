using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangAssessment.Models
{
    public class Bookings
    {
        [Key]
        public int BId { get; set; }
        public string? CustName { get;set; }
        public string? BDate { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Rooms? Rooms { get; set; }   


    }
}

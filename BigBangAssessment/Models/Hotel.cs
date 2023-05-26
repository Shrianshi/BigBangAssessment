using System.ComponentModel.DataAnnotations;


namespace BigBangAssessment.Models
{
    public class Hotel
    {
        [Key]
        public int Hid { get; set; }
        public string? HName { get; set; }
        public int? HPhone { get; set;}
        public string? HCity { get; set; }
        public string? HState { get; set; }
        public string? HCountry { get; set;}
        public ICollection<Rooms> Rooms { get; set; }
    }
}

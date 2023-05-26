using BigBangAssessment.Models;

namespace BigBangAssessment.Repository
{
    public interface HotelInterfaceRepo
    {
        //Crud functions on Hotel Table
        IEnumerable<Hotel> GetHotel();
        IEnumerable<Hotel> GetRoomsHotel();
        Hotel GetHotel(int id);
        Hotel AddHotel(Hotel h);
        Hotel UpdateHotel(Hotel h, int id);
        Hotel DeleteHotel(int id);


        //Crud functions on Rooms Table
        IEnumerable<Rooms> GetRooms();
        IEnumerable<Rooms> GetHotelRooms();
        Rooms GetRooms(int id);
        Rooms AddRooms(Rooms r);
        Rooms UpdateRooms(Rooms r, int id);
        Rooms DeleteRooms(int id);
        
    }
}

using BigBangAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Repository
{
    public class HotelRepo : HotelInterfaceRepo
    {
        private readonly HotelRoomsContext _contextDb;
        public HotelRepo(HotelRoomsContext s)
        {
            _contextDb = s;
        }

        //CRUD OPERATION ON HOTEL TABLE
        public Hotel AddHotel(Hotel h)
        {
            var hotels = new Hotel()
            {
                HName = h.HName,
                HPhone = h.HPhone,
                HCity = h.HCity,
                HState = h.HState,
                HCountry = h.HCountry,

            };
            _contextDb.Hotel.Add(hotels);
            _contextDb.SaveChanges();
            return hotels;
        }
        public Hotel DeleteHotel(int id)
        {
            var hotel = _contextDb.Hotel.Find(id);
            _contextDb.Remove(hotel);
            _contextDb.SaveChanges();
            return hotel;
        }
        public IEnumerable<Hotel> GetHotel()
        {
            var hotels = _contextDb.Hotel.Include(p => p.Rooms).ToList();
            return (hotels);
        }

        public Hotel GetHotel(int id)
        {
            var hotel = _contextDb.Hotel.Find(id);
            return hotel;
        }

        public Rooms AddRooms(Rooms r)
        {
            _contextDb.Rooms.Add(r);
            _contextDb.SaveChanges();
            return (r);
        }

        public IEnumerable<Hotel> GetRoomsHotel()
        {
            var hotels = _contextDb.Hotel.ToList();
            return (hotels);
        }

        public Hotel UpdateHotel(Hotel h, int id)
        {
            var hotel = _contextDb.Hotel.Find(id);

            hotel.HName = h.HName;
            hotel.HPhone = h.HPhone;
            hotel.HCity = h.HCity;
            hotel.HState = h.HState;
            hotel.HCountry = h.HCountry;
            _contextDb.Hotel.Update(hotel);
            _contextDb.SaveChanges();
            return (hotel);
        }


        //CRUD OPERATION ON ROOMS TABLE
       
        public Rooms DeleteRooms(int id)
        {
            var rooms = _contextDb.Rooms.Find(id);
            _contextDb.Rooms.Remove(rooms);
            _contextDb.SaveChanges();
            return rooms;
        }

       

        public IEnumerable<Rooms> GetHotelRooms()
        {
            return _contextDb.Rooms.Include(s => s.Hotel).ToList();
        }

        public IEnumerable<Rooms> GetRooms()
        {
            var rooms = _contextDb.Rooms.ToList();


            return rooms;
        }

        public Rooms GetRooms(int id)
        {
            var rooms = _contextDb.Rooms.Find(id);
            return rooms;
        }

        
        public Rooms UpdateRooms(Rooms r, int id)
        {
            var rooms = _contextDb.Rooms.Find(id);
            if (rooms != null)
            {
                _contextDb.Update(rooms);
                _contextDb.SaveChanges();
            }
            return (r);

        }
    }
}

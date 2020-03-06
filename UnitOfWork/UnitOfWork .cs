using Data.EF;
using Data.Entities;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private HotelDataContext _dbContext;

        private BaseRepository<CategoryService> _categoryServices;
        private BaseRepository<CategoryRoom> _categoryRooms;
        private BaseRepository<Room> _rooms;
        private BaseRepository<Service> _services;


        private BaseRepository<BookRoom> _bookRooms;
        private BaseRepository<Guest> _guests;
        private BaseRepository<Booking> _bookings;



        public UnitOfWork(HotelDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<CategoryRoom> CategoryRooms
        {
            get
            {
                return _categoryRooms ??
                       (_categoryRooms = new BaseRepository<CategoryRoom>(_dbContext));
            }
        }

        public IRepository<CategoryService> CategoryServices
        {
            get
            {
                return _categoryServices ??
                       (_categoryServices = new BaseRepository<CategoryService>(_dbContext));
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                return _rooms ??
                       (_rooms = new BaseRepository<Room>(_dbContext));
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                return _services ??
                       (_services = new BaseRepository<Service>(_dbContext));
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                return _guests ??
                       (_guests = new BaseRepository<Guest>(_dbContext));
            }
        }
        public IRepository<Booking> Bookings
        {
            get
            {
                return _bookings ??
                       (_bookings = new BaseRepository<Booking>(_dbContext));
            }
        }
        public IRepository<BookRoom> BookRooms
        {
            get
            {
                return _bookRooms ??
                       (_bookRooms = new BaseRepository<BookRoom>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
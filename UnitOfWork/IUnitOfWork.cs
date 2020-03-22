using Data.Entities;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<CategoryRoom> CategoryRooms { get; }
        IRepository<Room> Rooms { get; }

        IRepository<CategoryService> CategoryServices { get; }
        IRepository<Service> Services { get; }

        IRepository<Guest> Guests { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<BookRoom> BookRooms { get; }

        IRepository<Order> Orders { get; }
        IRepository<OrderDetail> OrderDetails { get; }

        void Commit();
    }
}
using Data.Entities;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<CategoryRoom> CategoryRooms { get; }
        IRepository<CategoryService> CategoryServices { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Service> Services { get; }

        void Commit();
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Repository.Services
{
    public interface ICategoryRoomService : IService<CategoryRoom>
    {
        IEnumerable<CategoryRoom> GetLastedCategoryRooms();
    }
}

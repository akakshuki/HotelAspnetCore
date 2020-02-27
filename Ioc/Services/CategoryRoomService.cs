using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Repository.Interfaces;
using Repository.Services;

namespace Repository.Services
{
  

    public class CategoryRoomService  : Service<CategoryRoom>, ICategoryRoomService
    {
      

        public CategoryRoomService(IUow uow, IRepository<CategoryRoom> repository): base (uow, repository)
        {
        }

        public IEnumerable<CategoryRoom> GetLastedCategoryRooms()
        {
            try
            {
                return GetAll();
            }
            catch (Exception e)
            {
                return new List<CategoryRoom>();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Repository.Interfaces;
using Repository.Services;

namespace Repository.DTO
{
    public interface ICategoryRoomService : IService<CategoryRoom>
    {

    }

    public class CategoryRoomService  : Service<CategoryRoom>, ICategoryRoomService
    {
      

        public CategoryRoomService(IUow uow, IRepository<CategoryRoom> repository): base (uow, repository)
        {

        }
    }
}

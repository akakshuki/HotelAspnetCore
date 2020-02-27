using System;
using System.Collections.Generic;
using System.Text;
using Data.EF;
using Data.Entities;

namespace Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HotelDataContext _dbContext;
        private BaseRepository<CategoryRoom> _categoryRoom;
        private BaseRepository<Order> _orders;


        public UnitOfWork(HotelDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override IRepository<CategoryRoom> CategoryRoom
        {
            get
            {
                return _categoryRoom ??
                       (_categoryRoom = new BaseRepository<CategoryRoom>(_dbContext));
            }
        }


        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public IRepository<CategoryService> CategoryServiceRep { get; }
        public override IRepository<Order> Orders { get; }
    }
}

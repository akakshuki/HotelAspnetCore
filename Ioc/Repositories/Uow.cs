using System;
using System.Collections.Generic;
using System.Text;
using Data.EF;
using Repository.Interfaces;
using Repository.Services;

namespace Repository.Repositories
{
   public class Uow : IUow
    {
        private HotelDataContext _data;

        private IDBFactory _dbFactory;

        public Uow(IDBFactory dbfactory)
        {
            _dbFactory = dbfactory;
        }

        public HotelDataContext Data
            => _data ?? (_data = _dbFactory.Init());

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

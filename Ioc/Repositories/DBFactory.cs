using System;
using System.Collections.Generic;
using System.Text;
using Data.EF;
using Repository.Services;

namespace Repository.Repositories
{
    class DBFactory :IDBFactory
    {
        private HotelDataContext _data;

        public void Dispose()
        {
            if (_data != null)
            {
                _data.Dispose();
            }
        }

        public HotelDataContext Init()
        {
            return _data ?? (_data = new HotelDataContext());
        }
    }
}

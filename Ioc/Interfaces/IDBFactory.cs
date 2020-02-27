using System;
using System.Collections.Generic;
using System.Text;
using Data.EF;

namespace Repository.Services
{
    public interface IDBFactory : IDisposable
    {
        //initial data  contex to interface here
        HotelDataContext Init();   
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services
{
    public interface IService
    {

    }

    public interface IService<T> : IService where  T : class
    {
        IEnumerable<T> GetAll();
        T FindById(object id);
        void Insert(T t);
        void Delete(object id);
        void Update(T t);
        void Save();
        }
}

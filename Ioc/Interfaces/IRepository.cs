using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where  T : class
    {

        //initial all request to db if you want in this interface
        IEnumerable<T> GetAll();
        T FindById(object id);
        void Insert(T t);
        void Delete(object id);
        void Update(T t);   
    }
}

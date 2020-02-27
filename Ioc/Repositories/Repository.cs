using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Services;

namespace Repository.Repositories
{
   public class Repository<T> : IRepository<T> where T : class
    {
        internal HotelDataContext _context;
        internal DbSet<T> _dbSet;
        protected IDBFactory DbFactory
        {
            get;
            private set;
        }
        protected HotelDataContext DbContext => _context ?? (_context = DbFactory.Init());


        public Repository(IDBFactory dbFactory)
        {
            DbFactory = dbFactory;
            this._dbSet = DbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

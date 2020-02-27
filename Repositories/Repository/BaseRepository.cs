using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository
{
   public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal HotelDataContext context;
        internal DbSet<TEntity> dbSet;




        public BaseRepository(HotelDataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public Task Delete(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public static implicit operator BaseRepository<TEntity>(BaseRepository<CategoryRoom> v)
        {
            throw new NotImplementedException();
        }
    }
}

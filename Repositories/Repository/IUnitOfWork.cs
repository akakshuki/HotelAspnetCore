using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Repositories.Repository
{
    public abstract class IUnitOfWork
    {
        public abstract IRepository<CategoryRoom> CategoryRoom { get; }
        public abstract IRepository<Order> Orders { get; }
    }
}

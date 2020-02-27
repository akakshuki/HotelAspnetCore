using System;
using System.Collections.Generic;
using System.Text;
using Repository.Interfaces;

namespace Repository.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private IUow _uow;
        private IRepository<T> _repository;
        private IService<T> _serviceImplementation;

        public Service(IUow uow, IRepository<T> repository)
        {
            this._uow = uow;
            this._repository = repository;
        }


        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T FindById(object id)
        {
            return _repository.FindById(id);
        }

        public void Insert(T t)
        {
            _repository.Insert(t);
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public void Update(T t)
        {
          _repository.Update(t);
        }

        public void Save()
        {
            _uow.Save();
        }
    }

}

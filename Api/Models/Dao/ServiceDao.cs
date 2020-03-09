using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace Api.Models.Dao
{
    public class ServiceDao
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ServiceDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public ActionResult<IEnumerable<ServiceMv>> GetAll()
        {
            var service = _unitOfWork.Services.Get();
            var list = _mapper.Map<List<ServiceMv>>(service);
            return list;
        }

        public ActionResult<ServiceMv> GetById(int id)
        {
            var data = _unitOfWork.Services.GetByID(id);
            var Service = _mapper.Map<ServiceMv>(data);
            return Service;
        }

        public ActionResult<List<ServiceMv>> GetListServiceByIdCate(int id)
        {
            var data = _unitOfWork.Services.Get();
            data = data.Where(x => x.CategoryServiceId == id).ToList();
            var Service = _mapper.Map<List<ServiceMv>>(data);
            return Service;
        }

        public void Create(ServiceMv service)
        {
            var data = new Service()
            {
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                CategoryServiceId = service.CategoryServiceId,
                Status = true
            };
            try
            {
                _unitOfWork.Services.Insert(data);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(ServiceMv service)
        {
            var data = new Service()
            {
                Name = service.Name,
                Description = service.Description,
                CategoryServiceId = service.CategoryServiceId,
                Status = true
            };
            try
            {
                _unitOfWork.Services.Update(data);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(in int id)
        {
            try
            {
                _unitOfWork.Services.Delete(id);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
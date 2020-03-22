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

        public IEnumerable<ServiceMv> GetAll()
        {
            var service = _unitOfWork.Services.Get();
            var category = _unitOfWork.CategoryServices.Get();
            var list = _mapper.Map<List<ServiceMv>>(service);
            var listCate = _mapper.Map<List<CategoryServicesMv>>(category);

            foreach (var serviceMv in list)
            {
                serviceMv.CategoryServicesMv = listCate.SingleOrDefault(x => x.Id == serviceMv.CategoryServiceId);
            }
            return list;
        }

        public ActionResult<ServiceMv> GetById(int id)
        {
            var data = _unitOfWork.Services.GetByID(id);
            var datacate = _unitOfWork.CategoryServices.GetByID(data.CategoryServiceId);
            var Service = _mapper.Map<ServiceMv>(data);
            var category = _mapper.Map<CategoryServicesMv>(datacate);
            Service.CategoryServicesMv = category;
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
                CategoryServiceId = service.CategoryServiceId
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
                Status = service.Status
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

        public List<ServiceMv> GetServiceByCategoryId( int id)
        {
            var data = _mapper.Map<List<ServiceMv>>(_unitOfWork.Services.Get().Where(x => x.CategoryServiceId == id).ToList());
            foreach (var serviceMv in data)
            {
                serviceMv.CategoryServicesMv =
                    _mapper.Map<CategoryServicesMv>(_unitOfWork.CategoryServices.GetByID(serviceMv.CategoryServiceId));
            }
            return data;
        }
    }
}
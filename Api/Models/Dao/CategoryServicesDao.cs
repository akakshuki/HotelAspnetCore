using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitOfWork;

namespace Api.Models.Dao
{
    internal class CategoryServicesDao
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CategoryServicesDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<CategoryServicesMv>> GetAll()
        {
            var category = _unitOfWork.CategoryServices.Get();
            var list = _mapper.Map<List<CategoryServicesMv>>(category);
            return list;
        }

        public ActionResult<CategoryServicesMv> GetById(in int id)
        {
            var data = _unitOfWork.CategoryServices.GetByID(id);
            var categoryRoom = _mapper.Map<CategoryServicesMv>(data);
            return categoryRoom;
        }

        public void Create(CategoryServicesMv data)
        {
            var categoryRoom = new CategoryService()
            {
                Name = data.Name
            };
            try
            {
                _unitOfWork.CategoryServices.Insert(categoryRoom);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(CategoryServicesMv data)
        {
            var category = new CategoryService()
            {
                Id = data.Id,
                Name = data.Name
            };
            try
            {
                _unitOfWork.CategoryServices.Update(category);
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
                _unitOfWork.CategoryServices.Delete(id);
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
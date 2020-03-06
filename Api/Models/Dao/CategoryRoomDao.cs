using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Api.Models.Dao
{
    public class CategoryRoomDao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryRoomDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(CategoryRoomMv data)
        {
            var categoryRoom = new CategoryRoom()
            {
                Name = data.Name,
                Price = data.Price,
                Description = data.Description
            };
            try
            {
                _unitOfWork.CategoryRooms.Insert(categoryRoom);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult<IEnumerable<CategoryRoomMv>> GetAll()
        {
            var categoryRooms = _unitOfWork.CategoryRooms.Get();
            var list = _mapper.Map<List<CategoryRoomMv>>(categoryRooms);
            return list;
        }

        public ActionResult<CategoryRoomMv> GetById(int id)
        {
            var data = _unitOfWork.CategoryRooms.GetByID(id);
            var categoryRoom = _mapper.Map<CategoryRoomMv>(data);
            return categoryRoom;
        }


        public void Update(CategoryRoomMv category)
        {
            var data = new CategoryRoom()
            {
                Id = category.Id,
                Name = category.Name,
                Price = category.Price,
                Description = category.Description
            };
            try
            {
                _unitOfWork.CategoryRooms.Update(data);
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
                _unitOfWork.CategoryRooms.Delete(id);
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
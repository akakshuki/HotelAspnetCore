using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var categoryRoom = _mapper.Map<CategoryRoom>(data);
            try
            {
                _unitOfWork.CategoryRooms.Insert(categoryRoom);
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
    }
}
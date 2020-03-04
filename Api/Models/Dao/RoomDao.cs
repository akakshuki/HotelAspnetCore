using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace Api.Models.Dao
{
    public class RoomDao
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomDao(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public ActionResult<IEnumerable<RoomMv>> GetAll()
        {
            var room = _unitOfWork.Rooms.Get();
            var list = _mapper.Map<List<RoomMv>>(room);
            return list;
        }

        public ActionResult<RoomMv> GetById(int id)
        {
            var data = _unitOfWork.Rooms.GetByID(id);
            var room = _mapper.Map<RoomMv>(data);
            return room;
        }

        public void Create(RoomMv room)
        {
            var Room = new Room()
            {
               RoomNo = room.RoomNo,
               CategoryRoomId = room.CategoryRoomId,
               Status = true 
            };
            try
            {
                _unitOfWork.Rooms.Insert(Room);
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

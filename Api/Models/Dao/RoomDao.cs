﻿using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var category = _unitOfWork.CategoryRooms.Get();
            var listCate = _mapper.Map<List<CategoryRoomMv>>(category);
            var list = _mapper.Map<List<RoomMv>>(room);
            foreach (var roomMv in list)
            {
                roomMv.CategoryRoomMv = listCate.Where(x => x.Id == roomMv.CategoryRoomId).SingleOrDefault();
            }
            return list;
        }

        public ActionResult<RoomMv> GetById(int id)
        {
            var data = _unitOfWork.Rooms.GetByID(id);
            var category = _unitOfWork.CategoryRooms.GetByID(data.Id);
            var categoryRoom = _mapper.Map<CategoryRoomMv>(category);
            var room = _mapper.Map<RoomMv>(data);
            room.CategoryRoomMv = categoryRoom;
            return room;
        }

        public List<RoomMv> GetListRoomByIdCate(int id)
        {
            var data = _unitOfWork.Rooms.Get();
            data = data.Where(x => x.CategoryRoomId == id).ToList();
            var room = _mapper.Map<List<RoomMv>>(data);
            return room;
        }

        public void Create(RoomMv room)
        {
            var Room = new Room()
            {
                RoomNo = room.RoomNo,
                CategoryRoomId = room.CategoryRoomId
            
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

        public void Update(RoomMv room)
        {
            var data = new Room()
            {
                Id = room.Id,
                RoomNo = room.RoomNo,
                CategoryRoomId = room.CategoryRoomId

            };
            try
            {
                _unitOfWork.Rooms.Update(data);
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
                _unitOfWork.Rooms.Delete(id);
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
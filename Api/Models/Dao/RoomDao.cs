using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork;
using Room = Data.Entities.Room;

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




        public List<RoomMv> GetListEmptyRoomByIdCate(int id)
        
        {
            
            var bookedRoom = _unitOfWork.Bookings.Get().Where(x => x.Status == BookedStatus.booked).ToList();
            var listRoomBooked = new List<Room>();
            
            foreach (var booking in bookedRoom)
            {
                var listBook = _unitOfWork.BookRooms.Get().Where(x => x.BookingId == booking.Id).ToList();
                foreach (var bookRoom in  listBook)
                {
                    listRoomBooked.Add(_unitOfWork.Rooms.Get().Where(x=>x.Id == bookRoom.RoomId ).FirstOrDefault());   
                }
            }

            var rooms = _unitOfWork.Rooms.Get().ToList();
            foreach (var room in listRoomBooked)
            {
                rooms.Remove(room);
            }

            var roomEmpty = _mapper.Map<List<RoomMv>>(rooms.Where(x => x.CategoryRoomId == id).ToList());

            return roomEmpty;

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

        public void Create(RoomApi room)
        {
            var Room = new Room()
            {
                RoomNo = room.RoomNo,
                CategoryRoomId = room.CategoryRoomId,
                Status = Status.Active
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
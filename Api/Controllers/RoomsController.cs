using Api.Models.Dao;
using Api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RoomsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<RoomMv>> Get()
        {
            try
            {
                var data = new RoomDao(_unitOfWork, _mapper).GetAll();
                if (data == null)
                {
                    return NotFound();
                }
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public ActionResult<RoomMv> Get(int id)
        {
            try
            {
                var data = new RoomDao(_unitOfWork, _mapper).GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // GET: api/Rooms/5
        [HttpGet("CountRoom/{idCategoryRoom}")]
        public ActionResult<RoomMv> GetCountRoom(int idCategoryRoom)
        {
            try
            {
                var data = new RoomDao(_unitOfWork, _mapper).GetListRoomByIdCate(idCategoryRoom);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }


        // GET: api/Rooms/5
        [HttpGet("GetEmptyRoom/{idCategoryRoom}")]
        public ActionResult<RoomMv> GetEmptyRoom(int idCategoryRoom)
        {
            try
            {
                var data = new RoomDao(_unitOfWork, _mapper).GetListEmptyRoomByIdCate(idCategoryRoom);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // POST: api/Rooms
        [HttpPost]
        public IActionResult Post([FromBody]RoomMv room)
        {
            try
            {
                new RoomDao(_unitOfWork, _mapper).Create(room);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoomMv room)
        {
            try
            {
                new RoomDao(_unitOfWork, _mapper).Update(room);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                new RoomDao(_unitOfWork, _mapper).Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
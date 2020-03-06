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
    public class CategoryRoomsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CategoryRoomsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/CategoryRooms
        [HttpGet]
        public ActionResult<IEnumerable<CategoryRoomMv>> Get()
        {
            try
            {
                var data = new CategoryRoomDao(_unitOfWork, _mapper).GetAll();
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

        // GET: api/CategoryRooms/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CategoryRoomMv> Get(int id)
        {
            try
            {
                var data = new CategoryRoomDao(_unitOfWork, _mapper).GetById(id);
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

       // POST: api/CategoryRooms
        [HttpPost]
        public IActionResult Post([FromBody]CategoryRoomMv category)
        {
            try
            {
                //var result = JsonConvert.DeserializeObject<CategoryRoomMv>(category);
                new CategoryRoomDao(_unitOfWork, _mapper).Create(category);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/CategoryRooms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryRoomMv category)
        {
            try
            {
                new CategoryRoomDao(_unitOfWork, _mapper).Update(category);
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
                new CategoryRoomDao(_unitOfWork, _mapper).Delete(id);
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
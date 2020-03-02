using Api.Models.Dao;
using Api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Data.Entities;
using Newtonsoft.Json;
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
       public void Post(CategoryRoomMv category)
        {
            try
            {
                //var result = JsonConvert.DeserializeObject<CategoryRoomMv>(category);
                new CategoryRoomDao(_unitOfWork, _mapper).Create(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }

        // PUT: api/CategoryRooms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
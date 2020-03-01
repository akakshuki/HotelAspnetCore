using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Dao;
using Api.Models.DTOs;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryRoomsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public CategoryRoomsController(IUnitOfWork unitOfWork, IMapper mapper )
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
                return new CategoryRoomDao(_unitOfWork, _mapper).GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // GET: api/CategoryRooms/5
        [HttpGet("{id}", Name = "Get")]
        public CategoryRoom Get(int id)
        {
            return _unitOfWork.CategoryRooms.GetByID(id);
        }

        // POST: api/CategoryRooms
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CategoryRoomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CategoryRooms
        [HttpGet]
        public IEnumerable<CategoryRoom> Get()
        {
            return _unitOfWork.CategoryRooms.Get();
        }

        // GET: api/CategoryRooms/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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

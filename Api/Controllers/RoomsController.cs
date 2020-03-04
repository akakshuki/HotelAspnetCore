using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Dao;
using Api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                var data = new RoomDao(_unitOfWork,_mapper).GetAll();
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

    }
}
using Api.Models.Dao;
using Api.Models.DTOs;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
      
       

        public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
         
        }

        // POST: api/Booking
        [HttpPost]
        public IActionResult Post([FromBody] BookMv booking)
        {
            try
            {
                new BookingDao(_unitOfWork, _mapper).CreateBooking(booking);
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
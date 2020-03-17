using Api.Models.Dao;
using Api.Models.DTOs;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        [HttpPost("guestpost")]
        public async Task<IActionResult> UserPost([FromBody] BookMv booking)
        {
            try
            {
                await new BookingDao(_unitOfWork, _mapper).CreateBooking(booking);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        [HttpPost("employeepost")]
        public async Task<IActionResult> EmpleePostAsync([FromBody] BookMv booking)
        {
            try
            {
              await  new BookingDao(_unitOfWork, _mapper).EmployeCreateBooking(booking);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        [HttpGet("CheckGuest")]
        public IActionResult CheckGuest(string email)
        {
            try
            {
                if (new BookingDao(_unitOfWork, _mapper).checkGuest(email))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [HttpGet("GetGuest")]
        public ActionResult<List<GuestMv>> GetGuest()
        {
            try
            {
                var data = new GuestDao(_unitOfWork, _mapper).GetListGuest();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
                throw;
            }

            
        }
        [HttpGet("GetBookingOnline")]
        public IActionResult GetBookingOnline()
        {
            try
            {
                var data = new BookingDao(_unitOfWork, _mapper).GetListBookingOnline();
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
                throw;
            }
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking()
        {
            try
            {
                var data = new BookingDao(_unitOfWork, _mapper).GetListBooking();
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
                throw;
            }
        }


    }
}
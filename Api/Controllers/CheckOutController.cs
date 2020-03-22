using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Dao;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CheckOutController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetDataForCheckOut/{orderNo}")]
        public IActionResult GetDataForCheckOut(string orderNo)
        {
            try
            {
                var data = new OrderDao(_unitOfWork,_mapper).getOrderServiceByOrderNo(Guid.Parse(orderNo));
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

        }
        [HttpGet("GetDataForCheckOut/{orderNo}/{cash}/{money}")]
        public IActionResult SetDataToCashCheckOut(string orderNo, int cash, decimal money)
        {
            try
            {
                if (cash == 1)
                {
                    new OrderDao(_unitOfWork, _mapper).SetOrderByCard(Guid.Parse(orderNo));
                    return Ok();
                }
                else
                {
                    var data = new OrderDao(_unitOfWork, _mapper).SetOrderByMomo(Guid.Parse(orderNo),money);
                    return Ok(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

        }
    }
}
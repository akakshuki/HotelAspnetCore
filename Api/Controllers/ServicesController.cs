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
    public class ServicesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ServicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Services
        [HttpGet]
        public ActionResult<IEnumerable<ServiceMv>> Get()
        {
            try
            {
                var data = new ServiceDao(_unitOfWork, _mapper).GetAll();
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

        // GET: api/Services/5
        [HttpGet("{id}")]
        public ActionResult<ServiceMv> Get(int id)
        {
            try
            {
                var data = new ServiceDao(_unitOfWork, _mapper).GetById(id);
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

        // GET: api/Services/5
        [HttpGet("CountService/{idCategoryService}")]
        public ActionResult<ServiceMv> GetCountService(int idCategoryService)
        {
            try
            {
                var data = new ServiceDao(_unitOfWork, _mapper).GetListServiceByIdCate(idCategoryService);
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

        // POST: api/Services
        [HttpPost]
        public IActionResult Post([FromBody]ServiceMv Service)
        {
            try
            {
                new ServiceDao(_unitOfWork, _mapper).Create(Service);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ServiceMv Service)
        {
            try
            {
                new ServiceDao(_unitOfWork, _mapper).Update(Service);
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
                new ServiceDao(_unitOfWork, _mapper).Delete(id);
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
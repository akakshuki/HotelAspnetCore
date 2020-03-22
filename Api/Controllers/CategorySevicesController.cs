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
    public class CategoryServicesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CategoryServicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/CategoryServices
        [HttpGet]
        public ActionResult<IEnumerable<CategoryServicesMv>> Get()
        {
            try
            {
                var data = new CategoryServicesDao(_unitOfWork, _mapper).GetAll();
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

        // GET: api/CategoryServices/5
        [HttpGet("{id}")]
        public ActionResult<CategoryServicesMv> Get(int id)
        {
            try
            {
                var data = new CategoryServicesDao(_unitOfWork, _mapper).GetById(id);
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

        // POST: api/CategoryServices
        [HttpPost]
        public IActionResult Post([FromBody]CategoryServicesMv category)
        {
            try
            {
                //var result = JsonConvert.DeserializeObject<CategoryServicesMv>(category);
                new CategoryServicesDao(_unitOfWork, _mapper).Create(category);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/CategoryServices/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryServicesMv category)
        {
            try
            {
                new CategoryServicesDao(_unitOfWork, _mapper).Update(category);
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
                new CategoryServicesDao(_unitOfWork, _mapper).Delete(id);
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
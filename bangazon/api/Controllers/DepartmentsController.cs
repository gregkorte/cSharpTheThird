using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/departments
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _context.Department.ToList();
            if(departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetSingleDepartment")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Department department = _context.Department.Single(c => c.DepartmentId == id);

                if(department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/departments
        [HttpPost]
        public IActionResult Post([FromBody]Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Department.Add(department);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(DepartmentExists(department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleDepartment", new { id = department.DepartmentId }, department);
        }

        // PUT api/departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != department.DepartmentId)
            {
                return BadRequest();
            }
            _context.Department.Update(department);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        private bool DepartmentExists(int departmentId)
        {
            return _context.Department.Any(c => c.DepartmentId == departmentId);
        }
    }
}

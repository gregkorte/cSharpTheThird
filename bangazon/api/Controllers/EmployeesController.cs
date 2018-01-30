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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/employees
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _context.Employee.ToList();
            if(employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET api/employees/5
        [HttpGet("{id}", Name = "GetSingleEmployee")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Employee employee = _context.Employee.Single(c => c.EmployeeId == id);

                if(employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/employees
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Employee.Add(employee);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(EmployeeExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.EmployeeId }, employee);
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }
            _context.Employee.Update(employee);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!EmployeeExists(id))
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

        private bool EmployeeExists(int employeeId)
        {
            return _context.Employee.Any(c => c.EmployeeId == employeeId);
        }
    }
}

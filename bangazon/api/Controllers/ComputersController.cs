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
    public class ComputersController : Controller
    {
        private ApplicationDbContext _context;

        public ComputersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/computers
        [HttpGet]
        public IActionResult Get()
        {
            var computers = _context.Computer.ToList();
            if(computers == null)
            {
                return NotFound();
            }
            return Ok(computers);
        }

        // GET api/computers/5
        [HttpGet("{id}", Name = "GetSingleComputer")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Computer computer = _context.Computer.Single(c => c.ComputerId == id);

                if(computer == null)
                {
                    return NotFound();
                }
                return Ok(computer);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/computers
        [HttpPost]
        public IActionResult Post([FromBody]Computer computer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Computer.Add(computer);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(ComputerExists(computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleComputer", new { id = computer.ComputerId }, computer);
        }

        // PUT api/computers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Computer computer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != computer.ComputerId)
            {
                return BadRequest();
            }
            _context.Computer.Update(computer);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!ComputerExists(id))
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

        // DELETE api/computers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Computer computer = _context.Computer.Single(c => c.ComputerId == id);

            if(computer == null)
            {
                return NotFound();
            }
            _context.Computer.Remove(computer);
            _context.SaveChanges();
            return Ok(computer);
        }

        private bool ComputerExists(int computerId)
        {
            return _context.Computer.Any(c => c.ComputerId == computerId);
        }
    }
}

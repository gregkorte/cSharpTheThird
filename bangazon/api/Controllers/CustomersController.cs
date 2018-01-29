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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/customers
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customer.ToList();
            if(customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetSingleCustomer")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Customer customer = _context.Customer.Single(c => c.CustomerId == id);

                if(customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch(System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Customer.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleCustomer", new { id = customer.CustomerId }, customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != customer.CustomerId)
            {
                return BadRequest();
            }
            _context.Customer.Update(customer);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!CustomerExists(id))
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

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _context.Customer.Single(c => c.CustomerId == id);

            if(customer == null)
            {
                return NotFound();
            }
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        private bool CustomerExists(int customerId)
        {
            return _context.Customer.Any(c => c.CustomerId == customerId);
        }
    }
}

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
            string active = HttpContext.Request.Query["active"];
            if(active != null)
            {
                if(active == "false")
                {
                    var inactive = _context.Customer
                    .Select(c => c)
                    .Where(c => !c.Active)
                    .ToList();
                    if(inactive == null)
                    {
                        return NotFound();
                    }
                    return Ok(inactive);
                }
                else
                {
                    return NotFound();
                }
            }
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
                Console.Write(ex);
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

        private bool CustomerExists(int customerId)
        {
            return _context.Customer.Any(c => c.CustomerId == customerId);
        }
    }
}

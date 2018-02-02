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
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/orders
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _context.Order
                    .Select(o => new {
                        OrderId = o.OrderId,
                        CustomerId = o.CustomerId,
                        PaymentTypeId = o.PaymentTypeId
                    }).ToList();

            if(orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/orders/5
        [HttpGet("{id}", Name = "GetSingleOrder")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var order = _context.Order
                .Where(o => o.OrderId == id)
                .Select(o => new {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    PaymentTypeId = o.PaymentTypeId,
                    Products = o.OrderProducts
                        .Select(p => new {
                            ProductId = p.ProductId,
                            Name = p.Product.Title,
                            Description = p.Product.Description,
                            Price = p.Product.Price
                        })
                    }
                );

                if(order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/orders
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Order.Add(order);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = order.OrderId }, order);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != order.OrderId)
            {
                return BadRequest();
            }
            _context.Order.Update(order);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!OrderExists(id))
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

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = _context.Order.Single(c => c.OrderId == id);

            if(order == null)
            {
                return NotFound();
            }
            _context.Order.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }

        private bool OrderExists(int orderId)
        {
            return _context.Order.Any(c => c.OrderId == orderId);
        }
    }
}

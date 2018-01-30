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
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Product.ToList();
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/products/5
        [HttpGet("{id}", Name = "GetSingleProduct")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Product product = _context.Product.Single(c => c.ProductId == id);

                if(product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Product.Add(product);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProduct", new { id = product.ProductId }, product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != product.ProductId)
            {
                return BadRequest();
            }
            _context.Product.Update(product);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!ProductExists(id))
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

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Product.Single(c => c.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        private bool ProductExists(int productId)
        {
            return _context.Product.Any(c => c.ProductId == productId);
        }
    }
}

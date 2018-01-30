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
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/productTypes
        [HttpGet]
        public IActionResult Get()
        {
            var productTypes = _context.ProductType.ToList();
            if(productTypes == null)
            {
                return NotFound();
            }
            return Ok(productTypes);
        }

        // GET api/productTypes/5
        [HttpGet("{id}", Name = "GetSingleProductType")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProductType productType = _context.ProductType.Single(c => c.ProductTypeId == id);

                if(productType == null)
                {
                    return NotFound();
                }
                return Ok(productType);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/productTypes
        [HttpPost]
        public IActionResult Post([FromBody]ProductType productType)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.ProductType.Add(productType);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(ProductTypeExists(productType.ProductTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProductType", new { id = productType.ProductTypeId }, productType);
        }

        // PUT api/productTypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductType productType)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != productType.ProductTypeId)
            {
                return BadRequest();
            }
            _context.ProductType.Update(productType);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!ProductTypeExists(id))
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

        // DELETE api/productTypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductType productType = _context.ProductType.Single(c => c.ProductTypeId == id);

            if(productType == null)
            {
                return NotFound();
            }
            _context.ProductType.Remove(productType);
            _context.SaveChanges();
            return Ok(productType);
        }

        private bool ProductTypeExists(int productTypeId)
        {
            return _context.ProductType.Any(c => c.ProductTypeId == productTypeId);
        }
    }
}

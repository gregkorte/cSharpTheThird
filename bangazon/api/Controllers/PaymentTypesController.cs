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
    public class PaymentTypesController : Controller
    {
        private ApplicationDbContext _context;

        public PaymentTypesController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/paymentTypes
        [HttpGet]
        public IActionResult Get()
        {
            var paymentTypes = _context.PaymentType.ToList();
            if(paymentTypes == null)
            {
                return NotFound();
            }
            return Ok(paymentTypes);
        }

        // GET api/paymentTypes/5
        [HttpGet("{id}", Name = "GetSinglePaymentType")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentType paymentType = _context.PaymentType.Single(c => c.PaymentTypeId == id);

                if(paymentType == null)
                {
                    return NotFound();
                }
                return Ok(paymentType);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/paymentTypes
        [HttpPost]
        public IActionResult Post([FromBody]PaymentType paymentType)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.PaymentType.Add(paymentType);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(PaymentTypeExists(paymentType.PaymentTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
        }

        // PUT api/paymentTypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PaymentType paymentType)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != paymentType.PaymentTypeId)
            {
                return BadRequest();
            }
            _context.PaymentType.Update(paymentType);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!PaymentTypeExists(id))
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

        // DELETE api/paymentTypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PaymentType paymentType = _context.PaymentType.Single(c => c.PaymentTypeId == id);

            if(paymentType == null)
            {
                return NotFound();
            }
            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        private bool PaymentTypeExists(int paymentTypeId)
        {
            return _context.PaymentType.Any(c => c.PaymentTypeId == paymentTypeId);
        }
    }
}

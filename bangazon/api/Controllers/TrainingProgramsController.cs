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
    public class TrainingProgramsController : Controller
    {
        private ApplicationDbContext _context;

        public TrainingProgramsController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        // GET api/trainingPrograms
        [HttpGet]
        public IActionResult Get()
        {
            var trainingPrograms = _context.TrainingProgram.ToList();
            if(trainingPrograms == null)
            {
                return NotFound();
            }
            return Ok(trainingPrograms);
        }

        // GET api/trainingPrograms/5
        [HttpGet("{id}", Name = "GetSingleTrainingProgramType")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                TrainingProgram trainingProgram = _context.TrainingProgram.Single(c => c.TrainingProgramId == id);

                if(trainingProgram == null)
                {
                    return NotFound();
                }
                return Ok(trainingProgram);
            }
            catch(System.InvalidOperationException ex)
            {
                Console.Write(ex);
                return NotFound();
            }
        }

        // POST api/trainingPrograms
        [HttpPost]
        public IActionResult Post([FromBody]TrainingProgram trainingProgram)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.TrainingProgram.Add(trainingProgram);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                if(TrainingProgramExists(trainingProgram.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleTrainingProgram", new { id = trainingProgram.TrainingProgramId }, trainingProgram);
        }

        // PUT api/trainingPrograms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrainingProgram trainingProgram)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != trainingProgram.TrainingProgramId)
            {
                return BadRequest();
            }
            _context.TrainingProgram.Update(trainingProgram);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if(!TrainingProgramExists(id))
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

        // DELETE api/trainingPrograms/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TrainingProgram trainingProgram = _context.TrainingProgram.Single(c => c.TrainingProgramId == id);

            if(trainingProgram == null)
            {
                return NotFound();
            }
            _context.TrainingProgram.Remove(trainingProgram);
            _context.SaveChanges();
            return Ok(trainingProgram);
        }

        private bool TrainingProgramExists(int trainingProgramId)
        {
            return _context.TrainingProgram.Any(c => c.TrainingProgramId == trainingProgramId);
        }
    }
}

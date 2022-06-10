using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolizaSeguros.Data;
using PolizaSeguros.Models;

namespace PolizaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly PolizaSeguroDbContext _context;

        public PlanController(PolizaSeguroDbContext context)
        {
            _context = context;
        }

        // GET: api/Plan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanModels>>> GetPlanModels()
        {
            return await _context.PlanModels.ToListAsync();
        }

        // GET: api/Plan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanModels>> GetPlanModels(int id)
        {
            var planModels = await _context.PlanModels.FindAsync(id);

            if (planModels == null)
            {
                return NotFound();
            }

            return planModels;
        }

        // PUT: api/Plan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanModels(int id, PlanModels planModels)
        {
            if (id != planModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(planModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanModels>> PostPlanModels(PlanModels planModels)
        {
            _context.PlanModels.Add(planModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanModels", new { id = planModels.Id }, planModels);
        }

        // DELETE: api/Plan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanModels(int id)
        {
            var planModels = await _context.PlanModels.FindAsync(id);
            if (planModels == null)
            {
                return NotFound();
            }

            _context.PlanModels.Remove(planModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanModelsExists(int id)
        {
            return _context.PlanModels.Any(e => e.Id == id);
        }
    }
}

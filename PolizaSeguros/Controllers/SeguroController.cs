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
    public class SeguroController : ControllerBase
    {
        private readonly PolizaSeguroDbContext _context;

        public SeguroController(PolizaSeguroDbContext context)
        {
            _context = context;
        }

        // GET: api/Seguro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguroModels>>> GetSeguroModels()
        {
            return await _context.SeguroModels.ToListAsync();
        }

        // GET: api/Seguro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeguroModels>> GetSeguroModels(int id)
        {
            var seguroModels = await _context.SeguroModels.FindAsync(id);

            if (seguroModels == null)
            {
                return NotFound();
            }

            return seguroModels;
        }

        // PUT: api/Seguro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguroModels(int id, SeguroModels seguroModels)
        {
            if (id != seguroModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguroModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroModelsExists(id))
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

        // POST: api/Seguro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeguroModels>> PostSeguroModels(SeguroModels seguroModels)
        {
            _context.SeguroModels.Add(seguroModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguroModels", new { id = seguroModels.Id }, seguroModels);
        }

        // DELETE: api/Seguro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguroModels(int id)
        {
            var seguroModels = await _context.SeguroModels.FindAsync(id);
            if (seguroModels == null)
            {
                return NotFound();
            }

            _context.SeguroModels.Remove(seguroModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguroModelsExists(int id)
        {
            return _context.SeguroModels.Any(e => e.Id == id);
        }
    }
}

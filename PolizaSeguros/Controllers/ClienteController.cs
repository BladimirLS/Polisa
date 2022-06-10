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
    public class ClienteController : ControllerBase
    {
        private readonly PolizaSeguroDbContext _context;

        public ClienteController(PolizaSeguroDbContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModels>>> GetClienteModels()
        {
            return await _context.ClienteModels.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModels>> GetClienteModels(int id)
        {
            var clienteModels = await _context.ClienteModels.FindAsync(id);

            if (clienteModels == null)
            {
                return NotFound();
            }

            return clienteModels;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModels(int id, ClienteModels clienteModels)
        {
            if (id != clienteModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelsExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteModels>> PostClienteModels(ClienteModels clienteModels)
        {
            _context.ClienteModels.Add(clienteModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteModels", new { id = clienteModels.Id }, clienteModels);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteModels(int id)
        {
            var clienteModels = await _context.ClienteModels.FindAsync(id);
            if (clienteModels == null)
            {
                return NotFound();
            }

            _context.ClienteModels.Remove(clienteModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteModelsExists(int id)
        {
            return _context.ClienteModels.Any(e => e.Id == id);
        }
    }
}

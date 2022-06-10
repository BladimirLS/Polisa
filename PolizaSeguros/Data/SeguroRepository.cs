using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolizaSeguros.Data.Entity;

namespace PolizaSeguros.Data
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly PolizaSeguroDbContext _context;

        public SeguroRepository(PolizaSeguroDbContext context)
        {
            _context = context;
        }
        private ISeguroRepository _seguroRepositoryImplementation;
        public void Add<T>(T entity) where T : class
        {
            _seguroRepositoryImplementation.Add(entity);
        }

        public async Task<IEnumerable<Cliente>> getAllCliente()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> getClienteById(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            var result = await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteClienteById(int id)
        {
            var result = await _context.Clientes.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _context.Clientes.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var result = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            if (result != null)
            {
                result.Name = cliente.Name;
                result.DNI = cliente.DNI;
                result.BirthDate = cliente.BirthDate;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Plan>> getAllPlan()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan> getPlanById(int id)
        {
            return await _context.Plans.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Plan> AddPlann(Plan plan)
        {
          var result = await _context.Plans.AddAsync(plan);
          await _context.SaveChangesAsync();
          return result.Entity;
        }

        public async void DeletePlann(int id)
        {
            var result = await _context.Plans.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _context.Plans.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            var result = await _context.Plans.FirstOrDefaultAsync(p => p.Id == plan.Id);
            if (result != null)
            {
                result.Name = plan.Name;
                result.Code = plan.Code;
                result.Dues = plan.Dues;
                result.MinAge = plan.MinAge;
                result.MaxAge = plan.MaxAge;

                await _context.SaveChangesAsync();

                return result;

            }

            return null;
        }


        public async Task<IEnumerable<Seguro>> getAllSeguro()
        {
            return await _context.Seguros.ToListAsync();
        }

        public async Task<Seguro> getSeguroById(int id)
        {
            return await _context.Seguros.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Seguro> AddSeguro(Seguro seguro)
        {
            var result = await _context.Seguros.AddAsync(seguro);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async void DeleteSeguro(int id)
        {
            var result = await _context.Seguros.FirstOrDefaultAsync(s => s.Id == id);
            if (result != null)
            {
                _context.Seguros.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Seguro> UpdateSeguro(Seguro seguro)
        {
            var result = await _context.Seguros.FirstOrDefaultAsync(s => s.Id == seguro.Id);
            if (result != null)
            {
                result.Code = seguro.Code;
                result.Name = seguro.Name;

                _context.SaveChangesAsync();

                return result;
            }

            return null;
            
        }
    }
}

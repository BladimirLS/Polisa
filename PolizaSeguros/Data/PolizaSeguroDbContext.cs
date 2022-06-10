using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PolizaSeguros.Data.Entity;
using PolizaSeguros.Models;

namespace PolizaSeguros.Data
{
    public class PolizaSeguroDbContext : DbContext
    {
        public IConfiguration _Configuration { get; set; }
        public PolizaSeguroDbContext(DbContextOptions options, IConfiguration Configuration) : base(options)
        {
            _Configuration = Configuration;
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Seguro> Seguros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Configuration.GetConnectionString("con"));
        }

        public DbSet<PolizaSeguros.Models.ClienteModels> ClienteModels { get; set; }

        public DbSet<PolizaSeguros.Models.PlanModels> PlanModels { get; set; }

        public DbSet<PolizaSeguros.Models.SeguroModels> SeguroModels { get; set; }
    }
}

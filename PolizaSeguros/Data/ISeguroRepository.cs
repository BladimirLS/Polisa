using System.Collections.Generic;
using System.Threading.Tasks;
using PolizaSeguros.Data.Entity;

namespace PolizaSeguros.Data
{
    public interface ISeguroRepository
    {
        void Add<T>(T entity) where T : class;

        Task<IEnumerable<Cliente>> getAllCliente();
        Task<Cliente> getClienteById(int id);
        Task<Cliente> AddCliente(Cliente cliente);
        void DeleteClienteById(int id);
        Task<Cliente> UpdateCliente(Cliente cliente);

        Task<IEnumerable<Plan>> getAllPlan();
        Task<Plan> getPlanById(int id);
        Task<Plan> AddPlann(Plan plan);
        void  DeletePlann(int id);
        Task<Plan> UpdatePlan(Plan plan);


        Task<IEnumerable<Seguro>> getAllSeguro();
        Task<Seguro> getSeguroById(int id);
        Task<Seguro> AddSeguro(Seguro seguro);
        void DeleteSeguro(int id);
        Task<Seguro> UpdateSeguro(Seguro seguro);
    }
}

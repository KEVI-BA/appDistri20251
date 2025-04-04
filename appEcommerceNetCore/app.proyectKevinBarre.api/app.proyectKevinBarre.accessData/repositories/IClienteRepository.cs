
using app.proyectKevinBarre.entities.Models;

namespace app.proyectKevinBarre.accessData.repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(int id);

        Task<Cliente> CreateCliente(Cliente entity);

        Task<List<Cliente>> GetClienteLista();

        Task UpdateCliente(Cliente entity);

        Task DeleteCliente(int id);
    }
}

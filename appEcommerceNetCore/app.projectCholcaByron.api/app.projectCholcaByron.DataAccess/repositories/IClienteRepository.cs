using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> InsertarEntidad(Cliente entity);

        Task EliminarEntidad(int id);

        Task<Cliente> ObtenerEntidad(int id);

        Task<List<Cliente>> ObtenerEntidadesLista();

        Task ActualizarEntidad(Cliente entity);
    }
}

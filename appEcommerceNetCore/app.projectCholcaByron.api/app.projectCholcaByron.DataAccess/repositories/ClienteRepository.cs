using app.projectCholcaByron.DataAccess.context;
using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public class ClienteRepository : CrudGenericService<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task ActualizarEntidad(Cliente entity)
        {
            await UpdateEntity(entity);
        }

        public async Task EliminarEntidad(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Cliente> InsertarEntidad(Cliente entity)
        {
            return await InsertEntity(entity);
        }

        public async Task<Cliente> ObtenerEntidad(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Cliente>> ObtenerEntidadesLista()
        {
            return await SelectEntitiesAll();
        }
    }
}

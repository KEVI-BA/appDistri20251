using app.projectCholcaByron.DataAccess.context;
using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public class ProductoRepository : CrudGenericService<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Producto> InsertarEntidad(Producto entity)
        {
            return await InsertEntity(entity);
        }

        public async Task EliminarEntidad(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Producto> ObtenerEntidad(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Producto>> ObtenerEntidadesLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task ActualizarEntidad(Producto entity)
        {
            await UpdateEntity(entity);
        }
    }
}

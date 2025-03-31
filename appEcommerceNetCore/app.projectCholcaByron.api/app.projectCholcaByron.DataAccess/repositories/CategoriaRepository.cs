using app.projectCholcaByron.DataAccess.context;
using app.projectCholcaByron.Entities.Models;

namespace app.projectCholcaByron.DataAccess.repositories
{
    public class CategoriaRepository : CrudGenericService<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Categoria> CreateCategoria(Categoria entity)
        {
            return await InsertEntity(entity);
        }

        public async Task DeleteCategoria(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Categoria>> GetCategoriaLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateCategoria(Categoria entity)
        {
            await UpdateEntity(entity);
        }
    }
}

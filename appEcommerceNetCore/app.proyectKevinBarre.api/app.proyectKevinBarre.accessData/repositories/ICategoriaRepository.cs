
using app.proyectKevinBarre.entities.Models;

namespace app.proyectKevinBarre.accessData.repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetCategoria(int id);

        Task<Categoria> CreateCategoria(Categoria entity);

        Task<List<Categoria>> GetCategoriaLista();

        Task UpdateCategoria(Categoria entity);

        Task DeleteCategoria(int id);
    }
}

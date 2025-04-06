using app.proyectKevinBarre.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.proyectKevinBarre.accessData.repositories
{
    public interface IVentaRepository
    {
        Task<Venta> GetCategoria(int id);

        Task<Venta> CreateCategoria(Venta entity);

        Task<List<Venta>> GetCategoriaLista();

        Task UpdateCategoria(Venta entity);

        Task DeleteCategoria(int id);
    }
}

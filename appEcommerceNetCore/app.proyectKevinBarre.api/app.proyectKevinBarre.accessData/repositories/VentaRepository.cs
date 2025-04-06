using app.proyectKevinBarre.accessData.Context;
using app.proyectKevinBarre.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.proyectKevinBarre.accessData.repositories
{
    public class VentaRepository : CrudGenericService<Venta>, IVentaRepository
    {
        public VentaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Venta> CreateCategoria(Venta entity)
        {
            return await InsertEntity(entity);
        }

        public  async Task DeleteCategoria(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Venta> GetCategoria(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Venta>> GetCategoriaLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateCategoria(Venta entity)
        {
            await UpdateCategoria(entity);
        }
    }
}

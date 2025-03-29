using app.projectCholcaByron.DataAccess.context;
using app.projectCholcaByron.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace app.projectCholcaByron.DataAccess
{
    public class CrudGenericService<TEntityBase> where TEntityBase : EntityBase
    {
        private readonly AppDbContext _context;

        public CrudGenericService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Insert(TEntityBase entity)
        {
            await _context.Set<TEntityBase>().AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<TEntityBase> Select(int id)
        {
            var entity = await _context.Set<TEntityBase>().SingleOrDefaultAsync(p => p.Id == id && p!.Estado);
            if (entity == null) return null!;
            return entity;
        }


        public async Task<ICollection<TEntityBase>> SelectAll()
        {
            var entities = await _context.Set<TEntityBase>().ToListAsync();
            if (entities == null) return null!;
            return entities;
        }


        public async Task UpdateEntity(TEntityBase entity)
        {
            _context.Set<TEntityBase>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<TEntityBase>().SingleOrDefaultAsync(p => p.Id == id);

            if (entity == null) return;

            _context.Set<TEntityBase>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

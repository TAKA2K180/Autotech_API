using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Autotech.Core.Models;
using Autotech.Core.Services;

namespace Autotech.BusinessLayer.Data.Services
{
    public class GenericDataService<T> : IDataService<T> where T : BaseModel
    {
        private readonly ApplicationDbContextFactory _dbContextFactory;
        public GenericDataService(ApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResults = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResults.Entity;
            };
        }

        public async Task<bool> Delete(Guid Id)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == Id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            };
        }

        public async Task<T> GetById(Guid Id)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == Id);
                return entity;
            };
        }

        public async Task<List<T>> GetAll()
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                List<T> entities = await context.Set<T>().Select(x => x).ToListAsync();
                return entities;
            };
        }

        public async Task<T> Update(T entity)
        {
            using (ApplicationDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            };
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using TheGamingCompany.Core;

namespace TheGamingCompany.Infrastructure.Database.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly TheGamingCompanyContext context;

        public BaseRepository(TheGamingCompanyContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await context.AddAsync(entity);
            return result.Entity;
        }

        public async Task<IReadOnlyList<TEntity>> AllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Delete(TEntity entity) => context.Remove(entity);

        public IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity? GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            var result = context.Update(entity);
            return result.Entity;
        }
    }
}


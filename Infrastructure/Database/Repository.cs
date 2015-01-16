using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : EntityBase, IAggregateRoot
        where TContext : DbContext
    {
        private readonly DbSet<TEntity> db;
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
            db = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            db.Add(entity);
            await CommitAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            var entry = context.Entry(entity);
            db.Attach(entity);
            entry.State = EntityState.Modified;
            await CommitAsync();
        }
        public async Task RemoveAsync(TEntity entity)
        {
            db.Remove(entity);
            await CommitAsync();
        }
        public async Task<TEntity> GetByKeyAsync(Guid key)
        {
            return await db.FindAsync(key);
        }
        private async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        } 

        public IQueryable<TEntity> Get()
        {
            return db;
        }
        public IQueryable<TEntity> ReadonlyGet()
        {
            return db.AsNoTracking();
        }
    }
}
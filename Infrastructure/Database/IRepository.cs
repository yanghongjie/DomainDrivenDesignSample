using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    /// <summary>
    /// 数据仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型.</typeparam>
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<TEntity> GetByKeyAsync(Guid key);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> ReadonlyGet();
    }
}
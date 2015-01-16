using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase<TKey> 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }
    /// <summary>
    /// 实体基类（GUID）
    /// </summary>
    public abstract class EntityBase :EntityBase<Guid>, IAggregateRoot
    {
    }
}
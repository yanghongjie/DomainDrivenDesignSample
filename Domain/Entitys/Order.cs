using System;
using Infrastructure.Database;
using ServiceStack;

namespace Domain.Entitys
{
    /// <summary>
    /// 订单实体类
    /// </summary>
    public partial class Order : EntityBase
    {
        public string OrderNo { get; set; }
        public decimal OrderAmount { get; set; }
        public DateTime OrderTime { get; set; }
        public string ProductNo { get; set; }
        public string UserIdentifier { get; set; }
        public bool IsPaid { get; set; }
    }
}
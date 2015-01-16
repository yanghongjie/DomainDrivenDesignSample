using System.Data.Entity;
using Domain.Entitys;

namespace Domain.DataBase
{
    public class SampleContext : DbContext
    {
        public SampleContext()
            : base("SampleContext")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<PayOrder> PayOrders { get; set; }
        public DbSet<EventStore> EventStores { get; set; }
    }
}
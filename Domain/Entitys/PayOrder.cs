using Infrastructure.Database;

namespace Domain.Entitys
{
    public partial class PayOrder : EntityBase
    {
        public decimal PayAmount { get; set; }
        public string PayResult { get; set; }
        public string OrderNo { get; set; }
    }
}
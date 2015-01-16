using Domain.Events;

namespace Domain.Entitys
{
    public partial class PayOrder
    {
        public PaySuccessReady ToPaySuccessReadyEvent()
        {
            return new PaySuccessReady
            {
                Entity = this
            };
        }
    }
}
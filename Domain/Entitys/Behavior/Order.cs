using Domain.Events;

namespace Domain.Entitys
{
    public partial class Order
    {
        public BuildOrderReady ToBuildOrderReadyEvent()
        {
            return new BuildOrderReady
            {
                Entity = this
            };
        }
    }
}
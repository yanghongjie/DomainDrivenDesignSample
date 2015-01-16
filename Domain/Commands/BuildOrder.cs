using System;
using Domain.Entitys;
using Infrastructure.Commands;
using ServiceStack;

namespace Domain.Commands
{
     [Route("/BuildOrder", "Post")]
    public class BuildOrder : Command
    {
        public string OrderNo { get; set; }
        public decimal OrderAmount { get; set; }
        public string ProductNo { get; set; }
        public string UserIdentifier { get; set; }

        public Order ToOrder()
        {
            return new Order
            {
                OrderNo = OrderNo,
                OrderAmount = OrderAmount,
                OrderTime = DateTime.Now,
                ProductNo = ProductNo,
                UserIdentifier = UserIdentifier,
                IsPaid = false
            };
        }
    }
}
using System;
using Domain.Commands;
using Infrastructure.Bus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void BuildOrder()
        {
            var commandBus = new CommandBus();
            var orderCommand = new BuildOrder
            {
                OrderNo = "ON1001",
                OrderAmount = 10000,
                ProductNo = "PN1001",
                UserIdentifier = "UID1001"
            };
            var result = commandBus.Excute(orderCommand);
            Assert.IsTrue(result.Result);
        }
    }
}

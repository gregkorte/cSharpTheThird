using System;
using System.Collections.Generic;
using Xunit;

namespace cli.tests
{
    public class OrderShould
    {
        private Order _order;
        private OrderManager manager = new OrderManager();
        public OrderShould()
        {
            _order = new Order(
                1, 
                1,
                null
            );
        }

        [Fact]
        public void AddPropertiesToOrderInstance()
        {
            Assert.Equal(1, _order.OrderId);
            Assert.Equal(1, _order.CustomerId);
        }

        [Fact]
        public void GetSingleOrder()
        {
            manager.Add(_order);
            Order order = manager.GetSingleOrder(1);

            Assert.Equal(_order, order);
        }
    }
}
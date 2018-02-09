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

        [Fact]
        public void GetAllOrders()
        {
            manager.Add(_order);
            List<Order> allOrders = manager.GetAllOrders();

            Assert.Contains(_order, allOrders);
        }

        [Fact]
        public void AddPaymentTypeToOrder()
        {
            manager.Add(_order);
            manager.CompleteOrder(1, 3);
            Order order = manager.GetSingleOrder(1);

            Assert.Equal(3, order.PaymentTypeId);
        }
    }
}
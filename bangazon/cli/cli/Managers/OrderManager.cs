using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class OrderManager
    {
        private List<Order> _ordersTable = new List<Order>();

        public void Add(Order order)
        {
            _ordersTable.Add(order);
        }

        public Order GetSingleOrder(int id)
        {
            return _ordersTable.Where(o => o.OrderId == id).Single();
        }

        public List<Order> GetAllOrders()
        {
            return _ordersTable;
        }

        public void CompleteOrder(int id, int paymentTypeId)
        {
            Order order = _ordersTable.Where(o => o.OrderId == id).Single();
            order.PaymentTypeId = paymentTypeId;
        }
    }
}
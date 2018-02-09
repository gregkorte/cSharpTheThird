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
    }
}
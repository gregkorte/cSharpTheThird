using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class CustomerManager
    {
        private List<Customer> _customerTable = new List<Customer>();
        private Customer _activeCustomer;

        public void Add(Customer customer)
        {
            _customerTable.Add(customer);
        }

        public Customer GetSingleCustomer(int id)
        {
            Customer customer = _customerTable.Where(c => c.CustomerId == id).Single();
            // activeCustomer = customer;
            return customer;
        }
        
        public List<Customer> GetAllCustomers()
        {
            return _customerTable;
        }

        public Customer GetActiveCustomer(Customer customer)
        {
            _activeCustomer = customer;
            return _activeCustomer;
        }
    }
}
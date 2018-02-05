using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class CustomerManager
    {
        private List<Customer> _customerTable = new List<Customer>();

        public void Add(Customer customer)
        {
            _customerTable.Add(customer);
        }

        public Customer GetSingleCustomer(int id)
        {
            return _customerTable.Where(c => c.CustomerId == id).Single();
        }
        
        public List<Customer> GetAllCustomers()
        {
            return _customerTable;
        }
    }
}
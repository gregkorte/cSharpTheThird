using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class CustomerManager
    {
        private DatabaseInterface _db;
        private List<Customer> _customerTable = new List<Customer>();
        private Customer _activeCustomer;

        public CustomerManager(DatabaseInterface db)
        {
            _db = db;
        }

        public int Add(Customer customer)
        {
            _customerTable.Add(customer);
            int id = _db.Insert($"insert into customer values (null, '{customer.FirstName}', '{customer.LastName}', '{customer.StreetAddress}', '{customer.City}', '{customer.ZipCode}', '{customer.PhoneNumber}')");

            return id;
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
using System;
using System.Collections.Generic;
using Xunit;


namespace cli.tests
{
    public class CustomerShould : IDisposable
    {
        private Customer _customer;
        private CustomerManager _manager;
        private DatabaseInterface _db;

        public CustomerShould()
        {
            _db = new DatabaseInterface("CLI_TEST_DB");
            _manager = new CustomerManager(_db);
            _db.CheckCustomerTable();

            _customer = new Customer(
                "Jimminy",
                "Cricket",
                "345 Pinnoc Ln",
                "Somewhere",
                "Shomehow",
                "98765",
                "123-456-7890"
            );
        }

        [Fact]
        public void AddPropertiesToCustomerInstance()
        {
            _manager.Add(_customer);
            Assert.Equal(_customer.PhoneNumber, "123-456-7890");
        }

        [Fact]
        public void GetSingleCustomer()
        {
            _manager.Add(_customer);

            Customer customer = _manager.GetSingleCustomer(1);

            Assert.Equal(customer.CustomerId 
            , 1);
        }

        [Fact]
        public void GetAllCustomers()
        {
            _manager.Add(_customer);

            List<Customer> allCustomers = _manager.GetAllCustomers();

            Assert.Contains(_customer, allCustomers);
        }

        [Fact]
        public void SelectActiveCustomer()
        {
            _manager.Add(_customer);
            Customer customer = _manager.GetSingleCustomer(1);
            Customer activeCustomer = _manager.GetActiveCustomer(customer);

            Assert.Equal(_customer, activeCustomer);
        }

        public void Dispose()
        {
            _manager.Delete($"delete from customer");
        }
    }
}
using System;
using System.Collections.Generic;
using Xunit;

namespace cli.tests
{
    public class CustomerCreateShould
    {
        private Customer _customer;

        public CustomerCreateShould()
        {
            _customer = new Customer(
                1,
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
            Assert.Equal(_customer.PhoneNumber, "123-456-7890");
        }

        [Fact]
        public void GetSingleCustomer()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);

            Customer customer = manager.GetSingleCustomer(1);

            Assert.Equal(customer.CustomerId 
            , 1);
        }

        [Fact]
        public void GetAllCustomers()
        {
            CustomerManager manager = new CustomerManager();
            manager.Add(_customer);

            List<Customer> allCustomers = manager.GetAllCustomers();

            Assert.Contains(_customer, allCustomers);
        }
    }
}

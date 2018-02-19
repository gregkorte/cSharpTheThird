using System;
using System.Collections.Generic;
using Xunit;


namespace cli.tests
{
    public class PaymentTypeShould : IDisposable
    {
        private PaymentType _paymentType = new PaymentType();
        private Customer _customer = new Customer();
        private PaymentTypeManager _manager;
        private CustomerManager _cm;
        private DatabaseInterface _db;

        public PaymentTypeShould()
        {
            _db = new DatabaseInterface("CLI_TEST_DB");
            _cm = new CustomerManager(_db);
            _manager = new PaymentTypeManager(_db);
            _db.CheckCustomerTable();
            _db.CheckPaymentTypeTable();

            _paymentType.Name = "Visa";
            _paymentType.AccountNumber = "1234567890";

            _customer.FirstName = "Jimminy";
            _customer.LastName = "Cricket";
            _customer.StreetAddress = "345 Pinnoc Ln";
            _customer.City = "Somewhere";
            _customer.State = "Shomehow";
            _customer.ZipCode = "98765";
            _customer.PhoneNumber = "123-456-7890";

        }

        [Fact]
        public void AddPropertiesToPaymentTypeInstance()
        {
            _cm.Add(_customer);
            _cm.GetSingleCustomer(1);
            int id = _manager.Add(_paymentType);

            Assert.Equal("Visa", _paymentType.Name);
        }

        [Fact]
        public void AddActiveCustomerToPaymentType()
        {
            _cm.Add(_customer);
            _cm.GetSingleCustomer(1);
            _manager.Add(_paymentType);

            PaymentType paymentType = _manager.GetSinglePaymentType(1);

            Assert.Equal(1, paymentType.CustomerId 
            );
        }

        [Fact]
        public void GetSinglePaymentType()
        {
            _cm.Add(_customer);
            _cm.GetSingleCustomer(1);
            _manager.Add(_paymentType);

            PaymentType paymentType = _manager.GetSinglePaymentType(1);

            Assert.Equal(1, paymentType.PaymentTypeId 
            );
        }

        [Fact]
        public void GetAllPaymentTypesForCustomer()
        {
            _cm.Add(_customer);
            _cm.GetSingleCustomer(1);
            _manager.Add(_paymentType);
            var pt = _manager.GetSinglePaymentType(1);

            List<PaymentType> allPaymentTypes = _manager.GetAllPaymentTypes();

            Assert.
        }

        public void Dispose()
        {
            _db.Delete($"delete from paymentTypes");
            _db.Delete($"delete from sqlite_sequence where name='paymentTypes'");
            _db.Delete($"delete from customers");
            _db.Delete($"delete from sqlite_sequence where name='customers'");
        }
    }
}

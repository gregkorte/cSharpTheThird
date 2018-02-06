using System;
using System.Collections.Generic;
using Xunit;


namespace cli.tests
{
    public class PaymentTypeShould
    {
        private PaymentType _paymentType;

        public PaymentTypeShould()
        {
            _paymentType = new PaymentType(
                1,
                "Visa",
                "1234567890",
                1
            );
        }

        [Fact]
        public void AddPropertiesToPaymentTypeInstance()
        {
            PaymentTypeManager manager = new PaymentTypeManager();
            manager.Add(_paymentType);

            Assert.Equal(_paymentType.AccountNumber, "1234567890");
        }

        [Fact]
        public void GetSinglePaymentType()
        {
            PaymentTypeManager manager = new PaymentTypeManager();
            manager.Add(_paymentType);

            PaymentType paymentType = manager.GetSinglePaymentType(1);

            Assert.Equal(paymentType.PaymentTypeId 
            , 1);
        }

        [Fact]
        public void GetAllPaymentTypes()
        {
            PaymentTypeManager manager = new PaymentTypeManager();
            manager.Add(_paymentType);

            List<PaymentType> allPaymentTypes = manager.GetAllPaymentTypes();

            Assert.Contains(_paymentType, allPaymentTypes);
        }
    }
}

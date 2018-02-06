using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _paymentTypeTable = new List<PaymentType>();
        
        public void Add(PaymentType pt)
        {
            _paymentTypeTable.Add(pt);
        }

        public PaymentType GetSinglePaymentType(int id)
        {
            return _paymentTypeTable.Where(pt => pt.PaymentTypeId == id).Single();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _paymentTypeTable;
        }
    }
}
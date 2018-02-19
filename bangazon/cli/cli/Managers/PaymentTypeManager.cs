using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace cli
{
    public class PaymentTypeManager
    {
        private DatabaseInterface _db;
        private List<PaymentType> _paymentTypeTable = new List<PaymentType>();
        private CustomerManager _cm;

        public PaymentTypeManager(DatabaseInterface db)
        {
            _db = db;
            _cm = new CustomerManager(db);
        }
        
        public int Add(PaymentType pt)
        {
            // _paymentTypeTable.Add(pt);
            Customer customer = _cm.GetActiveCustomer();
            int id = _db.Insert($"insert into paymentTypes values(null, '{pt.Name}', '{pt.AccountNumber}', {customer.CustomerId})"); 
            return id;
        }

        public PaymentType GetSinglePaymentType(int id)
        {
            PaymentType pt = new PaymentType();
            _db.Query($"select * from paymentTypes where PaymentTypeId == {id}", 
                (SqliteDataReader reader) =>  {
                    while(reader.Read())
                    {
                        pt.PaymentTypeId = reader.GetInt32(0);
                        pt.Name = reader["Name"].ToString();
                        pt.AccountNumber = reader["AccountNumber"].ToString();
                        pt.CustomerId = reader.GetInt32(3);
                    }
                }
            );
            return pt;
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            // get the active customer
            int id = _cm.GetActiveCustomer().CustomerId;
            // filter payment types to a list
            _db.Query($"select * from paymentTypes where CustomerId == {id}",
                (SqliteDataReader reader) => {
                    while(reader.Read())
                    {
                        _paymentTypeTable.Add(new PaymentType(){
                            PaymentTypeId = reader.GetInt32(0),
                            Name = reader["Name"].ToString(),
                            AccountNumber = reader["AccountNumber"].ToString(),
                            CustomerId = reader.GetInt32(3)
                            }
                        );
                    }
                }
            );
            return _paymentTypeTable;
        }
    }
}
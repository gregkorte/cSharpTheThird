using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

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
            Customer c = new Customer();
            _db.Query($"SELECT * FROM customer WHERE CustomerId == {id}",
                (SqliteDataReader reader) => {
                    while(reader.Read())
                    {
                        c.CustomerId = reader.GetInt32(0);
                        c.FirstName = reader["FirstName"].ToString();
                        c.LastName = reader["LastName"].ToString();
                        c.StreetAddress = reader[3].ToString();
                        c.City = reader["City"].ToString();
                        c.State = reader[5].ToString();
                        c.ZipCode = reader["ZipCode"].ToString();
                        c.PhoneNumber = reader["PhoneNumber"].ToString();
                    }
                }
            );
            _activeCustomer = c;
            return c;
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
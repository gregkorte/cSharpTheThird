using System;
using Microsoft.Data.Sqlite;

namespace cli
{
    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface(string db)
        {
            string env = $"{Environment.GetEnvironmentVariable(db)}";
            _connectionString = $"Data Source={env}";
            _connection = new SqliteConnection(_connectionString);
        }

        public void Delete(string command)
        {
            using(_connection)
            using(SqliteCommand dbcmd = _connection.CreateCommand())
            {
                _connection.Open();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using(_connection)
            using(SqliteCommand dbcmd = _connection.CreateCommand())
            {
                _connection.Open();
                dbcmd.CommandText = command;

                using(SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler(dataReader);
                }
                _connection.Close();
            }
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using(_connection)
            using(SqliteCommand dbcmd = _connection.CreateCommand())
            {
                _connection.Open();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery();
                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while(reader.Read())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );
                _connection.Close();
            }
            return insertedItemId;
        }

        public void CheckCustomerTable()
        {
            using(_connection)

            using(SqliteCommand dbcmd = _connection.CreateCommand())
            {
                _connection.Open();
                dbcmd.CommandText = $"select CustomerId from customer";

                try
                {
                    using(SqliteDataReader reader = dbcmd.ExecuteReader())
                    {

                    }
                }
                catch(Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if(ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table customer (
                            `CustomerId`        integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `FirstName`         varchar(80) not null,
                            `LastName`          varchar(80) not null,
                            `StreetAddress `    varchar(160) not null,
                            `City`              varchar(80) not null,
                            `ZipCode`           varchar(5) not null,
                            `PhoneNumber`       varchar(20) not null
                        )";
                        dbcmd.ExecuteNonQuery();
                    }                    
                }
                _connection.Close();
            }
        }

    }
}
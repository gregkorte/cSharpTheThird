using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<string> _children = new List<string>();
        private string _connectionString = $"Data Source = {Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ChildRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AddChildren(string child)
        {
            int _lastId = 0;
            using(_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Insert the new child
                dbcmd.CommandText = $"insert into child values (null, '{child}', 0)";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery();
                
                // Get id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using(SqliteDataReader reader = dbcmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        _lastId = reader.GetInt32(0);
                    } else{
                        throw new Exception("Unable to insert value");
                    }
                }
                // Clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            return _lastId != 0;
        }

        public List<string> GetChildren()
        {
            return new List<string>();
        }

        public string GetChild(string name)
        {
            var child = _children.SingleOrDefault(c => c == name);

            // Inevitable two children will have the same name. Then what?

            return child;
        }
    }
}
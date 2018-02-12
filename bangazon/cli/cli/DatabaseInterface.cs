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

        internal void Check()
        {
            throw new NotImplementedException();
        }
    }
}
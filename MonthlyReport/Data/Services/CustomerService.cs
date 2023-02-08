using MonthlyReport.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyReport.Data.Services
{
    public class CustomerService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public CustomerService(string dbPath)
        {
            _dbPath = dbPath;
        }
        private async Task InitAsync()
        {
            if (conn != null) return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Customer>();
        }

    }
}

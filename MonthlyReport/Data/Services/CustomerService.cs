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
        public async Task<List<Customer>> GetCustomerAsync(int id)
        {
            await InitAsync();
            if(id > 0) return new List<Customer>() { await conn.GetAsync<Customer>(id) };
            return await conn.Table<Customer>().ToListAsync();
        }
        public async Task<Customer> CreateUpdateCustomerAsync(Customer customer)
        {
            if(customer.Id <= 0) await conn.InsertAsync(customer);
            else await conn.UpdateAsync(customer);
            return customer;
        }
        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            await conn.DeleteAsync(customer);
            return customer;
        }

    }
}

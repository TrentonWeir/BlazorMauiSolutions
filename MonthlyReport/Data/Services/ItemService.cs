using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthlyReport.Data.Models;
using SQLite;

namespace MonthlyReport.Data.Services
{
    public class ItemService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ItemService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (conn != null) return; 
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Item>();
        }
        public async Task<List<Item>> GetItemAsync(int id = 0)
        {
            await InitAsync();
            if (id > 0) return new List<Item>() { await conn.GetAsync<Item>(id) };
            return await conn.Table<Item>().ToListAsync();
        }
        public async Task<Item> CreateUpdateItemAsync(Item Item)
        {
            Item.CreateDate = DateTime.Now.ToShortDateString();
            if (Item.Id <= 0) await conn.InsertAsync(Item);
            else await conn.UpdateAsync(Item);
            return Item;
        }
        public async Task<Item> DeleteItem(Item Item)
        {
            await conn.DeleteAsync(Item);
            return Item;
        }

    }
}

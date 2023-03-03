using SQLite;
using DailyTasks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updates.Data.Services
{
    public class UpdateService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public UpdateService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (conn != null) return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Update>();
        }
        public async Task<List<Update>> GetUpdateAsync(int id = 0)
        {
            await InitAsync();
            if (id > 0) return new List<Update>() { await conn.GetAsync<Update>(id) };
            return await conn.Table<Update>().ToListAsync();
        }
        public async Task<Update> CreateUpdateUpdateAsync(Update Update)
        {
            Update.Date = DateTime.Now;
            if (Update.Id <= 0) await conn.InsertAsync(Update);
            else await conn.UpdateAsync(Update);
            return Update;
        }
        public async Task<Update> DeleteUpdate(Update Update)
        {
            await conn.DeleteAsync(Update);
            return Update;
        }
    }
}

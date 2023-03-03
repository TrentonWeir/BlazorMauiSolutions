using SQLite;
using DailyTasks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks.Data.Services
{
    internal class DailyTaskService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public DailyTaskService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (conn != null) return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<DailyTask>();
        }
        public async Task<List<DailyTask>> GetDailyTaskAsync(int id = 0)
        {
            await InitAsync();
            if (id > 0) return new List<DailyTask>() { await conn.GetAsync<DailyTask>(id) };
            return await conn.Table<DailyTask>().ToListAsync();
        }
        public async Task<DailyTask> CreateUpdateDailyTaskAsync(DailyTask DailyTask)
        {
            if (await isConnNULL()) await InitAsync();
            if (DailyTask.Id <= 0) await conn.InsertAsync(DailyTask);
            else await conn.UpdateAsync(DailyTask);
            return DailyTask;
        }
        public async Task<DailyTask> DeleteDailyTask(DailyTask DailyTask)
        {
            if (await isConnNULL()) await InitAsync();
            await conn.DeleteAsync(DailyTask);
            return DailyTask;
        }
        public async Task<bool>isConnNULL() => (conn == null);
    }
}



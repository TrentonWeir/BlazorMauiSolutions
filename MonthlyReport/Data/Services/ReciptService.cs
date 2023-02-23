using SQLite;
using MonthlyReport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyReport.Data.Services
{
    public class ReciptService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ReciptService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (conn != null) return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Recipt>();
        }
        public async Task<List<Recipt>> GetReciptAsync(int id = 0)
        {
            await InitAsync();
            if (id > 0) return new List<Recipt>() { await conn.GetAsync<Recipt>(id) };
            return await conn.Table<Recipt>().ToListAsync();
        }
        public async Task<Recipt> CreateUpdateReciptAsync(Recipt Recipt)
        {
            Recipt.AddedDate = DateTime.Now;
            if (Recipt.Id <= 0) await conn.InsertAsync(Recipt);
            else await conn.UpdateAsync(Recipt);
            return Recipt;
        }
        public async Task<Recipt> DeleteRecipt(Recipt Recipt)
        {
            await conn.DeleteAsync(Recipt);
            return Recipt;
        }
    }
}

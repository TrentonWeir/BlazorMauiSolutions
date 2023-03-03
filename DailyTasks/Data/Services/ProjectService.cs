using DailyTasks.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Data.Services
{
    public class ProjectService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ProjectService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (conn != null) return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Project>();
        }
        public async Task<List<Project>> GetProjectAsync(int id = 0)
        {
            await InitAsync();
            if (id > 0) return new List<Project>() { await conn.GetAsync<Project>(id) };
            return await conn.Table<Project>().ToListAsync();
        }
        public async Task<Project> CreateUpdateProjectAsync(Project Project)
        {
            Project.Date = DateTime.Now;
            if (Project.Id <= 0) await conn.InsertAsync(Project);
            else await conn.UpdateAsync(Project);
            return Project;
        }
        public async Task<Project> DeleteProject(Project Project)
        {
            await conn.DeleteAsync(Project);
            return Project;
        }
    }
}

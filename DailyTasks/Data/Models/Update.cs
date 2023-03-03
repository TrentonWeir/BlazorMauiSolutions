using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks.Data.Models
{
    public class Update
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public int ProjectId { get; set; }
        [MaxLength(300)] public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}

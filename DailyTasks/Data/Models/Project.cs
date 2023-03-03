using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks.Data.Models
{
    public class Project
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [MaxLength(300)] public string Title { get; set; }
        [MaxLength(300)] public string Description { get; set; }
        [MaxLength(300)] public string Status { get; set; }
        [MaxLength(300)] public string Threats { get; set; }
        public DateTime Date { get; set; }
    }
}

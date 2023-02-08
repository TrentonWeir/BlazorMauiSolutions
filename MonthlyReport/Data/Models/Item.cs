using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyReport.Data.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public DateTime Updated { get; set; }
        public string SerialNumber { get; set; }
    }
}

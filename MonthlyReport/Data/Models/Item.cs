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
        public int ReciptId { get; set; }
        [MaxLength(150)] public string Name { get; set; }
        [MaxLength(300)] public string Description { get; set; }
        public string CreateDate { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public DateTime Updated { get; set; }
        [MaxLength(150)] public string SerialNumber { get; set; }
    }
}

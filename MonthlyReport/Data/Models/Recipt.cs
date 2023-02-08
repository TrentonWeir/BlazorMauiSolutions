using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyReport.Data.Models
{
    public class Recipt
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public List<Item> Items { get; set; }
        public int CustomerNumber { get; set; }
        public float Total { get; set; }
        public float Paid { get; set; }
        public DateTime PaidDate { get; set; }
        [MaxLength(4000)] public string Summary { get; set; }
    }
}

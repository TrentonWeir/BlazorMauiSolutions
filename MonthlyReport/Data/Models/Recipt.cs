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
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public float Total { get; set; }
        [MaxLength(4000)] public string Summary { get; set; }
    }
}

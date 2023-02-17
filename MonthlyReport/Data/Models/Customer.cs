using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyReport.Data.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]  public int Id { get; set; }
        [MaxLength(100)]public string FistName { get; set; }
        [MaxLength(100)] public string LastName { get; set; }
        [MaxLength(350)] public string Address { get; set; }
        [MaxLength(100)] public string PhoneNumber { get; set; }
    }
}

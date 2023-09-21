using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHang.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

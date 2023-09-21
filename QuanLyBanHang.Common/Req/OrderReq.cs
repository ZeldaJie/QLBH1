using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Common.Req
{
    public class OrderReq
    {
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }
        public string ShipAddress { get; set; }
        public int ShipVia { get; set; }
        public List<OrderDetailReq> orderDetailsList { get; set; }
    
    }

}

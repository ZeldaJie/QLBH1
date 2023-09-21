using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Common.Req
{
    public class OrderDetailReq
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; } 
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}

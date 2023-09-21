﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHang.DAL.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Product Product { get; set; }
    }
}

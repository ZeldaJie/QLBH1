﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyBanHang.DAL.Models
{
    public partial class User
    {
        

        public int UserID { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        
        
    }
}

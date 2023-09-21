using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Common.Req
{
 public class SearchProductReq
    {
        public String KeyWork { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

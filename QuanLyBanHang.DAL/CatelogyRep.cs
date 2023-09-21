using QuanLyBanHang.Common.DAL;
using QuanLyBanHang.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public class CategoryRep : GenericRep<QuanLyBanHang14Context, Category>
    {
        #region -- Overrides --

       
        public override Category Read(int id)
        {
            return base.Read(id);
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        #endregion

        #region -- Methods --


        #endregion
    }
}

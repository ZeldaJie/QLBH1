using QuanLyBanHang.Common.DAL;
using QuanLyBanHang.Common.Rsp;
using QuanLyBanHang.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public class UserRep : GenericRep<QuanLyBanHang14Context, User >
    {
        #region -- Overrides --
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(p => p.UserID == id);
            return res;
        }
        #endregion

        #region --  Method --
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();


            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                    var p = context.Users.Add(user);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetData("200", user);
                    }
                    catch (Exception ex)
                    {
                       tran.Rollback();
                     res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        #endregion

        public SingleRsp Login(string email, string password)
        {
            var res = new SingleRsp();
            var user = All.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(user != null) {
                res.SetData("200", user);
                res.SetMessage("Bạn đã đăng nhập thành công!");
            } else {
                res.SetError("Email hoặc password không đúng!");
            }
            
            return res;
        }
    }
}

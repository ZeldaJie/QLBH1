using QuanLyBanHang.Common.BLL;
using QuanLyBanHang.DAL.Models;
using QuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;

namespace QuanLyBanHang.BLL
{
    public class UserSvc : GenericSvc<UserRep, User >
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }
        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserID = userReq.UserID;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            user.Phone = userReq.Phone;
            res = userRep.CreateUser(user);
            return res;
        }
        public SingleRsp LoginUser(UserLoginReq userLoginReq)
        {
            var res = new SingleRsp();
            res = userRep.Login(userLoginReq.Email, userLoginReq.Password);
            return res;
        }
    }
}

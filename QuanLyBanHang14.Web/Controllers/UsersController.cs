using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.BLL;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;

namespace QuanLyBanHang14.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserSvc userSvc;
        public UsersController()
        {
            userSvc = new UserSvc();
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }
        [HttpPost("login-user")]
        public IActionResult LoginUser([FromBody] UserLoginReq userLoginReq)
        {
            var res = new SingleRsp();
            res = userSvc.LoginUser(userLoginReq);
            return Ok(res);
        }
    }
   
}

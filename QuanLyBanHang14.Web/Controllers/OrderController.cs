using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.BLL;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;
using QuanLyBanHang.DAL.Models;

namespace QuanLyBanHang14.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControllers : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderControllers()
        {
           orderSvc = new OrderSvc();
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.CreateOrder(orderReq);
            return Ok(res);
        }
        [HttpPut("edit-order")]
        public IActionResult EditOrder([FromBody] OrderReq orderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.EditOrder(orderReq);
            return Ok(res);
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.BLL;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;

namespace QuanLyBanHang.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(productReq);
            return Ok(res);
        }
        [HttpPut("edit-product")]
        public IActionResult EditProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.EditProduct(productReq);
            return Ok(res);
        }
        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res.Data = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }
    }
}

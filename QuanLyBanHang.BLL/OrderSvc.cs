using QuanLyBanHang.Common.BLL;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep orderRep;
        public OrderSvc() {
            orderRep = new OrderRep();
        }
        public SingleRsp CreateOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.CustomerId= orderReq.CustomerId;
            order.EmployeeId = orderReq.EmployeeId;
            order.OrderDate = orderReq.OrderDate;
            order.RequiredDate = orderReq.RequiredDate;
            order.Freight = orderReq.Freight;
            order.ShippedDate = orderReq.ShippedDate;
            order.ShipVia = orderReq.ShipVia;
            order.ShipAddress = orderReq.ShipAddress;

             var orderDetails = new List<OrderDetail>();
             foreach (var detail in orderReq.orderDetailsList)
              {
               var orderDetail = new OrderDetail
             {
               ProductId = detail.ProductId,
             UnitPrice = detail.UnitPrice,
              Quantity = detail.Quantity,
              Discount = detail.Discount
             };

             orderDetails.Add(orderDetail);
             
            }
            res = orderRep.CreateOrder(order, orderDetails);
            return res;
        }
        public SingleRsp EditOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.CustomerId = orderReq.CustomerId;
            order.EmployeeId = orderReq.EmployeeId;
            order.OrderDate = orderReq.OrderDate;
            order.RequiredDate = orderReq.RequiredDate;
            order.Freight = orderReq.Freight;
            order.ShippedDate = orderReq.ShippedDate;
            order.ShipVia = orderReq.ShipVia;
            order.ShipAddress = orderReq.ShipAddress;

            var orderDetails = new List<OrderDetail>();
            foreach (var detail in orderReq.orderDetailsList)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = detail.ProductId,
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    Discount = detail.Discount
                };

                orderDetails.Add(orderDetail);

            }
            res = orderRep.EditOrder(order, orderDetails);
            return res;
        }

    }
}

using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Common.DAL;
using QuanLyBanHang.Common.Req;
using QuanLyBanHang.Common.Rsp;
using QuanLyBanHang.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public class OrderRep : GenericRep<QuanLyBanHang14Context, Order>
    {
        #region -- Overrides --
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }
        #endregion
        #region --  Method --
        
        public SingleRsp CreateOrder(Order order, List<OrderDetail> details)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                    var p = context.Orders.Add(order);
                    context.SaveChanges();
                    foreach (var detail in details)
                    {
                        detail.OrderId = order.OrderId;
                        var od = context.OrderDetails.Add(detail);
                    }
                    context.SaveChanges();
                    tran.Commit();
                    res.SetData("200", order);
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

        public SingleRsp EditOrder(Order order, List<OrderDetail> details)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {

                    // Update Order
                    var p = context.Orders.Update(order);
                    context.SaveChanges();
                    
                    

                    // Insert Order Details
                    foreach (var detail in details)
                    {
                        detail.OrderId = order.OrderId;
                        var od = context.OrderDetails.Add(detail);
                    }
                    context.SaveChanges();
                    tran.Commit();
                    res.SetData("200", order);
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
    }
}

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
 public class ProductRep : GenericRep<QuanLyBanHang14Context, Product>
    {
        #region -- Overrides --


        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }


        public int Delete(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        public int Edit(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }

        #endregion
        #region --  Method --
        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
                        context.SaveChanges();
                        tran.Commit();
                    res.SetData("200", product);
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
        public SingleRsp DeleteProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                    var p = context.Products.Remove(product);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetData("200", product);
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
        public SingleRsp EditProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyBanHang14Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                    var p = context.Products.Update(product);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetData("200", product);
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
        public List<Product> SearchProduct(string keyWork)
        {
            return All.Where(x => x.ProductName.Contains(keyWork)).ToList();
         
        }
        #endregion
    }
}

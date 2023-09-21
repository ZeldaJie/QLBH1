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
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        public ProductSvc() {
            productRep = new ProductRep();
        }
        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.SupplierId = productReq.SupplierId;
            product.CategoryId = productReq.CategoryId;
            product.QuantityPerUnit = productReq.QuantityPerUnit;
            product.UnitsOnOrder = productReq.UnitsOnOrder;
            product.ReorderLevel = productReq.ReorderLevel;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;
        }
        public SingleRsp DeleteProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.SupplierId = productReq.SupplierId;
            product.CategoryId = productReq.CategoryId;
            product.QuantityPerUnit = productReq.QuantityPerUnit;
            product.UnitsOnOrder = productReq.UnitsOnOrder;
            product.ReorderLevel = productReq.ReorderLevel;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.DeleteProduct(product);
            return res;
        }
        public SingleRsp EditProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.SupplierId = productReq.SupplierId;
            product.CategoryId = productReq.CategoryId;
            product.QuantityPerUnit = productReq.QuantityPerUnit;
            product.UnitsOnOrder = productReq.UnitsOnOrder;
            product.ReorderLevel = productReq.ReorderLevel;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.EditProduct(product);
            return res;
        }
        public SingleRsp SearchProduct(SearchProductReq s)
        {
            var res = new SingleRsp();
            var products = productRep.SearchProduct(s.KeyWork);
            //
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page-1);
            pCount = products.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size :1 + (pCount / s.Size);
            var p = new
            {
                Data = products.Skip(offset).Take(totalPages).ToList(),
                Page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }
 } }

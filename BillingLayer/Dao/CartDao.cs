using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Common;
using BillingLayer.Model;
using System.Configuration;

namespace BillingLayer.Dao
{
    public class CartDao
    {
        BillingAppDBEntities db = new BillingAppDBEntities();

        public List<Cart> GetCarts(int retailerId)
        {
            List<Cart> lstcarts;
            try
            {
                lstcarts = (from x in db.CARTs.Where(o => o.RETAIL_ID == retailerId)
                            let sgst = (x.PRODUCT.SGST != null && x.PRODUCT.SGST.Value > 0) ? x.PRODUCT.SGST.Value : 0
                            let cgst = (x.PRODUCT.CGST != null && x.PRODUCT.CGST.Value > 0) ? x.PRODUCT.CGST.Value : 0
                            select new Cart
                            {
                                CartId = x.ID,
                                ProductId = x.ITEM_ID,
                                RetailerId = x.RETAIL_ID,
                                UserId =  x.USER_ID.Value,
                                Quantity = x.QUANTITY,
                                ProductName = x.PRODUCT.NAME,
                                Price = x.PRODUCT.SELLING_PRICE.Value,
                                CGST = ((x.PRODUCT.SELLING_PRICE.Value) * (cgst) / 100)* x.QUANTITY,
                                SGST = ((x.PRODUCT.SELLING_PRICE.Value) * (sgst) / 100)* x.QUANTITY,
                                CGSTPercentage=cgst,
                                SGSTPercentage=sgst,
                                TaxAmount = ((x.PRODUCT.SELLING_PRICE.Value) * (sgst + cgst) / 100)* x.QUANTITY,
                                TotalPrice = (((x.PRODUCT.SELLING_PRICE.Value) * (sgst + cgst) / 100) + x.PRODUCT.SELLING_PRICE.Value)* x.QUANTITY
                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstcarts;
        }

        public int AddCart(Cart objcart)
        {
            int addC = 0;
            try
            {
                CART dbcart = new CART();
                dbcart.RETAIL_ID = objcart.RetailerId;
                dbcart.USER_ID = objcart.UserId;
                dbcart.ITEM_ID = objcart.ProductId;
                dbcart.QUANTITY = objcart.Quantity;
                db.CARTs.Add(dbcart);
                db.SaveChanges();
                addC = dbcart.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addC;
        }

        public int UpdateCart(List<Cart> objcarts)
        {
            int updateC = 0;
            try
            {
                foreach (var item in objcarts)
                {
                    var obj = db.CARTs.FirstOrDefault(o => o.ID == item.CartId);
                    if (obj != null)
                    {
                        obj.QUANTITY = item.Quantity;
                        db.SaveChanges();
                        updateC = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateC;
        }

        public int DeleteCart(int cId)
        {
            int deleteC = 0;
            try
            {
                var obj = db.CARTs.FirstOrDefault(o => o.ID == cId);
                if (obj != null)
                {
                    //-obj.STATUS = false;
                    db.CARTs.Remove(obj);
                    db.SaveChanges();
                    deleteC = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteC;
        }
    }
}

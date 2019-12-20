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

        double SGST = Convert.ToDouble(ConfigurationSettings.AppSettings["SGST"]);
        double CGST = Convert.ToDouble(ConfigurationSettings.AppSettings["CGST"]);

        public List<Cart> GetCarts(int retailerId)
        {
            List<Cart> lstcarts;
            try
            {
                lstcarts = (from x in db.CARTs.Where(o => o.RETAIL_ID == retailerId)
                            select new Cart
                            {
                                CartId = x.ID,
                                ProductId = x.ITEM_ID,
                                RetailerId = x.RETAIL_ID,
                                UserId = x.USER_ID.Value,
                                Quantity = x.QUANTITY,
                                ProductName = x.PRODUCT.NAME,
                                Price = x.PRODUCT.SELLING_PRICE.Value,
                                CGST = (!string.IsNullOrEmpty(CGST.ToString())) ? (x.PRODUCT.SELLING_PRICE.Value) * (CGST) / 100 : 0,
                                SGST = (!string.IsNullOrEmpty(SGST.ToString())) ? (x.PRODUCT.SELLING_PRICE.Value) * (SGST) / 100 : 0,
                                TaxAmount = (!string.IsNullOrEmpty(CGST.ToString()) && !string.IsNullOrEmpty(SGST.ToString())) ? (x.PRODUCT.SELLING_PRICE.Value) * (SGST + CGST) / 100 : 0,
                                TotalPrice = (!string.IsNullOrEmpty(CGST.ToString()) && !string.IsNullOrEmpty(SGST.ToString())) ? ((x.PRODUCT.SELLING_PRICE.Value) * (SGST + CGST) / 100) + x.PRODUCT.SELLING_PRICE.Value : x.PRODUCT.SELLING_PRICE.Value
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

        public int UpdateCart(Cart objcart)
        {
            int updateC = 0;
            try
            {
                var obj = db.CARTs.FirstOrDefault(o => o.ID == objcart.CartId);
                if (obj != null)
                {
                    obj.QUANTITY = objcart.Quantity;
                    db.SaveChanges();
                    updateC = 1;
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

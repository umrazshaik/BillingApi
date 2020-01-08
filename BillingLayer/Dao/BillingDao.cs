using BillingLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Billing;
using System.Data.Entity;

namespace BillingLayer.Dao
{
    public class BillingDao
    {
        BillingAppDBEntities db = new BillingAppDBEntities();

        public int AddBilling(Bill bill)
        {
            int addBill = 0;
            try
            {
                BILLING objbillinfo = new BILLING();
                Random random = new Random();
                objbillinfo.BILL_NO = "BL"+ RandomString(6);
                objbillinfo.RETAIL_ID = bill.BillInfo.RetailId;
                objbillinfo.USER_ID = bill.BillInfo.UserId;
                objbillinfo.CUSTOMER_NAME = bill.BillInfo.CustomerName;
                objbillinfo.CUST_MOBILE = bill.BillInfo.CustMobile;
                objbillinfo.PAID_AMOUNT = bill.BillInfo.PaidAmount;
                objbillinfo.TAX_AMOUNT = bill.BillInfo.TaxAmount;
                objbillinfo.ACTUAL_AMOUNT = bill.BillInfo.ActualAmount;
                objbillinfo.BILLED_AMOUNT = bill.BillInfo.BilledAmount;
                objbillinfo.PAYMENT_TYPE = bill.BillInfo.PaymentType;
                objbillinfo.STATUS = true;
                objbillinfo.CREATED_BY = bill.BillInfo.CreatedBy;
                objbillinfo.UPDATED_BY = bill.BillInfo.UpdatedBy;
                objbillinfo.CREATED_DATE = DateTime.Now;
                objbillinfo.UPDATED_DATE = DateTime.Now;
                db.BILLINGS.Add(objbillinfo);
                db.SaveChanges();
                addBill = objbillinfo.ID;
                if (addBill > 0)
                    AddBillInfoProducts(bill.BillProducts, addBill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addBill;
        }

        public int AddBillInfoProducts(List<BillingProducts> products, int billId)
        {
            int billP = 0;
            try
            {
                foreach (var item in products)
                {
                    BILLING_INFO dbbillinfo = new BILLING_INFO();
                    dbbillinfo.BILL_ID = billId;
                    dbbillinfo.QUANTITY = item.Quantity;
                    dbbillinfo.PRODUCT_ID = item.ProductId;
                    dbbillinfo.PRICE = item.Price;
                    dbbillinfo.TAX = item.Tax;
                    dbbillinfo.STATUS = true;
                    dbbillinfo.CREATED_BY = item.CreatedBy;
                    dbbillinfo.UPDATED_BY = item.UpdatedBy;
                    dbbillinfo.CREATED_DATE = DateTime.Now;
                    dbbillinfo.UPDATED_DATE = DateTime.Now;
                    db.BILLING_INFO.Add(dbbillinfo);
                    db.SaveChanges();
                    billP = 1;
                }
                if(billP==1)
                {
                    var carts = db.CARTs.ToList();
                    db.Database.ExecuteSqlCommand(string.Format("DELETE  FROM Cart"));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billP;
        }

        public int DeleteBill(int billId)
        {
            int billD = 0;
            try
            {
                var objbill = db.BILLINGS.FirstOrDefault(o => o.ID == billId);
                if (objbill != null)
                {
                    objbill.STATUS = false;
                    db.SaveChanges();
                    billD = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billD;
        }

        public List<BillingInfo> GetBills(int retailerId)
        {
            List<BillingInfo> lstBills = null;
            try
            {
                lstBills = (from x in db.BILLINGS.Where(o => o.RETAIL_ID == retailerId && o.STATUS==true)
                            select new BillingInfo
                            {
                                ActualAmount = x.ACTUAL_AMOUNT.Value,
                                BilledAmount = x.BILLED_AMOUNT.Value,
                                BillId = x.ID,
                                BillNo = x.BILL_NO,
                                CreatedBy = x.CREATED_BY,
                                CreatedDate = x.CREATED_DATE.Value,
                                PaidAmount = x.PAID_AMOUNT.Value,
                                CustomerName=x.CUSTOMER_NAME,
                                CustMobile=x.CUST_MOBILE.Value,
                                PaymentType = x.PAYMENT_TYPE,
                                RetailId = x.RETAIL_ID,
                                Status = x.STATUS.Value,
                                TaxAmount = x.TAX_AMOUNT.Value,
                                UpdatedBy = x.UPDATED_BY,
                                UpdatedDate = x.UPDATED_DATE.Value,
                                UserId = x.USER_ID.Value
                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstBills;
        }

        public List<BillingInfo> GetBillsByDate(int retailerId,DateTime fromdate, DateTime todate)
        {
            List<BillingInfo> lstBills = null;
            try
            {
                lstBills = (from x in db.BILLINGS.Where(o => o.RETAIL_ID == retailerId && o.STATUS == true
                            && DbFunctions.TruncateTime(o.CREATED_DATE) >= DbFunctions.TruncateTime(fromdate) && DbFunctions.TruncateTime(o.CREATED_DATE) <= DbFunctions.TruncateTime(todate))
                            let fdate = DbFunctions.TruncateTime(x.CREATED_DATE)
                            select new BillingInfo
                            {
                                ActualAmount = x.ACTUAL_AMOUNT.Value,
                                BilledAmount = x.BILLED_AMOUNT.Value,
                                BillId = x.ID,
                                BillNo = x.BILL_NO,
                                CreatedBy = x.CREATED_BY,
                                CreatedDate = x.CREATED_DATE.Value,
                                PaidAmount = x.PAID_AMOUNT.Value,
                                CustomerName = x.CUSTOMER_NAME,
                                CustMobile = x.CUST_MOBILE.Value,
                                PaymentType = x.PAYMENT_TYPE,
                                RetailId = x.RETAIL_ID,
                                Status = x.STATUS.Value,
                                TaxAmount = x.TAX_AMOUNT.Value,
                                UpdatedBy = x.UPDATED_BY,
                                UpdatedDate = x.UPDATED_DATE.Value,
                                UserId = x.USER_ID.Value
                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstBills;
        }

        public Bill GetBillInfo(int billId)
        {
            Bill objbill = null;
            try
            {
                var obj = (from x in db.BILLINGS.Where(o => o.ID == billId)
                           select new Bill
                           {
                               BillInfo = new BillingInfo()
                               {
                                   ActualAmount = x.ACTUAL_AMOUNT.Value,
                                   BilledAmount = x.BILLED_AMOUNT.Value,
                                   BillId = x.ID,
                                   BillNo = x.BILL_NO,
                                   CreatedBy = x.CREATED_BY,
                                   CreatedDate = x.CREATED_DATE.Value,
                                   CustomerName=x.CUSTOMER_NAME,
                                   CustMobile=x.CUST_MOBILE.Value,
                                   PaidAmount = x.PAID_AMOUNT.Value,
                                   PaymentType = x.PAYMENT_TYPE,
                                   RetailId = x.RETAIL_ID,
                                   Status = x.STATUS.Value,
                                   TaxAmount = x.TAX_AMOUNT.Value,
                                   UpdatedBy = x.UPDATED_BY,
                                   UpdatedDate = x.UPDATED_DATE.Value,
                                   UserId = x.USER_ID.Value
                               },
                               BillProducts = (from y in db.BILLING_INFO.Where(o => o.BILL_ID == x.ID)
                                               select new BillingProducts
                                               {
                                                   BillId=x.ID,
                                                   BillProductId=y.ID,
                                                   Price=y.PRICE.Value,
                                                   ProductName=y.PRODUCT.NAME,
                                                   Code=y.PRODUCT.CODE,
                                                   ProductId=y.PRODUCT_ID.Value,
                                                   Quantity=y.QUANTITY.Value,
                                                   Tax=y.TAX.Value,
                                                   CGSTPercentage=y.PRODUCT.CGST.Value,
                                                   SGSTPercentage=y.PRODUCT.SGST.Value,
                                                   Status=y.STATUS.Value
                                               }).ToList()

                           }).FirstOrDefault();

                if (obj != null)
                    objbill = obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objbill;
        }

        private static Random random = new Random();
        public  string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

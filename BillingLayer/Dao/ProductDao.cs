using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Product;
using BillingLayer.Model;

namespace BillingLayer.Dao
{
    public class ProductDao
    {
        BillingAppDBEntities db = new BillingAppDBEntities();

        public List<Product> GetProducts(int retailerId)
        {
            List<Product> lstproducts;
            try
            {
                lstproducts = (from x in db.PRODUCTS.Where(o => o.RETAIL_ID == retailerId)
                               select new Product
                               {
                                   BrandId = x.BRAND_ID.Value,
                                   BrandName = x.BRAND.NAME,
                                   CreatedBy = x.CREATED_BY,
                                   CreatedDate = x.CREATED_DATE.Value,
                                   Id = x.ID,
                                   Name = x.NAME,
                                   DisplayName = x.DISPLAY_NAME,
                                   RetailId = x.RETAIL_ID.Value,
                                   RetailName = x.RETAILER.NAME,
                                   ActualCost = x.ACTUAL_PRICE.Value,
                                   SellingCost = x.SELLING_PRICE.Value,
                                   Status = x.STATUS.Value,
                                   TypeId = x.TYPE_ID.Value,
                                   TypeName = x.PRODUCT_TYPE.TYPE,
                                   UpdatedBy = x.UPDATED_BY,
                                   UpdatedDate = x.UPDATE_DATE.Value

                               }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstproducts;
        }

        public int AddProduct(Product objproduct)
        {
            int addp = 0;
            try
            {
                PRODUCT dbproduct = new PRODUCT();
                dbproduct.BRAND_ID = objproduct.BrandId;
                dbproduct.NAME = objproduct.Name;
                dbproduct.DISPLAY_NAME = objproduct.DisplayName;
                dbproduct.TYPE_ID = objproduct.TypeId;
                dbproduct.RETAIL_ID = objproduct.RetailId;
                dbproduct.ACTUAL_PRICE = objproduct.ActualCost;
                dbproduct.SELLING_PRICE = objproduct.SellingCost;
                dbproduct.CREATED_BY = objproduct.CreatedBy;
                dbproduct.CREATED_DATE = DateTime.Now;
                dbproduct.UPDATED_BY = objproduct.UpdatedBy;
                dbproduct.UPDATE_DATE = DateTime.Now;
                dbproduct.STATUS = true;
                db.PRODUCTS.Add(dbproduct);
                db.SaveChanges();
                addp =dbproduct.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addp;
        }

        public int UpdateProduct(Product objproduct)
        {
            int updateP = 0;
            try
            {
                var obj = db.PRODUCTS.FirstOrDefault(o => o.ID == objproduct.Id);
                if (obj != null)
                {
                    obj.DISPLAY_NAME = objproduct.DisplayName;
                    obj.BRAND_ID = objproduct.BrandId;
                    obj.TYPE_ID = objproduct.TypeId;
                    obj.ACTUAL_PRICE = objproduct.ActualCost;
                    obj.SELLING_PRICE = objproduct.SellingCost;
                    obj.STATUS = objproduct.Status;
                    obj.UPDATED_BY = objproduct.UpdatedBy;
                    obj.UPDATE_DATE = DateTime.Now;
                    db.SaveChanges();
                    updateP = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateP;
        }

        public int DeleteProduct(int pId)
        {
            int deleteP = 0;
            try
            {
                var obj = db.PRODUCTS.FirstOrDefault(o => o.ID == pId);
                if (obj != null)
                {
                    obj.STATUS = false;
                    db.SaveChanges();
                    deleteP = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteP;
        }

    }
}

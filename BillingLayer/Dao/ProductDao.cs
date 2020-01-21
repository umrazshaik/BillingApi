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
        private readonly BillingAppDBEntities db = null;
        public ProductDao()
        {
            db = DataBase.GetInstance;
        }


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
                                   Description = x.DESCRIPTION,
                                   Code = x.CODE,
                                   RetailId = x.RETAIL_ID.Value,
                                   RetailName = x.RETAILER.NAME,
                                   ActualCost = x.ACTUAL_PRICE.Value,
                                   SellingCost = x.SELLING_PRICE.Value,
                                   SGST = x.SGST.Value,
                                   CGST = x.CGST.Value,
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
                dbproduct.DESCRIPTION = objproduct.Description;
                dbproduct.CODE = objproduct.Code;
                dbproduct.TYPE_ID = objproduct.TypeId;
                dbproduct.RETAIL_ID = objproduct.RetailId;
                dbproduct.ACTUAL_PRICE = objproduct.ActualCost;
                dbproduct.SELLING_PRICE = objproduct.SellingCost;
                dbproduct.SGST = objproduct.SGST;
                dbproduct.CGST = objproduct.CGST;
                dbproduct.CREATED_BY = objproduct.CreatedBy;
                dbproduct.CREATED_DATE = DateTime.Now;
                dbproduct.UPDATED_BY = objproduct.UpdatedBy;
                dbproduct.UPDATE_DATE = DateTime.Now;
                dbproduct.STATUS = true;
                db.PRODUCTS.Add(dbproduct);
                db.SaveChanges();
                addp = dbproduct.ID;
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
                    obj.DESCRIPTION = objproduct.Description;
                    obj.CODE = objproduct.Code;
                    obj.BRAND_ID = objproduct.BrandId;
                    obj.TYPE_ID = objproduct.TypeId;
                    obj.ACTUAL_PRICE = objproduct.ActualCost;
                    obj.SELLING_PRICE = objproduct.SellingCost;
                    obj.SGST = objproduct.SGST;
                    obj.CGST = objproduct.CGST;
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
                int dependency1 = db.CARTs.Count(o => o.ITEM_ID == pId);
                int dependency2 = db.BILLING_INFO.Count(o => o.PRODUCT_ID == pId);
                if (obj != null && dependency1.Equals(0) && dependency2.Equals(0))
                {
                    // obj.STATUS = false;
                    db.PRODUCTS.Remove(obj);
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

        public int ImportProducts(List<Product> lstProds)
        {
            int isImport = 0; List<string> prodnames = null;
            try
            {
                int retailId = lstProds[0].RetailId;
                var dbprodobjects = db.PRODUCTS.Where(o => o.RETAIL_ID == retailId).ToList();
                if (dbprodobjects?.Count > 0)
                {
                    prodnames = dbprodobjects.Select(o => o.NAME).ToList();

                    foreach (var item in lstProds)
                    {
                        if (prodnames.Any(o => o.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            //update
                            var obj = dbprodobjects.FirstOrDefault(o => o.ID == item.Id);
                            if (obj != null)
                            {
                                obj.DISPLAY_NAME = item.DisplayName;
                                obj.DESCRIPTION = item.Description;
                                obj.CODE = item.Code;
                                obj.BRAND_ID = item.BrandId;
                                obj.TYPE_ID = item.TypeId;
                                obj.ACTUAL_PRICE = item.ActualCost;
                                obj.SELLING_PRICE = item.SellingCost;
                                obj.SGST = item.SGST;
                                obj.CGST = item.CGST;
                                obj.STATUS = item.Status;
                                obj.UPDATED_BY = item.UpdatedBy;
                                obj.UPDATE_DATE = DateTime.Now;
                            }
                        }
                        else
                        {
                            //insert
                            PRODUCT dbproduct = new PRODUCT();
                            dbproduct.BRAND_ID = item.BrandId;
                            dbproduct.NAME = item.Name;
                            dbproduct.DISPLAY_NAME = item.DisplayName;
                            dbproduct.DESCRIPTION = item.Description;
                            dbproduct.CODE = item.Code;
                            dbproduct.TYPE_ID = item.TypeId;
                            dbproduct.RETAIL_ID = retailId;
                            dbproduct.ACTUAL_PRICE = item.ActualCost;
                            dbproduct.SELLING_PRICE = item.SellingCost;
                            dbproduct.SGST = item.SGST;
                            dbproduct.CGST = item.CGST;
                            dbproduct.CREATED_BY = item.CreatedBy;
                            dbproduct.CREATED_DATE = DateTime.Now;
                            dbproduct.UPDATED_BY = item.UpdatedBy;
                            dbproduct.UPDATE_DATE = DateTime.Now;
                            dbproduct.STATUS = true;
                            db.PRODUCTS.Add(dbproduct);
                        }
                    }
                    if(lstProds?.Count>0)
                    {
                        db.SaveChanges();
                        isImport = 1;
                    }

                }
                else
                {
                    foreach (var item in lstProds)
                    {
                        //insert
                        PRODUCT dbproduct = new PRODUCT();
                        dbproduct.BRAND_ID = item.BrandId;
                        dbproduct.NAME = item.Name;
                        dbproduct.DISPLAY_NAME = item.DisplayName;
                        dbproduct.DESCRIPTION = item.Description;
                        dbproduct.CODE = item.Code;
                        dbproduct.TYPE_ID = item.TypeId;
                        dbproduct.RETAIL_ID = retailId;
                        dbproduct.ACTUAL_PRICE = item.ActualCost;
                        dbproduct.SELLING_PRICE = item.SellingCost;
                        dbproduct.SGST = item.SGST;
                        dbproduct.CGST = item.CGST;
                        dbproduct.CREATED_BY = item.CreatedBy;
                        dbproduct.CREATED_DATE = DateTime.Now;
                        dbproduct.UPDATED_BY = item.UpdatedBy;
                        dbproduct.UPDATE_DATE = DateTime.Now;
                        dbproduct.STATUS = true;
                        db.PRODUCTS.Add(dbproduct);
                    }
                    db.SaveChanges();
                    isImport = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isImport;
        }
    }
}

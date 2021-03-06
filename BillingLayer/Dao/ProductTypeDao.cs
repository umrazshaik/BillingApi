﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Product;
using BillingLayer.Model;

namespace BillingLayer.Dao
{
    public class ProductTypeDao
    {
        private readonly BillingAppDBEntities db = null;
        public ProductTypeDao()
        {
            db = DataBase.GetInstance;
        }

        public List<ProductType> GetProductTypes(int retailerId)
        {
            List<ProductType> lstproductType;
            try
            {
                lstproductType = (from x in db.PRODUCT_TYPE.Where(o => o.RETAIL_ID == retailerId)
                                  select new ProductType
                                  {
                                      CreatedBy = x.CREATED_BY,
                                      CreatedDate = x.CREATED_DATE.Value,
                                      Name = x.TYPE,
                                      UpdatedDate = x.UPDATED_DATE.Value,
                                      RetailId = x.RETAIL_ID.Value,
                                      Status = x.STATUS.Value,
                                      TypeId = x.ID,
                                      UpdatedBy = x.UPDATED_BY,
                                  }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstproductType;
        }

        public int AddProductType(ProductType objproductType)
        {
            int addp = 0;
            try
            {
                bool checkisExist = db.PRODUCT_TYPE.Any(o => o.TYPE == objproductType.Name && o.RETAIL_ID == objproductType.RetailId);
                if (!checkisExist)
                {
                    PRODUCT_TYPE dbproductType = new PRODUCT_TYPE();
                    dbproductType.TYPE = objproductType.Name;
                    dbproductType.RETAIL_ID = objproductType.RetailId;
                    dbproductType.CREATED_BY = objproductType.CreatedBy;
                    dbproductType.CREATED_DATE = DateTime.Now;
                    dbproductType.UPDATED_BY = objproductType.UpdatedBy;
                    dbproductType.UPDATED_DATE = DateTime.Now;
                    dbproductType.STATUS = true;
                    db.PRODUCT_TYPE.Add(dbproductType);
                    db.SaveChanges();
                    addp = dbproductType.ID;
                }
                else
                    return addp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addp;
        }

        public int UpdateProductType(ProductType objproductType)
        {
            int updateP = 0;
            try
            {
                var obj = db.PRODUCT_TYPE.FirstOrDefault(o => o.ID == objproductType.TypeId);
                if (obj != null)
                {
                    obj.TYPE = objproductType.Name;
                    obj.STATUS = objproductType.Status;
                    obj.UPDATED_BY = objproductType.UpdatedBy;
                    obj.UPDATED_DATE = DateTime.Now;
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

        public int DeleteProductType(int pId)
        {
            int deleteP = 0;
            try
            {
                var obj = db.PRODUCT_TYPE.FirstOrDefault(o => o.ID == pId);
                int dependencycount = db.PRODUCTS.Count(o => o.TYPE_ID == pId);
                if (obj != null && dependencycount.Equals(0))
                {
                    // obj.STATUS = false;
                    db.PRODUCT_TYPE.Remove(obj);
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

        public int ImportProductTypes(List<ProductType> lstTypes)
        {
            int isImport = 0; List<string> dbtypes = null;
            try
            {
                int retailId = lstTypes[0].RetailId;
                var dbProdTypes = db.PRODUCT_TYPE.Where(o => o.RETAIL_ID == retailId).ToList();
                if (dbProdTypes?.Count > 0)
                {
                    dbtypes = dbProdTypes.Select(o => o.TYPE).ToList();

                    foreach (var item in lstTypes)
                    {
                        if (dbtypes.Any(o => o.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            //update, ntg to update
                        }
                        else
                        {
                            //insert
                            PRODUCT_TYPE dbproductType = new PRODUCT_TYPE();
                            dbproductType.TYPE = item.Name;
                            dbproductType.RETAIL_ID = retailId;
                            dbproductType.CREATED_BY = item.CreatedBy;
                            dbproductType.CREATED_DATE = DateTime.Now;
                            dbproductType.UPDATED_BY = item.UpdatedBy;
                            dbproductType.UPDATED_DATE = DateTime.Now;
                            dbproductType.STATUS = true;
                            db.PRODUCT_TYPE.Add(dbproductType);
                        }
                    }
                    db.SaveChanges();
                    isImport = 1;
                }
                else
                {
                    foreach (var item in lstTypes)
                    {
                        PRODUCT_TYPE dbproductType = new PRODUCT_TYPE();
                        dbproductType.TYPE = item.Name;
                        dbproductType.RETAIL_ID = retailId;
                        dbproductType.CREATED_BY = item.CreatedBy;
                        dbproductType.CREATED_DATE = DateTime.Now;
                        dbproductType.UPDATED_BY = item.UpdatedBy;
                        dbproductType.UPDATED_DATE = DateTime.Now;
                        dbproductType.STATUS = true;
                        db.PRODUCT_TYPE.Add(dbproductType);
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

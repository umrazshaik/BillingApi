using BillingClasses.Product;
using BillingLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingLayer.Dao
{
    public class BrandsDao
    {
        private readonly BillingAppDBEntities db = null;
        public BrandsDao()
        {
            db = DataBase.GetInstance;
        }

        public List<Brand> GetBrands(int retailerId)
        {
            List<Brand> lstBrands;
            try
            {
                lstBrands = (from x in db.BRANDS.Where(o => o.RETAIL_ID == retailerId)
                             select new Brand
                             {
                                 CreatedBy = x.CREATED_BY,
                                 CreatedDate = x.CREATED_DATE.Value,
                                 BrandName = x.NAME,
                                 UpdatedDate = x.UPDATED_DATE.Value,
                                 RetailId = x.RETAIL_ID.Value,
                                 Status = x.STATUS.Value,
                                 UpdatedBy = x.UPDATED_BY,
                                 BrandId = x.ID
                             }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstBrands;
        }

        public int AddBrand(Brand objbrand)
        {
            int addB = 0;
            try
            {
                BRAND dbbrand = new BRAND();

                dbbrand.RETAIL_ID = objbrand.RetailId;
                dbbrand.CREATED_BY = objbrand.CreatedBy;
                dbbrand.CREATED_DATE = DateTime.Now;
                dbbrand.UPDATED_BY = objbrand.UpdatedBy;
                dbbrand.UPDATED_DATE = DateTime.Now;
                dbbrand.STATUS = true;
                dbbrand.NAME = objbrand.BrandName;
                dbbrand.RETAIL_ID = objbrand.RetailId;
                db.BRANDS.Add(dbbrand);
                db.SaveChanges();
                addB = dbbrand.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addB;
        }

        public int UpdateBrand(Brand objbrand)
        {
            int updateB = 0;
            try
            {
                var obj = db.BRANDS.FirstOrDefault(o => o.ID == objbrand.BrandId);
                if (obj != null)
                {
                    obj.NAME = objbrand.BrandName;
                    obj.STATUS = objbrand.Status;
                    obj.UPDATED_BY = objbrand.UpdatedBy;
                    obj.UPDATED_DATE = DateTime.Now;
                    db.SaveChanges();
                    updateB = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateB;
        }

        public int DeleteBrand(int bId)
        {
            int deleteB = 0;
            try
            {
                var obj = db.BRANDS.FirstOrDefault(o => o.ID == bId);
                int dependencycount = db.PRODUCTS.Count(o => o.BRAND_ID == bId);
                if (obj != null && dependencycount.Equals(0))
                {
                    //obj.STATUS = false;
                    db.BRANDS.Remove(obj);
                    db.SaveChanges();
                    deleteB = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteB;
        }
        public int ImportBrands(List<Brand> lstBrands)
        {
            int isImport = 0; List<string> dbbrandnames = null;
            try
            {
                int retailId = lstBrands[0].RetailId;
                var dbbrandsobj = db.BRANDS.Where(o => o.RETAIL_ID == retailId).ToList();
                if (dbbrandsobj?.Count > 0)
                {
                    dbbrandnames = dbbrandsobj.Select(o => o.NAME).ToList();

                    foreach (var item in lstBrands)
                    {
                        if (dbbrandnames.Any(o => o.Equals(item.BrandName, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            //update, ntg to update
                        }
                        else
                        {
                            //insert
                            BRAND dbbrand = new BRAND();
                            dbbrand.RETAIL_ID = retailId;
                            dbbrand.CREATED_BY = item.CreatedBy;
                            dbbrand.CREATED_DATE = DateTime.Now;
                            dbbrand.UPDATED_BY = item.UpdatedBy;
                            dbbrand.UPDATED_DATE = DateTime.Now;
                            dbbrand.STATUS = true;
                            dbbrand.NAME = item.BrandName;
                            db.BRANDS.Add(dbbrand);
                        }
                    }
                    db.SaveChanges();
                    isImport = 1;
                }
                else
                {
                    //insert
                    foreach (var item in lstBrands)
                    {
                        BRAND dbbrand = new BRAND();
                        dbbrand.RETAIL_ID = retailId;
                        dbbrand.CREATED_BY = item.CreatedBy;
                        dbbrand.CREATED_DATE = DateTime.Now;
                        dbbrand.UPDATED_BY = item.UpdatedBy;
                        dbbrand.UPDATED_DATE = DateTime.Now;
                        dbbrand.STATUS = true;
                        dbbrand.NAME = item.BrandName;
                        db.BRANDS.Add(dbbrand);
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

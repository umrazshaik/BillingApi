using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Common;
using BillingClasses.Product;
using BillingLayer.Model;
using System.IO;

namespace BillingLayer.Dao
{
    public static class Converter
    {
        static BillingAppDBEntities db = new BillingAppDBEntities();

        public static DataTable GetDataTableFromExcel(Stream file)
        {
            DataTable dt = new DataTable();
            try
            {
                using (XLWorkbook workBook = new XLWorkbook(file))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);

                    //Create a new DataTable.

                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt, string tableType, int retailerId)
        {
            List<T> values = new List<T>();
            try
            {
                switch (tableType)
                {
                    case Constants.ProductTypes:
                        ConvertProductType(dt, values as List<ProductType>, retailerId);
                        break;

                    case Constants.Brands:
                        ConvertBrands(dt, values as List<Brand>, retailerId);
                        break;

                    case Constants.Products:
                        ConvertProducts(dt, values as List<Product>, retailerId);
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return values;
        }

        public static void ConvertProductType(DataTable dt, List<ProductType> values, int retailerId)
        {
            try
            {
                if (dt?.Rows?.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(item[Constants.Name].ToString().Trim()))
                        {
                            ProductType obj = new ProductType();
                            obj.Name = item[Constants.Name].ToString().Trim();
                            obj.RetailId = retailerId;
                            obj.Status = true;
                            obj.CreatedBy = Constants.Admin;
                            obj.UpdatedBy = Constants.Admin;
                            obj.CreatedDate = DateTime.Now;
                            obj.UpdatedDate = DateTime.Now;
                            values.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ConvertBrands(DataTable dt, List<Brand> values, int retailerId)
        {
            try
            {
                if (dt?.Rows?.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(item[Constants.Name].ToString().Trim()))
                        {
                            Brand obj = new Brand();
                            obj.BrandName = item[Constants.Name].ToString().Trim();
                            obj.RetailId = retailerId;
                            obj.Status = true;
                            obj.CreatedBy = Constants.Admin;
                            obj.UpdatedBy = Constants.Admin;
                            obj.CreatedDate = DateTime.Now;
                            obj.UpdatedDate = DateTime.Now;
                            values.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ConvertProducts(DataTable dt, List<Product> values, int retailerId)
        {
            bool iserror = false;
            List<string> brands = db.BRANDS.Select(o => o.NAME).ToList();
            List<string> types = db.PRODUCT_TYPE.Select(o => o.TYPE).ToList();
            try
            {
                if (dt?.Rows?.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Product obj = new Product();
                        obj.Name = !string.IsNullOrEmpty(item[Constants.Name].ToString()) ? item[Constants.Name].ToString().Trim() : string.Empty;
                        if (string.IsNullOrEmpty(obj.Name)) iserror = true;

                        obj.DisplayName = !string.IsNullOrEmpty(item[Constants.DisplayName].ToString()) ? item[Constants.DisplayName].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(obj.DisplayName)) iserror = true;

                        obj.Code = !string.IsNullOrEmpty(item[Constants.Code].ToString()) ? item[Constants.Code].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(obj.Code)) iserror = true;

                        obj.Description = !string.IsNullOrEmpty(item[Constants.Desc].ToString()) ? item[Constants.Desc].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(obj.Name)) iserror = true;

                        obj.SellingCost = item[Constants.SellP] != DBNull.Value ? Convert.ToDouble(item[Constants.SellP]) : 0;
                        if (obj.SellingCost.Equals(0)) iserror = true;

                        obj.ActualCost = item[Constants.ActP] != DBNull.Value ? Convert.ToDouble(item[Constants.ActP]) : 0;
                        if (obj.ActualCost.Equals(0)) iserror = true;

                        obj.SGST = item[Constants.sgst] != DBNull.Value ? Convert.ToInt32(item[Constants.sgst]) : 0;
                        if (obj.SGST.Equals(0)) iserror = true;

                        obj.CGST = item[Constants.cgst] != DBNull.Value ? Convert.ToInt32(item[Constants.cgst]) : 0;
                        if (obj.CGST.Equals(0)) iserror = true;

                        obj.BrandName = !string.IsNullOrEmpty(item[Constants.Brand].ToString()) ? item[Constants.Brand].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(obj.BrandName)) iserror = true;

                        obj.TypeName = !string.IsNullOrEmpty(item[Constants.ProdType].ToString()) ? item[Constants.ProdType].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(obj.TypeName)) iserror = true;

                        if (brands?.Count > 0 && !brands.Any(o => o.Equals(obj.BrandName, StringComparison.InvariantCultureIgnoreCase)))
                            iserror = true;
                        else
                            obj.BrandId = db.BRANDS.FirstOrDefault(o => o.NAME == obj.BrandName).ID;

                        if (types?.Count > 0 && !types.Any(o => o.Equals(obj.TypeName, StringComparison.InvariantCultureIgnoreCase)))
                            iserror = true;
                        else
                            obj.TypeId = db.PRODUCT_TYPE.FirstOrDefault(o => o.TYPE == obj.TypeName).ID;

                        obj.RetailId = retailerId;
                        obj.Status = true;
                        obj.CreatedBy = Constants.Admin;
                        obj.UpdatedBy = Constants.Admin;
                        obj.CreatedDate = DateTime.Now;
                        obj.UpdatedDate = DateTime.Now;
                        if (!iserror)
                            values.Add(obj);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

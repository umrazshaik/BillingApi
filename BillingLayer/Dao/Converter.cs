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

        public static MemoryStream WritingDataTableToExcel(DataTable dt)
        {
            try
            {
                var wb = new XLWorkbook();
                var dataTable = dt;
                // Add a DataTable as a worksheet
                wb.Worksheets.Add(dataTable);
                MemoryStream stream = GetStream(wb);
                // The method is defined below             
                return stream;
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }

        public static MemoryStream GetStream(XLWorkbook excelWorkbook)
        {
            MemoryStream fs = new MemoryStream();
            excelWorkbook.SaveAs(fs);
            fs.Position = 0;
            return fs;
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

        public static DataTable ExportDataTable<T>(string tableType, List<T> values)
        {
            DataTable dt = null;
            try
            {
                if (values?.Count > 0)
                {
                    dt = BuildDataTableColumns(tableType);
                    BuildDataTableRows(tableType, dt, values);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        private static void BuildDataTableRows<T>(string tableType, DataTable dt, List<T> values)
        {
            DataRow newRow = null;
            try
            {
                switch (tableType)
                {
                    case Constants.ProductTypes:
                        List<ProductType> types = values as List<ProductType>;
                        if (types?.Count > 0)
                        {
                            foreach (var item in types)
                            {
                                newRow = dt.NewRow();
                                newRow[Constants.Name] = item.Name;
                                dt.Rows.Add(newRow);
                            }
                        }
                        break;
                    case Constants.Brands:
                        List<Brand> lstbrands = values as List<Brand>;
                        if (lstbrands?.Count > 0)
                        {
                            foreach (var item in lstbrands)
                            {
                                newRow = dt.NewRow();
                                newRow[Constants.Name] = item.BrandName;
                                dt.Rows.Add(newRow);
                            }
                        }
                        break;
                    case Constants.Products:
                        List<Product> lstprods = values as List<Product>;
                        if (lstprods?.Count > 0)
                        {
                            foreach (var item in lstprods)
                            {
                                newRow = dt.NewRow();
                                newRow[Constants.Name] = item.Name;
                                newRow[Constants.DisplayName] = item.DisplayName;
                                newRow[Constants.Desc] = item.Description;
                                newRow[Constants.Code] = item.Code;
                                newRow[Constants.ProdType] = item.TypeName;
                                newRow[Constants.Brand] = item.BrandName;
                                newRow[Constants.ActP] = item.ActualCost;
                                newRow[Constants.SellP] = item.SellingCost;
                                newRow[Constants.sgst] = item.SGST;
                                newRow[Constants.cgst] = item.CGST;
                                dt.Rows.Add(newRow);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuildDataTableColumns(string tableType)
        {
            DataTable l_columnsDT = new DataTable();
            try
            {
                switch (tableType)
                {
                    case Constants.ProductTypes:
                        l_columnsDT.TableName = Constants.ProductTypes;
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Name, DataType = typeof(String) });
                        break;
                    case Constants.Brands:
                        l_columnsDT.TableName = Constants.Brands;
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Name, DataType = typeof(String) });
                        break;
                    case Constants.Products:
                        l_columnsDT.TableName = Constants.Products;
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Name, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.DisplayName, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Desc, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Code, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.ProdType, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.Brand, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.ActP, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.SellP, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.sgst, DataType = typeof(String) });
                        l_columnsDT.Columns.Add(new DataColumn() { ColumnName = Constants.cgst, DataType = typeof(String) });
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l_columnsDT;
        }
    }
}

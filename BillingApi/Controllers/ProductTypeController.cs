using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Product;
using BillingLayer.Dao;
using System.Web;
using BillingClasses.Common;
using System.IO;
using System.Net.Http.Headers;

namespace BillingApi.Controllers
{
    [RoutePrefix("api/productType")]
    public class ProductTypeController : ApiController
    {
        private readonly ProductTypeDao dao;

        public ProductTypeController()
        {
            dao = new ProductTypeDao();
        }

        [HttpGet, Route("gett")]
        public IHttpActionResult GetProductTypes(int retailerId)
        {
            try
            {
                var products = dao.GetProductTypes(retailerId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("addt")]
        public IHttpActionResult AddProductType([FromBody] ProductType objproductType)
        {
            try
            {
                int isAdded = dao.AddProductType(objproductType);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("updatet")]
        public IHttpActionResult UpdateProductType([FromBody] ProductType objproductType)
        {
            try
            {
                int isUpdated = dao.UpdateProductType(objproductType);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete, Route("deletet")]
        public IHttpActionResult DeleteProductType(int typeId)
        {
            try
            {
                int isDeleted = dao.DeleteProductType(typeId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("import")]
        public IHttpActionResult ImportProductTypes(int retailId)
        {
            int isImport = 0;
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var dt = Converter.GetDataTableFromExcel(postedFile.InputStream);
                        List<ProductType> lstpords = Converter.ConvertDataTableToList<ProductType>(dt, Constants.ProductTypes, retailId);
                        if (lstpords?.Count > 0)
                            isImport = dao.ImportProductTypes(lstpords);
                    }
                }
                return Ok(isImport);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet, Route("export")]
        public IHttpActionResult ExportProductTypes(int retailerId)
        {
            try
            {
                var types = dao.GetProductTypes(retailerId);
                var datatable = Converter.ExportDataTable(Constants.ProductTypes, types.ToList());
                if (datatable?.Rows?.Count > 0)
                {
                    //convert to
                    var data = Converter.WritingDataTableToExcel(datatable);
                    

                    //return ;

                    return Ok(data.ToArray());
                }
                return null;
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
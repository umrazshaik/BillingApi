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

namespace BillingApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly ProductDao dao;

        public ProductController()
        {
            dao = new ProductDao();
        }

        [HttpGet, Route("getp")]
        public IHttpActionResult GetProducts(int retailerId)
        {
            try
            {
                var products = dao.GetProducts(retailerId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("addp")]
        public IHttpActionResult AddProduct([FromBody] Product objproduct)
        {
            try
            {
                int isAdded = dao.AddProduct(objproduct);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("updatep")]
        public IHttpActionResult UpdateProduct([FromBody] Product objproduct)
        {
            try
            {
                int isUpdated = dao.UpdateProduct(objproduct);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete, Route("deletep")]
        public IHttpActionResult DeleteProduct(int productId)
        {
            try
            {
                int isDeleted = dao.DeleteProduct(productId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("import")]
        public IHttpActionResult ImportProducts(int retailId)
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
                        List<Product> lstpords = Converter.ConvertDataTableToList<Product>(dt, Constants.Products, retailId);
                        if (lstpords?.Count > 0)
                            isImport = dao.ImportProducts(lstpords);
                    }
                }
                return Ok(isImport);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Product;
using BillingLayer.Dao;

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

        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
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
    }
}

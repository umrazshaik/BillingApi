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
    [RoutePrefix("api/Products")]
    public class ProductTypeController : ApiController
    {
        private readonly ProductTypeDao dao;

        public ProductTypeController()
        {
            dao = new ProductTypeDao();
        }

        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
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
    }
}

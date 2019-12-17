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
    [RoutePrefix("api/brands")]
    public class BrandController : ApiController
    {
        private readonly BrandsDao dao;

        public BrandController()
        {
            dao = new BrandsDao();
        }

        [HttpGet]
        public IHttpActionResult GetBrands(int retailerId)
        {
            try
            {
                var brands = dao.GetBrands(retailerId);
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddBrand([FromBody] Brand objbrand)
        {
            try
            {
                int isAdded = dao.AddBrand(objbrand);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateBrand([FromBody] Brand objbrand)
        {
            try
            {
                int isUpdated = dao.UpdateBrand(objbrand);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBrand(int brandId)
        {
            try
            {
                int isDeleted = dao.DeleteBrand(brandId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

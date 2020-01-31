using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Common;
using BillingLayer.Dao;
using BillingApi.Filters;

namespace BillingApi.Controllers
{
    [RoutePrefix("api/retailer")]
    public class RetailersController : ApiController
    {
       private readonly RetailerDao dao;

        public RetailersController()
        {
            dao = new RetailerDao();
        }
        [AuthorizationFilter]
        [HttpGet,Route("getr")]
        public IHttpActionResult GetRetailer()
        {
            try
            {
                var retailer = dao.GetRetailerDetails();
                return Ok(retailer);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("addr")]
        public IHttpActionResult AddRetailer(Retailer objretailer)
        {
            try
            {
                int id = dao.AddRetailer(objretailer);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
        [AuthorizationFilter]
        [HttpPost, Route("updater")]
        public IHttpActionResult UpdateRetailer(Retailer objretailer)
        {
            try
            {
                int id = dao.UpdateRetailer(objretailer);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}

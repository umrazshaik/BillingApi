using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Common;
using BillingLayer.Dao;

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

        [HttpGet]
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

    }
}

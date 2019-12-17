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
    [RoutePrefix("api/User")]
    public class UsersController : ApiController
    {
       private readonly UserDao dao;

        public UsersController()
        {
            dao = new UserDao();
        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var retailerId = ((string[])(Request.Headers.GetValues("retailerId")))[0];
                int retailId =Convert.ToInt32(retailerId);
                var Usersdata = dao.GetUsers(retailId);
                return Ok(Usersdata);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

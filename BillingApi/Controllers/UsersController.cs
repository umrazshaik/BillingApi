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
    [AuthorizationFilter]
    [RoutePrefix("api/User")]
    public class UsersController : ApiController
    {
        private readonly UserDao dao;

        public UsersController()
        {
            dao = new UserDao();
        }

        [HttpGet]
        public IHttpActionResult GetUsers(int retailerId)
        {
            try
            {
                var Usersdata = dao.GetUsers(retailerId);
                return Ok(Usersdata);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

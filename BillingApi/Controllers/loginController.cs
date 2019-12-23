using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingLayer.Dao;
using BillingClasses.Common;

namespace BillingApi.Controllers
{
    [RoutePrefix("api/login")]
    public class loginController : ApiController
    {
        private readonly logindao dao;

        public loginController()
        {
            dao = new logindao();
        }

        [HttpGet, Route("validate/{UserName}/{Password}")]
        public IHttpActionResult LoginUser(string UserName, string Password)
        {
            var user = new Users();
            try
            {
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    Users objuser = new Users();
                    objuser.UserName = UserName;
                    objuser.Password = Password;
                    user = dao.LoginUser(objuser);
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingLayer.Dao;
using BillingClasses.Common;
using System.Configuration;
using BillingApi.Filters;

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
            string key = ConfigurationSettings.AppSettings["bill29"];
            string format = "A9DCF37AED8574A1441FD82DB743765A";
            string Token = string.Empty;
            try
            {
                bool verify = (!string.IsNullOrEmpty(key) && key == SecurityHelper.PasswordEncrypt(System.Environment.MachineName, format));

                if (verify && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    Users objuser = new Users();
                    objuser.UserName = UserName;
                    objuser.Password = Password;
                    user = dao.LoginUser(objuser);
                    if(user!=null)
                    {
                        Token = TokenManager.GenerateToken(user.UserName);
                    }
                    return Ok(user);
                }
                else
                    return Content(HttpStatusCode.InternalServerError,"Unauthorize");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingLayer.Dao;


namespace BillingApi.Controllers
{
    [RoutePrefix("security")]
    public class SecurityController : ApiController
    {
        
        [HttpGet,Route("getkey/{pcname}")]
        public IHttpActionResult GetKey(string pcname)
        {
            try
            {
                return Ok(SecurityHelper.PasswordEncrypt(pcname, "A9DCF37AED8574A1441FD82DB743765A"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("getpckey")]
        public IHttpActionResult GetPcKey()
        {
            return Ok(SecurityHelper.PasswordEncrypt(System.Environment.MachineName, "A9DCF37AED8574A1441FD82DB743765A"));
        }
    }
}

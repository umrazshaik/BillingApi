using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BillingApi.Filters;
using System.Net;

namespace BillingApi.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public string[] Role { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            string tokenparameter = null; string token = null;
            try
            {
                var auth = actionContext.Request.Headers.Authorization;
                if (auth != null)
                    tokenparameter = auth.Parameter;

                tokenparameter = Encoding.Default.GetString(Convert.FromBase64String(tokenparameter));


                if (!string.IsNullOrEmpty(tokenparameter))
                    token = tokenparameter.ToString();

                string isvalid = TokenManager.ValidateToken(token);
                if (string.IsNullOrEmpty(isvalid))
                    throw new UnauthorizedAccessException();

                //bool isadminuser = (!string.IsNullOrEmpty(Role) && Role.Equals(isvalid[1].ToString(), StringComparison.InvariantCultureIgnoreCase)); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
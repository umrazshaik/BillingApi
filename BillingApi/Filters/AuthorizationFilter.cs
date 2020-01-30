using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BillingApi.Filters;

namespace BillingApi.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string tokenparameter = null; string token = null;
            try
            {
                var auth = actionContext.Request.Headers.Authorization.Parameter;
                if (auth != null)
                    tokenparameter = auth;

                tokenparameter = Encoding.Default.GetString(Convert.FromBase64String(tokenparameter));

                var tokens = tokenparameter.Split(':');

                if (tokenparameter.Length > 0)
                    token = tokenparameter[0].ToString();

                string isvalid = TokenManager.ValidateToken(token);

                if (string.IsNullOrEmpty(isvalid))
                    throw new Exception("Invalid Token");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
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
    public class CartController : ApiController
    {
        private readonly CartDao dao;

        public CartController()
        {
            dao = new CartDao();
        }

        [HttpGet]
        public IHttpActionResult GetCarts(int retailerId)
        {
            try
            {
                var products = dao.GetCarts(retailerId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddCart([FromBody] Cart objcart)
        {
            try
            {
                int isAdded = dao.AddCart(objcart);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateCartt([FromBody] Cart objcart)
        {
            try
            {
                int isUpdated = dao.UpdateCart(objcart);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCart(int cartId)
        {
            try
            {
                int isDeleted = dao.DeleteCart(cartId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

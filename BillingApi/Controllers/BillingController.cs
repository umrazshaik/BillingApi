using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BillingClasses.Billing;
using BillingLayer.Dao;

namespace BillingApi.Controllers
{
    [RoutePrefix("api/billing")]
    public class BillingController : ApiController
    {
        private readonly BillingDao dao;

        public BillingController()
        {
            dao = new BillingDao();
        }

        [HttpGet, Route("getbill")]
        public IHttpActionResult GetBills(int retailerId)
        {
            try
            {
                var bills = dao.GetBills(retailerId);
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet, Route("getbillbydates")]
        public IHttpActionResult GetBillsByDates(int retailerId,string fromdate,string todate)
        {
            try
            {
                var bills = dao.GetBillsByDate(retailerId,Convert.ToDateTime(fromdate),Convert.ToDateTime(todate));
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost, Route("addbill")]
        public IHttpActionResult AddBill([FromBody] Bill objbill)
        {
            try
            {
                int isAdded = dao.AddBilling(objbill);
                return Ok(isAdded);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete, Route("deletebill")]
        public IHttpActionResult DeleteBill(int billId)
        {
            try
            {
                int isDeleted = dao.DeleteBill(billId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet, Route("getbillinfo")]
        public IHttpActionResult GetBillInfo(int billId)
        {
            try
            {
                var billinfo = dao.GetBillInfo(billId);
                return Ok(billinfo);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

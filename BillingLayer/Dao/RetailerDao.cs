using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Common;
using BillingLayer.Model;

namespace BillingLayer.Dao
{
    public class RetailerDao
    {
        BillingAppDBEntities db = new BillingAppDBEntities();

        public Retailer GetRetailerDetails()
        {
            try
            {
                var retailer = (from x in db.RETAILERS
                                select new Retailer
                                {
                                    Address = x.ADDRESS,
                                    AlternateMob = x.ALTERNATE_MOB.Value,
                                    City = x.CITY,
                                    CreatedDate = x.CREATED_DATE.Value,
                                    District = x.DISTRICT,
                                    Mobile = x.MOBILE.Value,
                                    PinCode = x.PIN_CODE.Value,
                                    RetailId = x.ID,
                                    RetailName = x.NAME,
                                    DisplayName = x.DISPLAY_NAME,
                                    State = x.STATE,
                                    Status = x.STATUS.Value
                                }).FirstOrDefault();
                return retailer;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

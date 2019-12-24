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
                                    ShopNo = x.SHOP_NO,
                                    Area = x.AREA,
                                    Building = x.BUILDING,
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

        public int AddRetailer(Retailer objretailer)
        {
            int addR = 0; UserDao daouser = new UserDao();
            try
            {
                if (objretailer != null && objretailer.RetailId.Equals(0))
                {
                    if (db.RETAILERS.Count() == 0)
                    {
                        RETAILER dbretailer = new RETAILER();
                        dbretailer.NAME = objretailer.RetailName;
                        dbretailer.DISPLAY_NAME = objretailer.DisplayName;
                        dbretailer.ADDRESS = objretailer.Address;
                        dbretailer.SHOP_NO = objretailer.ShopNo;
                        dbretailer.BUILDING = objretailer.Building;
                        dbretailer.AREA = objretailer.Area;
                        dbretailer.MOBILE = objretailer.Mobile;
                        dbretailer.ALTERNATE_MOB = objretailer.AlternateMob;
                        dbretailer.PIN_CODE = objretailer.PinCode;
                        dbretailer.CITY = objretailer.City;
                        dbretailer.DISTRICT = objretailer.District;
                        dbretailer.STATE = objretailer.State;
                        dbretailer.STATUS = true;
                        dbretailer.CREATED_BY = "Admin";
                        dbretailer.UPDATED_BY = "Admin";
                        dbretailer.CREATED_DATE = DateTime.Now;
                        dbretailer.UPDATED_DATE = DateTime.Now;
                        db.RETAILERS.Add(dbretailer);
                        db.SaveChanges();
                        addR = dbretailer.ID;
                        if (addR > 0)
                        {
                            daouser.AddAdminUser(addR);
                        }
                    }
                    else
                        addR = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addR;
        }

        public int UpdateRetailer(Retailer objretailer)
        {
            int updatep = 0;
            try
            {
                var objr = db.RETAILERS.FirstOrDefault(o => o.ID == objretailer.RetailId);
                if (objr != null)
                {
                    objr.NAME = objretailer.RetailName;
                    objr.DISPLAY_NAME = objretailer.DisplayName;
                    objr.ADDRESS = objretailer.Address;
                    objr.SHOP_NO = objretailer.ShopNo;
                    objr.BUILDING = objretailer.Building;
                    objr.AREA = objretailer.Area;
                    objr.MOBILE = objretailer.Mobile;
                    objr.ALTERNATE_MOB = objretailer.AlternateMob;
                    objr.PIN_CODE = objretailer.PinCode;
                    objr.CITY = objretailer.City;
                    objr.DISTRICT = objretailer.District;
                    objr.STATUS = true;
                    objr.UPDATED_BY = objretailer.UpdatedBy;
                    objr.UPDATED_DATE = DateTime.Now;
                    db.SaveChanges();
                    updatep = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updatep;
        }

    }
}

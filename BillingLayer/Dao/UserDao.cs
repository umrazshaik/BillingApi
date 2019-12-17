using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Common;
using BillingLayer.Model;

namespace BillingLayer.Dao
{
   public class UserDao
    {
        BillingAppDBEntities db = new BillingAppDBEntities();

        public List<Users> GetUsers(int retailerId)
        {
            List<Users> lstusers = null;
            try
            {
                lstusers = (from x in db.USERS
                            where x.RETAIL_ID == retailerId
                            select new Users
                            {
                                UserId=x.ID,
                                UserName=x.NAME,
                                DisplayName=x.DISPLAY_NAME,
                                RetailId=retailerId,
                                RetailName=x.RETAILER.NAME,
                                CreatedBy=x.CREATED_BY,
                                UpdatedBy=x.UPDATED_BY,
                                CreatedDate=x.CREATED_DATE.Value,
                                UpdatedDate=x.UPDATED_DATE.Value,
                                Status=x.STATUS.Value

                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstusers;
        }

        public int AddUser(Users objuser)
        {
            int userid=0;
            try
            {
                USER dbuser = new USER();
                dbuser.NAME = objuser.UserName;
                dbuser.DISPLAY_NAME = objuser.DisplayName;
                dbuser.RETAIL_ID = objuser.RetailId;
                dbuser.STATUS = objuser.Status;
                dbuser.CREATED_BY = objuser.CreatedBy;
                dbuser.UPDATED_BY = objuser.UpdatedBy;
                dbuser.CREATED_DATE = DateTime.Now;
                dbuser.UPDATED_DATE = DateTime.Now;
                db.USERS.Add(dbuser);
                db.SaveChanges();
                userid = dbuser.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userid;
        }

        public int UpdateUser(Users objuser)
        {
            int userupdate=0;
            try
            {
                var obj = db.USERS.FirstOrDefault(o => o.ID == objuser.UserId);
                if(obj!=null)
                {
                    obj.DISPLAY_NAME = objuser.DisplayName;
                    obj.STATUS = objuser.Status;
                    obj.CREATED_BY = objuser.CreatedBy;
                    obj.CREATED_DATE = objuser.CreatedDate;
                    obj.UPDATED_BY = objuser.UserName;
                    objuser.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                    userupdate = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userupdate;
        }

        public int DeleteUser(int userId)
        {
            int userdelete=0;
            try
            {
                var obj = db.USERS.FirstOrDefault(o => o.ID == userId);
                if (obj != null)
                {

                    obj.STATUS = false;
                    db.SaveChanges();
                    userdelete = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userdelete;
        }
    }
}

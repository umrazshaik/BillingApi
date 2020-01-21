using BillingLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingClasses.Common;

namespace BillingLayer.Dao
{
    public class logindao
    {
       private readonly BillingAppDBEntities db =null;

        public logindao()
        {
            db = DataBase.GetInstance;
        }

        public Users LoginUser(Users objuser)
        {
            try
            {
                if (objuser != null)
                {
                    var user = (from x in db.USERS.Where(o => o.NAME == objuser.UserName && o.PASSWORD == objuser.Password)
                                select new Users
                                {
                                    UserName = x.NAME,
                                    DisplayName = x.DISPLAY_NAME,
                                    RetailId = x.RETAIL_ID.Value,
                                    RetailName = x.RETAILER.NAME,
                                    UserId = x.ID,
                                    UserType=x.USER_TYPE,
                                    CreatedBy = x.CREATED_BY
                                }).FirstOrDefault();

                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}

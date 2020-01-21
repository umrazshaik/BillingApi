using BillingLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingLayer.Dao
{
    public sealed class DataBase
    {

        private static readonly Lazy<BillingAppDBEntities> instance = new Lazy<BillingAppDBEntities>(() => new BillingAppDBEntities());

       // private static readonly object obj = new object();
 
        private DataBase()
        {

        }

        public static BillingAppDBEntities GetInstance
        {
            get
            {
                //if (instance == null)
                //{
                //    lock (obj)
                //    {
                //        if (instance == null)
                //            return new BillingAppDBEntities();
                //    }
                //}
                return instance.Value;
            }
        }
    }
}

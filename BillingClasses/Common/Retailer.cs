using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Common
{
    public class Retailer
    {
        public int RetailId { get; set; }

        public string RetailName { get; set; }

        public string DisplayName { get; set; }

        public string Address { get; set; }

        public string ShopNo { get; set; }

        public string Building { get; set; }

        public string Area { get; set; }

        public Int64 Mobile { get; set; }

        public Int64 AlternateMob { get; set; }

        public int PinCode { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

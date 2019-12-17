using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Common
{
   public class Customers
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int  RetailId { get; set; }

        public string RetailName { get; set; }

        public int Mobile { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

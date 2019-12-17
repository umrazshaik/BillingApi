using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Billing
{
   public class Bill
    {
        public BillingInfo BillInfo { get; set; }

        public List<BillingProducts> BillProducts { get; set; }

        public BillingTaxInfo BillTaxInfo { get; set; }
    }
}

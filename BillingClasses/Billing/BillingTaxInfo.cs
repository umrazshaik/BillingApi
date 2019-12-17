using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Billing
{
   public class BillingTaxInfo
    {
        public int BillTaxId { get; set; }

        public int BillId { get; set; }

        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public string  TaxType { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

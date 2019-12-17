using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.TaxCenter
{
   public class Tax
    {
        public int TaxId { get; set; }

        public string TaxName { get; set; }

        public int TaxTypeId { get; set; }

        public string TaxValue { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

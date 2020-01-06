using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Billing
{
    public class BillingInfo
    {
        public int BillId { get; set; }

        public string BillNo { get; set; }

        public int RetailId { get; set; }

        public string RetailName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string CustomerName { get; set; }

        public Int64 CustMobile { get; set; }

        public double BilledAmount { get; set; }

        public double ActualAmount { get; set; }

        public double TaxAmount { get; set; }

        public double PaidAmount { get; set; }

        public string PaymentType { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BillingClasses.Common
{
    public class Cart
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public int RetailerId { get; set; }

        public int? UserId { get; set; }

        public int Quantity { get; set; }

        public double TaxAmount { get; set; }

        public double CGST { get; set; }

        public double SGST { get; set; }

        public int CGSTPercentage { get; set; }

        public int SGSTPercentage { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}

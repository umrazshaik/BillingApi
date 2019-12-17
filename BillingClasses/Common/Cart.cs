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

        public int RetailerId { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }

        public double TaxAmount { get; set; }

        public double CGST { get; set; }

        public double SGST { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Product
{
    public  class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int RetailId { get; set; }

        public string RetailName { get; set; }

        public double ActualCost { get; set; }

        public double SellingCost { get; set; }

        public int SGST { get; set; }

        public int CGST { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

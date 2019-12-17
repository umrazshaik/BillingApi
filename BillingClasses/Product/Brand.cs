using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Product
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int RetailId { get; set; }

        public string RetailName { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

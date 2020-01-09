using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Reports
{
   public class PaymentReport
    {
        public double Cash { get; set; }
        
        public double Card { get; set; }

        public double Online { get; set; }
    }

    public class DaywiseReport
    {
        public double Weekly { get; set; }

        public double Monthly { get; set; }

        public double Annualy { get; set; }
    }
}

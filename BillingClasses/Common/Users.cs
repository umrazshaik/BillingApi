using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingClasses.Common
{
   public class Users
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public int RetailId { get; set; }

        public string RetailName { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}

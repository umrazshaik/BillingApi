//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BillingLayer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILLING_INFO
    {
        public int ID { get; set; }
        public Nullable<int> BILL_ID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> PRODUCT_ID { get; set; }
        public Nullable<double> PRICE { get; set; }
        public Nullable<double> TAX { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    
        public virtual BILLING BILLING { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}

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
    
    public partial class PRODUCT_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT_TYPE()
        {
            this.PRODUCTS = new HashSet<PRODUCT>();
        }
    
        public int ID { get; set; }
        public Nullable<int> RETAIL_ID { get; set; }
        public string TYPE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    
        public virtual RETAILER RETAILER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}

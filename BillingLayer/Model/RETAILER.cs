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
    
    public partial class RETAILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RETAILER()
        {
            this.BILLINGS = new HashSet<BILLING>();
            this.BRANDS = new HashSet<BRAND>();
            this.CARTs = new HashSet<CART>();
            this.CUSTOMERS = new HashSet<CUSTOMER>();
            this.PRODUCT_TYPE = new HashSet<PRODUCT_TYPE>();
            this.USERS = new HashSet<USER>();
            this.PRODUCTS = new HashSet<PRODUCT>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DISPLAY_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string SHOP_NO { get; set; }
        public string BUILDING { get; set; }
        public string AREA { get; set; }
        public Nullable<long> MOBILE { get; set; }
        public Nullable<long> ALTERNATE_MOB { get; set; }
        public Nullable<int> PIN_CODE { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BRAND> BRANDS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_TYPE> PRODUCT_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationProject1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesTransaction
    {
        public int Product_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Invoice_No { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> Total { get; set; }
        public int Transaction_ID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}

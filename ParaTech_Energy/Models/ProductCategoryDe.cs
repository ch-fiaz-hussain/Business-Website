//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParaTech_Energy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCategoryDe
    {
        public int ID { get; set; }
        public int ProductcatID { get; set; }
        public string ProDesc { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
    }
}

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
    
    public partial class SolarPackageD
    {
        public int DID { get; set; }
        public string TitleD { get; set; }
        public string SubtitleD { get; set; }
        public string DescripD { get; set; }
        public string ImageD { get; set; }
        public int MID { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<bool> ForHome { get; set; }
    
        public virtual SolarPackageM SolarPackageM { get; set; }
    }
}

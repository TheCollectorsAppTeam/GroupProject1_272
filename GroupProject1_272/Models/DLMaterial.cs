//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupProject1_272.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DLMaterial
    {
        public int DLMaterial_ID { get; set; }
        public string DLMaterial_Description { get; set; }
        public string Condition { get; set; }
        public int DL_ID { get; set; }
        public Nullable<int> Material_ID { get; set; }
    
        public virtual Donation_Line Donation_Line { get; set; }
        public virtual Material Material { get; set; }
    }
}

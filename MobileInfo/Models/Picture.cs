//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileInfo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        public int Id { get; set; }
        public byte[] Picture1 { get; set; }
        public int MobileId { get; set; }
    
        public virtual Mobile Mobile { get; set; }
    }
}

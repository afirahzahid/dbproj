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
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Web;
	using System.Web.Mvc;

	public partial class Mobile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mobile()
        {
            this.Pictures = new HashSet<Picture>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public string UI { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public string SIM { get; set; }
        public string Colors { get; set; }
        public string C2G_Band { get; set; }
        public string C3G_Band { get; set; }
        public string C4G_Band { get; set; }
        public string CPU { get; set; }
        public string Chipset { get; set; }
        public string GPU { get; set; }
        public string Technology { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string Built_in_Memory { get; set; }
        public string Card { get; set; }
        public string Main_Camera { get; set; }
        public string Camera_Description { get; set; }
        public string Features { get; set; }
        public string Front_Camera { get; set; }
        public string WLAN { get; set; }
        public string Bluetooth { get; set; }
        public string GPS { get; set; }
        public string USB { get; set; }
        public string NFC { get; set; }
        public string Data { get; set; }
        public string Sensors { get; set; }
        public string Audio { get; set; }
        public string Browser { get; set; }
        public string Messaging { get; set; }
        public string Games { get; set; }
        public string Torch { get; set; }
        public string Extra { get; set; }
        public string Battery { get; set; }
        public long Price { get; set; }
        public Nullable<System.DateTime> Announced_On { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public string Picture { get; set; }
    
		[NotMapped]
		public List<Brand> BrandCollection { get; set; }

		public HttpPostedFileBase ImageFile1 { get; set; }

		public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

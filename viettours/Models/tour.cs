//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace viettours.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tour()
        {
            this.dattours = new HashSet<dattour>();
        }

        public int id { get; set; }
        [DisplayName("T�n tour")]
        public string name { get; set; }
        public string anh { get; set; }
        public Nullable<int> thoigian { get; set; }
        public string khoihanh { get; set; }
        public string phuongtien { get; set; }
        public Nullable<int> gia { get; set; }
        public Nullable<int> dacdiem { get; set; }
        public Nullable<int> chitiet { get; set; }
        public Nullable<int> loai { get; set; }

        public virtual tourNN tourNN { get; set; }
        public virtual tourTN tourTN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dattour> dattours { get; set; }
    }
}
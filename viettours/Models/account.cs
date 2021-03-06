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

    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            this.dattours = new HashSet<dattour>();
        }
        public int id { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [RegularExpression("([a-zA-Z0-9]+)", ErrorMessage = "Tên đăng nhập không đúng định dạng")]
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Password không được để trống")]
        [RegularExpression("(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,30}", ErrorMessage = "Mật khẩu phải có  1 chữ hoa 1 chữ thường, sô và ít nhất 8 kí tự")]
        [DisplayName("Password")]
        public string pass { get; set; }

        [StringLength(50)]
        //[Required(ErrorMessage = "Email không được để trống")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Email không đúng định dạng")]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(50)]
        //[Required(ErrorMessage = "Địa chỉ không được để trống")]
        [RegularExpression("([a-z0-9A-Z_ãáàảạẽéèẻẹũúùủụõóòỏọĩíìỉịẫấầẩậễếềểệữứừửựỗốồổộỹýỳỷỵẵắằẳặỡớờởợâăêôươÃÁÀẢẠẼÉÈẺẸŨÚÙỦỤÕÓÒỎỌĨÍÌỈỊẪẤẦẨẬỄẾỀỂỆỮỨỪỬỰỖỐỒỔỘỸÝỲỶỴẴẮẰẲẶỠỚỜỞỢÂĂÊÔƯƠ, ().&\"'-–]+)", ErrorMessage = "Địa chỉ không đúng định dạng")]
        [DisplayName("Địa chỉ")]
        public string diachi { get; set; }
        public Nullable<int> quyenhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dattour> dattours { get; set; }
    }
}

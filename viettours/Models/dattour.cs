﻿//------------------------------------------------------------------------------
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
    public partial class dattour
    {

        [Required(ErrorMessage = "Mã đặt tour không được để trống")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Mã đặt tour không đúng định dạng")]
        [DisplayName("Mã đặt tour")]
        public int id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Họ Tên không được để trống")]
        [RegularExpression("([a-z0-9A-Z_ãáàảạẽéèẻẹũúùủụõóòỏọĩíìỉịẫấầẩậễếềểệữứừửựỗốồổộỹýỳỷỵẵắằẳặỡớờởợâăêôươÃÁÀẢẠẼÉÈẺẸŨÚÙỦỤÕÓÒỎỌĨÍÌỈỊẪẤẦẨẬỄẾỀỂỆỮỨỪỬỰỖỐỒỔỘỸÝỲỶỴẴẮẰẲẶỠỚỜỞỢÂĂÊÔƯƠ, ().&\"'-–]+)", ErrorMessage = "Họ Tên không đúng định dạng")]
        [DisplayName("Họ Tên")]
        public string ten { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email không được để trống")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Email không đúng định dạng")]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [RegularExpression("[0-9]{10,12}", ErrorMessage = "Điện thoại phải có ít nhất 10 số")]
        [DisplayName("Điện thoại")]
        public string tel { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "ĐDDĐ không được để trống")]
        [RegularExpression("[0-9]+", ErrorMessage = "ĐDDĐ không phải có ít nhất 10 số")]
        [DisplayName("ĐDDĐ")]
        public string mobile { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [RegularExpression("([a-z0-9A-Z_ãáàảạẽéèẻẹũúùủụõóòỏọĩíìỉịẫấầẩậễếềểệữứừửựỗốồổộỹýỳỷỵẵắằẳặỡớờởợâăêôươÃÁÀẢẠẼÉÈẺẸŨÚÙỦỤÕÓÒỎỌĨÍÌỈỊẪẤẦẨẬỄẾỀỂỆỮỨỪỬỰỖỐỒỔỘỸÝỲỶỴẴẮẰẲẶỠỚỜỞỢÂĂÊÔƯƠ, ().&\"'-–]+)", ErrorMessage = "Địa chỉ không đúng định dạng")]
        [DisplayName("Địa chỉ")]
        public string addr { get; set; }

        [DisplayName("Quốc Gia")]
        public string quocgia { get; set; }

        public int tour_id { get; set; }

        [DisplayName("Ngày khởi hành")]
        public System.DateTime start { get; set; }

        [DisplayName("Số người")]
        public int songuoi { get; set; }
        [DisplayName("Người lớn")]
        public Nullable<int> nguoilon { get; set; }
        [DisplayName("Trẻ em dưới 2 tuổi")]
        public Nullable<int> treem_2 { get; set; }
        [DisplayName("Trẻ em dưới 12 tuổi")]
        public Nullable<int> treem_12 { get; set; }

        [DisplayName("Loại phòng")]
        public string loaipid { get; set; }
        [DisplayName("Phòng đơn")]
        public Nullable<int> phong1 { get; set; }
        [DisplayName("Phòng đôi")]
        public Nullable<int> phong2 { get; set; }
        [DisplayName("Phòng ba")]
        public Nullable<int> phong3 { get; set; }
        [DisplayName("Hướng dẫn")]
        public string huongdan_id { get; set; }
        public Nullable<int> acc_id { get; set; }

        public virtual account account { get; set; }
        public virtual tour tour { get; set; }
    }
}
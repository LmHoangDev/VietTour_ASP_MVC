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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class viettoursDBEntities : DbContext
    {
        public viettoursDBEntities()
            : base("name=viettoursDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<danhmuc> danhmucs { get; set; }
        public virtual DbSet<danhmuccon> danhmuccons { get; set; }
        public virtual DbSet<huongdan> huongdans { get; set; }
        public virtual DbSet<lienhe> lienhes { get; set; }
        public virtual DbSet<loaiphong> loaiphongs { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<tour> tours { get; set; }
        public virtual DbSet<tourNN> tourNNs { get; set; }
        public virtual DbSet<tourTN> tourTNs { get; set; }
        public virtual DbSet<dattour> dattours { get; set; }
    
        public virtual int danhmuc_delete(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("danhmuc_delete", idParameter);
        }
    
        public virtual ObjectResult<danhmuc_loai_Result> danhmuc_loai(Nullable<int> loai)
        {
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuc_loai_Result>("danhmuc_loai", loaiParameter);
        }
    
        public virtual ObjectResult<danhmuc> danhmuc_select(Nullable<int> loai)
        {
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuc>("danhmuc_select", loaiParameter);
        }
    
        public virtual ObjectResult<danhmuc> danhmuc_select(Nullable<int> loai, MergeOption mergeOption)
        {
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuc>("danhmuc_select", mergeOption, loaiParameter);
        }
    
        public virtual int danhmuc_update(string id, string name, string mota, Nullable<int> type, string danhmuccha)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var motaParameter = mota != null ?
                new ObjectParameter("mota", mota) :
                new ObjectParameter("mota", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var danhmucchaParameter = danhmuccha != null ?
                new ObjectParameter("danhmuccha", danhmuccha) :
                new ObjectParameter("danhmuccha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("danhmuc_update", idParameter, nameParameter, motaParameter, typeParameter, danhmucchaParameter);
        }
    
        public virtual ObjectResult<danhmuccon_select_all_Result> danhmuccon_select_all()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuccon_select_all_Result>("danhmuccon_select_all");
        }
    
        public virtual int tour_delete(Nullable<int> id, Nullable<int> loai)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tour_delete", idParameter, loaiParameter);
        }
    
        public virtual int tour_insert(string name, string anh, Nullable<int> thoigian, string khoihanh, string phuongtien, Nullable<int> gia, Nullable<int> dacdiem, Nullable<int> chitiet, Nullable<int> loai, string danhmuc1, string danhmuc2)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var anhParameter = anh != null ?
                new ObjectParameter("anh", anh) :
                new ObjectParameter("anh", typeof(string));
    
            var thoigianParameter = thoigian.HasValue ?
                new ObjectParameter("thoigian", thoigian) :
                new ObjectParameter("thoigian", typeof(int));
    
            var khoihanhParameter = khoihanh != null ?
                new ObjectParameter("khoihanh", khoihanh) :
                new ObjectParameter("khoihanh", typeof(string));
    
            var phuongtienParameter = phuongtien != null ?
                new ObjectParameter("phuongtien", phuongtien) :
                new ObjectParameter("phuongtien", typeof(string));
    
            var giaParameter = gia.HasValue ?
                new ObjectParameter("gia", gia) :
                new ObjectParameter("gia", typeof(int));
    
            var dacdiemParameter = dacdiem.HasValue ?
                new ObjectParameter("dacdiem", dacdiem) :
                new ObjectParameter("dacdiem", typeof(int));
    
            var chitietParameter = chitiet.HasValue ?
                new ObjectParameter("chitiet", chitiet) :
                new ObjectParameter("chitiet", typeof(int));
    
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            var danhmuc1Parameter = danhmuc1 != null ?
                new ObjectParameter("danhmuc1", danhmuc1) :
                new ObjectParameter("danhmuc1", typeof(string));
    
            var danhmuc2Parameter = danhmuc2 != null ?
                new ObjectParameter("danhmuc2", danhmuc2) :
                new ObjectParameter("danhmuc2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tour_insert", nameParameter, anhParameter, thoigianParameter, khoihanhParameter, phuongtienParameter, giaParameter, dacdiemParameter, chitietParameter, loaiParameter, danhmuc1Parameter, danhmuc2Parameter);
        }
    
        public virtual ObjectResult<tour_manage_Result> tour_manage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tour_manage_Result>("tour_manage");
        }
    
        public virtual ObjectResult<tour> tour_select(Nullable<int> loai, string id_danhmuc)
        {
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            var id_danhmucParameter = id_danhmuc != null ?
                new ObjectParameter("id_danhmuc", id_danhmuc) :
                new ObjectParameter("id_danhmuc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tour>("tour_select", loaiParameter, id_danhmucParameter);
        }
    
        public virtual ObjectResult<tour> tour_select(Nullable<int> loai, string id_danhmuc, MergeOption mergeOption)
        {
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            var id_danhmucParameter = id_danhmuc != null ?
                new ObjectParameter("id_danhmuc", id_danhmuc) :
                new ObjectParameter("id_danhmuc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tour>("tour_select", mergeOption, loaiParameter, id_danhmucParameter);
        }
    
        public virtual int tour_update(Nullable<int> id, string name, string anh, Nullable<int> thoigian, string khoihanh, string phuongtien, Nullable<int> gia, Nullable<int> dacdiem, Nullable<int> chitiet, Nullable<int> loai, string danhmuc1, string danhmuc2)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var anhParameter = anh != null ?
                new ObjectParameter("anh", anh) :
                new ObjectParameter("anh", typeof(string));
    
            var thoigianParameter = thoigian.HasValue ?
                new ObjectParameter("thoigian", thoigian) :
                new ObjectParameter("thoigian", typeof(int));
    
            var khoihanhParameter = khoihanh != null ?
                new ObjectParameter("khoihanh", khoihanh) :
                new ObjectParameter("khoihanh", typeof(string));
    
            var phuongtienParameter = phuongtien != null ?
                new ObjectParameter("phuongtien", phuongtien) :
                new ObjectParameter("phuongtien", typeof(string));
    
            var giaParameter = gia.HasValue ?
                new ObjectParameter("gia", gia) :
                new ObjectParameter("gia", typeof(int));
    
            var dacdiemParameter = dacdiem.HasValue ?
                new ObjectParameter("dacdiem", dacdiem) :
                new ObjectParameter("dacdiem", typeof(int));
    
            var chitietParameter = chitiet.HasValue ?
                new ObjectParameter("chitiet", chitiet) :
                new ObjectParameter("chitiet", typeof(int));
    
            var loaiParameter = loai.HasValue ?
                new ObjectParameter("loai", loai) :
                new ObjectParameter("loai", typeof(int));
    
            var danhmuc1Parameter = danhmuc1 != null ?
                new ObjectParameter("danhmuc1", danhmuc1) :
                new ObjectParameter("danhmuc1", typeof(string));
    
            var danhmuc2Parameter = danhmuc2 != null ?
                new ObjectParameter("danhmuc2", danhmuc2) :
                new ObjectParameter("danhmuc2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tour_update", idParameter, nameParameter, anhParameter, thoigianParameter, khoihanhParameter, phuongtienParameter, giaParameter, dacdiemParameter, chitietParameter, loaiParameter, danhmuc1Parameter, danhmuc2Parameter);
        }
    
        public virtual ObjectResult<danhmuc> danhmuccha_select()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuc>("danhmuccha_select");
        }
    
        public virtual ObjectResult<danhmuc> danhmuccha_select(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuc>("danhmuccha_select", mergeOption);
        }
    
        public virtual ObjectResult<danhmuccon_select_Result> danhmuccon_select()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<danhmuccon_select_Result>("danhmuccon_select");
        }
    
        public virtual int danhmuc_insert(string id, string name, string mota, Nullable<int> type, string danhmuccha)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var motaParameter = mota != null ?
                new ObjectParameter("mota", mota) :
                new ObjectParameter("mota", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var danhmucchaParameter = danhmuccha != null ?
                new ObjectParameter("danhmuccha", danhmuccha) :
                new ObjectParameter("danhmuccha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("danhmuc_insert", idParameter, nameParameter, motaParameter, typeParameter, danhmucchaParameter);
        }
    }
}
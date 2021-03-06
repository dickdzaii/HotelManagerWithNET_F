﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagerWithNET_F.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HotelEntities : DbContext
    {
        public HotelEntities()
            : base("name=HotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CoSoVatChatPhong> CoSoVatChatPhong { get; set; }
        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhong { get; set; }
        public virtual DbSet<DatDichVu> DatDichVu { get; set; }
        public virtual DbSet<DatPhong> DatPhong { get; set; }
        public virtual DbSet<DichVu> DichVu { get; set; }
        public virtual DbSet<DichVuRieng> DichVuRieng { get; set; }
        public virtual DbSet<GiaDichVu> GiaDichVu { get; set; }
        public virtual DbSet<GiaPhong> GiaPhong { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhong { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TraPhong> TraPhong { get; set; }
    
        public virtual int capnhatgiaphong(Nullable<int> maphong, Nullable<int> gia)
        {
            var maphongParameter = maphong.HasValue ?
                new ObjectParameter("maphong", maphong) :
                new ObjectParameter("maphong", typeof(int));
    
            var giaParameter = gia.HasValue ?
                new ObjectParameter("gia", gia) :
                new ObjectParameter("gia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("capnhatgiaphong", maphongParameter, giaParameter);
        }
    
        public virtual ObjectResult<chitietdichvu_Result> chitietdichvu(Nullable<int> madichvu)
        {
            var madichvuParameter = madichvu.HasValue ?
                new ObjectParameter("madichvu", madichvu) :
                new ObjectParameter("madichvu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<chitietdichvu_Result>("chitietdichvu", madichvuParameter);
        }
    
        public virtual ObjectResult<chitietphong_Result> chitietphong(Nullable<int> maphong)
        {
            var maphongParameter = maphong.HasValue ?
                new ObjectParameter("maphong", maphong) :
                new ObjectParameter("maphong", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<chitietphong_Result>("chitietphong", maphongParameter);
        }
    
        public virtual ObjectResult<dichvubyid_Result> dichvubyid(Nullable<int> ma)
        {
            var maParameter = ma.HasValue ?
                new ObjectParameter("ma", ma) :
                new ObjectParameter("ma", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<dichvubyid_Result>("dichvubyid", maParameter);
        }
    
        public virtual ObjectResult<getphongwithloai_Result> getphongwithloai(Nullable<int> maloai)
        {
            var maloaiParameter = maloai.HasValue ?
                new ObjectParameter("maloai", maloai) :
                new ObjectParameter("maloai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getphongwithloai_Result>("getphongwithloai", maloaiParameter);
        }
    
        public virtual ObjectResult<loaiphongbyid_Result> loaiphongbyid(Nullable<int> ma)
        {
            var maParameter = ma.HasValue ?
                new ObjectParameter("ma", ma) :
                new ObjectParameter("ma", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<loaiphongbyid_Result>("loaiphongbyid", maParameter);
        }
    
        public virtual ObjectResult<phongbyid_Result> phongbyid(Nullable<int> ma)
        {
            var maParameter = ma.HasValue ?
                new ObjectParameter("ma", ma) :
                new ObjectParameter("ma", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<phongbyid_Result>("phongbyid", maParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int ThemKhachHang(string ten, Nullable<System.DateTime> ngaysinh, Nullable<int> gioitinh, string diachi, string sdt, string cmt)
        {
            var tenParameter = ten != null ?
                new ObjectParameter("ten", ten) :
                new ObjectParameter("ten", typeof(string));
    
            var ngaysinhParameter = ngaysinh.HasValue ?
                new ObjectParameter("ngaysinh", ngaysinh) :
                new ObjectParameter("ngaysinh", typeof(System.DateTime));
    
            var gioitinhParameter = gioitinh.HasValue ?
                new ObjectParameter("gioitinh", gioitinh) :
                new ObjectParameter("gioitinh", typeof(int));
    
            var diachiParameter = diachi != null ?
                new ObjectParameter("diachi", diachi) :
                new ObjectParameter("diachi", typeof(string));
    
            var sdtParameter = sdt != null ?
                new ObjectParameter("sdt", sdt) :
                new ObjectParameter("sdt", typeof(string));
    
            var cmtParameter = cmt != null ?
                new ObjectParameter("Cmt", cmt) :
                new ObjectParameter("Cmt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ThemKhachHang", tenParameter, ngaysinhParameter, gioitinhParameter, diachiParameter, sdtParameter, cmtParameter);
        }
    }
}

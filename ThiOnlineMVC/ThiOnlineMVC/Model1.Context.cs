﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiOnlineMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThiOnlineEntities : DbContext
    {
        public ThiOnlineEntities()
            : base("name=ThiOnlineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaiThi> BaiThis { get; set; }
        public virtual DbSet<BaiThi_DapAn> BaiThi_DapAn { get; set; }
        public virtual DbSet<CaThi> CaThis { get; set; }
        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<ChuongHoc> ChuongHocs { get; set; }
        public virtual DbSet<DeThi_CauHoi> DeThi_CauHoi { get; set; }
        public virtual DbSet<DoanVan> DoanVans { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<KyThi> KyThis { get; set; }
        public virtual DbSet<DoKho> DoKhoes { get; set; }
        public virtual DbSet<DeThi> DeThis { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
    }
}
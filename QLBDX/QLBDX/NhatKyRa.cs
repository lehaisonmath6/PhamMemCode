//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBDX
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhatKyRa
    {
        public int IDNhatKyRa { get; set; }
        public Nullable<int> ThoiGian { get; set; }
        public string BienSoXe { get; set; }
        public Nullable<int> IDLoaiXe { get; set; }
        public Nullable<int> IDTheGuiXe { get; set; }
        public string IDNhanVien { get; set; }
        public string Urlanh { get; set; }
    
        public virtual LoaiXe LoaiXe { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual TheGuiXe TheGuiXe { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfQLSpa
{
    using System;
    using System.Collections.Generic;
    
    public partial class LieuTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LieuTrinh()
        {
            this.LichLieuTrinhs = new HashSet<LichLieuTrinh>();
        }
    
        public int IDLieuTrinh { get; set; }
        public Nullable<int> IDDichVu { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> HoaHong { get; set; }
        public Nullable<int> TongSoBuoi { get; set; }
        public Nullable<int> SoBuoiDaSuDung { get; set; }
        public Nullable<int> TongTien { get; set; }
        public Nullable<System.DateTime> NgayMua { get; set; }
        public Nullable<int> SoTienDaThanhToan { get; set; }
        public Nullable<int> SoTienChuaThanhToan { get; set; }
        public string IDKhachhang { get; set; }
        public string IDNhanVien { get; set; }
    
        public virtual DichVu DichVu { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichLieuTrinh> LichLieuTrinhs { get; set; }
    }
}

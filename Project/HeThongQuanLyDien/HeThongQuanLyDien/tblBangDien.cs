using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyDien
{
    [Serializable()]
    public class tblBangDien
    {
        public string SoDien { get; set; }
        public string SoNhom { get; set; }
        public string NoiDung { get; set; }
        public string DoKhan { get; set; }
        public string SoLanPhat { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<bool> PhatTuDong { get; set; }
        public string NguoiPhat { get; set; }
        public int IDMay { get; set; }
    }
}

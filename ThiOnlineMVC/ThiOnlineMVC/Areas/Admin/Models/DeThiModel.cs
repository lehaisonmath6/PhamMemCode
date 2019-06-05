using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiOnlineMVC.Areas.Admin.Models
{
    public class DeThiModel
    {
        public int IDDeThi { get; set; }
        public Nullable<int> IDMonHoc { get; set; }
        public string MoTa { get; set; }
        public string ThoiGian { get; set; }
        public string TenDe { get; set; }
        public Nullable<int> IDCaThi { get; set; }
        public string DSIDCauHoi { get; set; }


    }
}
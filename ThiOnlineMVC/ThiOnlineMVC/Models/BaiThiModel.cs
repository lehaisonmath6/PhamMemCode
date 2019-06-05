using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiOnlineMVC.Models
{
    public class BaiThiModel
    {
        public int IDCauHoi { get; set; }
        public string CauTraLoi { get; set; }
        public string DapAn { get; set; }
        public bool isCorrect { get; set; }
        public int IDDeThi { get; set; }
        public int IDCaThi { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfQLSpa
{
    /// <summary>
    /// Interaction logic for TrangChuUC.xaml
    /// </summary>
    public partial class TrangChuUC : UserControl
    {
        public TrangChuUC()
        {
            InitializeComponent();
        }
        


        private LichHen _lichhenSelected;
        private LichLieuTrinh _lichLieuTrinhSelected;


     

    

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtThoiGianHienTai.Text = DateTime.Now.ToLongDateString();
            txtThoiGianHienTai2.Text = txtThoiGianHienTai.Text;
            //lsvDataHen.ItemsSource = new ObservableCollection<LichHen>(DataProvider.Instance.DB.LichHens);
            //lsvDataHen.ItemsSource = new ObservableCollection<LichLieuTrinh>(DataProvider.Instance.DB.LichLieuTrinhs);
            lsvDataHen.ItemsSource = new ObservableCollection<LichHen>(DataProvider.Instance.DB.LichHens.Where(n => n.IDTrangThaiHen == 1).OrderBy(n => n.ThoiGianHen));
            lsvDataDieuTri.ItemsSource = new ObservableCollection<LichLieuTrinh>(DataProvider.Instance.DB.LichLieuTrinhs.Where(n => n.DaThucHien == false).OrderBy(n => n.ThoiGianDieuTri));
        }
        
        private void BtnSMSLichHen_Click(object sender, RoutedEventArgs e)
        {
            var phonenumber = _lichhenSelected.KhachHang.SDT;
            string thoigianhen = _lichhenSelected.ThoiGianHen.Value.ToShortDateString();
            var mess = ConfigurationManager.AppSettings["SMSContent"] + " vào lúc "+ thoigianhen;
            int rs = SMSHelper.SendJson(phonenumber, mess);
            if(rs == 100)
            {
                MessageBox.Show("Gửi thành công");
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
            //SMSHelper.SendJson
        }

        private void BtnSMSLichDieuTri_Click(object sender, RoutedEventArgs e)
        {
            var phonenumber = _lichLieuTrinhSelected.LieuTrinh.KhachHang.SDT;
            var thoigian = _lichLieuTrinhSelected.ThoiGianDieuTri.Value.ToLongDateString();
            var mess = "Quy khach co buoi dieu tri tai  spa cua chung toi vao luc " + thoigian;
            int rs = SMSHelper.SendJson(phonenumber, mess);
            if(rs == 100)
            {
                MessageBox.Show("Gửi thành công");
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
        }

        private void LsvDataHen_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _lichhenSelected = item as LichHen;
            if (_lichhenSelected == null)
            {
               
                return;
            }
            txtThoiGianHienTai.Text = _lichhenSelected.KhachHang.IDKhachHang;
        }

        private void LsvDataDieuTri_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _lichLieuTrinhSelected = item as LichLieuTrinh;
            if (_lichLieuTrinhSelected == null)
            {
                return;
            }
            txtThoiGianHienTai2.Text = _lichLieuTrinhSelected.LieuTrinh.KhachHang.IDKhachHang;
        }
    }
}

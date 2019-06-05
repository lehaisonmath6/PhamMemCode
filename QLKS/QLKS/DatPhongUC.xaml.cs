using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QLKS
{
    /// <summary>
    /// Interaction logic for DatPhongUC.xaml
    /// </summary>
    public partial class DatPhongUC : UserControl
    {
        public DatPhongUC()
        {
            InitializeComponent();
        }

        private void BtnTimPhong_Click(object sender, RoutedEventArgs e)
        {

        }


        tblPhong _phongSelected;
        private void LsvPhong_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _phongSelected = item as tblPhong;
            if (_phongSelected == null)
            {
                return;
            }

            cboSoPhong.SelectedValue = _phongSelected.IDPhong;
        }

        private void BtnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tblDatPhong datPhong = new tblDatPhong();
                datPhong.IDPhong = (int)cboSoPhong.SelectedValue;
                datPhong.ThoiGianBatDau = pdNgayBatDauDat.SelectedDate;
                datPhong.ThoiGianKetThuc = pdNgayKetThucDat.SelectedDate;
                datPhong.TongTien = int.Parse(txtTongTien.Text);
                datPhong.TienDaCoc = int.Parse(txtTienDaDatCoc.Text);
                datPhong.TenKhachHang = txtTenKhachHang.Text;
                datPhong.SDT = txtSDT.Text;
                datPhong.MoTa = txtMoTa.Text;
                tblPhong phong = DataProvider.Instance.DB.tblPhongs.SingleOrDefault(n => n.IDPhong == datPhong.IDPhong);
                phong.IDTrangThaiPhong = 2;
                DataProvider.Instance.DB.tblDatPhongs.Add(datPhong);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Đặt phòng thành công");
                UserControl_Loaded(null, null);
            }
            catch
            {
                MessageBox.Show("Yêu cầu nhập đúng thông tin");
            }
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lsvPhong.ItemsSource = new ObservableCollection<tblPhong>(DataProvider.Instance.DB.tblPhongs);
            cboSoPhong.ItemsSource = new ObservableCollection<tblPhong>(DataProvider.Instance.DB.tblPhongs.Where(n=>n.IDTrangThaiPhong==3));
            txtIDDatPhong.Text = "auto";
            txtIDDatPhong.IsReadOnly = true;
            cboSoPhong.SelectedValuePath = "IDPhong";
            cboSoPhong.DisplayMemberPath = "IDPhong";

       
        }
    }
}

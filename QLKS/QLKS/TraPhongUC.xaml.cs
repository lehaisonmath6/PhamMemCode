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
    /// Interaction logic for TraPhongUC.xaml
    /// </summary>
    public partial class TraPhongUC : UserControl
    {
        public TraPhongUC()
        {
            InitializeComponent();
        }

        private void CboSoPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idphong = (int)cboSoPhong.SelectedValue;
            tblDatPhong datPhong = DataProvider.Instance.DB.tblDatPhongs.Where(n => n.IDPhong == idphong).OrderByDescending(n => n.ThoiGianBatDau).FirstOrDefault();
            if(datPhong == null)
            {
                return;
            }
            txtIDDatPhong.Text = datPhong.IDDatPhong.ToString();
            txtMoTa.Text = datPhong.MoTa;
            txtSDT.Text = datPhong.SDT;
            txtTenKhachHang.Text = datPhong.TenKhachHang;
            txtTienDaDatCoc.Text = datPhong.TienDaCoc.ToString();
            txtTongTien.Text = datPhong.TongTien.ToString();
            txtTienThanhToan.Text = (datPhong.TongTien - datPhong.TienDaCoc).ToString();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtIDDatPhong.IsReadOnly = true;
            txtMoTa.IsReadOnly = true;
            txtSDT.IsReadOnly = true;
            txtTenKhachHang.IsReadOnly = true;
            txtTienThanhToan.IsReadOnly = true;
            txtTienDaDatCoc.IsReadOnly = true;
            txtTongTien.IsReadOnly = true;
           
            cboSoPhong.ItemsSource = new ObservableCollection<tblPhong>(DataProvider.Instance.DB.tblPhongs.Where(n => n.IDTrangThaiPhong == 2));
            cboSoPhong.DisplayMemberPath = "IDPhong";
            cboSoPhong.SelectedValuePath = "IDPhong";
        }

        private void BtnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.IDDatPhong = int.Parse(txtIDDatPhong.Text);
            hoaDon.HoTenKhach = txtTenKhachHang.Text;
            hoaDon.IDPhong = int.Parse(cboSoPhong.Text);
            hoaDon.MoTa = txtMoTa.Text;
            hoaDon.ThoiGian = DateTime.Now;
            hoaDon.SDT = txtSDT.Text;
            hoaDon.TongTien = int.Parse(txtTongTien.Text);
            DataProvider.Instance.DB.HoaDons.Add(hoaDon);
            tblPhong phong = DataProvider.Instance.DB.tblPhongs.SingleOrDefault(n => n.IDPhong == hoaDon.IDPhong);
            if(phong == null)
            {
                MessageBox.Show("Không tìm thấy phòng ");
                return;
            }
            phong.IDTrangThaiPhong = 3;
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thanh toán hoàn tất");
        }
    }
}

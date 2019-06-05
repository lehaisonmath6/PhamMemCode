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
    /// Interaction logic for QuanLyDatPhongUC.xaml
    /// </summary>
    public partial class QuanLyDatPhongUC : UserControl
    {
        public QuanLyDatPhongUC()
        {
           
            InitializeComponent();

        }

       

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private tblDatPhong _datphongSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDDatPhong.Text = "auto";
            txtTenKhachHang.Text = "";
            txtTienDaCoc.Text = "";
            txtTongTien.Text = "";
            txtSDT.Text = "";
            txtMoTa.Text = "";
            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Them;
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Sua;
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            userAction = UserAction.Xoa;
            if (MessageBox.Show("Xóa", "Bạn có chắc sẽ xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int iddat = int.Parse(txtIDDatPhong.Text);
                var tblDatPhong = DataProvider.Instance.DB.tblDatPhongs.SingleOrDefault(n => n.IDDatPhong == iddat);
                if (tblDatPhong != null)
                {

                    DataProvider.Instance.DB.tblDatPhongs.Remove(tblDatPhong);
                    DataProvider.Instance.DB.SaveChanges();
                    UserControl_Loaded(null, null);
                    MessageBox.Show("Xóa thành công");

                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }
        }
        private void Them()
        {
            try
            {
                var datPhong = new tblDatPhong();

                datPhong.IDPhong = int.Parse(cboSoPhong.Text);
                datPhong.TenKhachHang = txtTenKhachHang.Text;
                datPhong.TongTien = int.Parse(txtTongTien.Text);
                datPhong.TienDaCoc = int.Parse(txtTienDaCoc.Text);
                datPhong.ThoiGianBatDau = pdThoiGianBatDau.SelectedDate;
                datPhong.ThoiGianKetThuc = pdThoiGianKetThuc.SelectedDate;
                datPhong.MoTa = txtMoTa.Text;
                datPhong.SDT = txtSDT.Text;
                datPhong.IDTrangThaiDat = int.Parse(cboTrangThaiDat.Text);


                DataProvider.Instance.DB.tblDatPhongs.Add(datPhong);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Thêm thành công");

              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Sua()
        {
            int iddatphong = int.Parse(txtIDDatPhong.Text);
            var datPhong = DataProvider.Instance.DB.tblDatPhongs.SingleOrDefault(n => n.IDDatPhong == iddatphong);
            if (datPhong != null)
            {
                datPhong.IDPhong = int.Parse(cboSoPhong.Text);
                datPhong.IDTrangThaiDat = (int)cboTrangThaiDat.SelectedValue;
                datPhong.MoTa = txtMoTa.Text;
                datPhong.SDT = txtSDT.Text;
                datPhong.TenKhachHang = txtTenKhachHang.Text;
                datPhong.TongTien = int.Parse(txtTongTien.Text);
                datPhong.TienDaCoc = int.Parse(txtTienDaCoc.Text);
                datPhong.ThoiGianBatDau = pdThoiGianBatDau.SelectedDate;
                datPhong.ThoiGianKetThuc = pdThoiGianKetThuc.SelectedDate;
               
                datPhong.MoTa = txtMoTa.Text;
                

                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {

            switch (userAction)
            {
                case UserAction.Them:
                    Them();
                    break;
                case UserAction.Sua:
                    Sua();
                    break;
            }
            userAction = UserAction.Luu;
            UserControl_Loaded(null, null);
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
            userAction = UserAction.Huy;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            lsvData.ItemsSource = new ObservableCollection<tblDatPhong>(DataProvider.Instance.DB.tblDatPhongs);
            cboSoPhong.ItemsSource = new ObservableCollection<tblPhong>(DataProvider.Instance.DB.tblPhongs);
            cboTrangThaiDat.ItemsSource = new ObservableCollection<tblTrangThaiDat>(DataProvider.Instance.DB.tblTrangThaiDats);
         

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _datphongSelected = item as tblDatPhong;
            if (_datphongSelected == null)
            {
                return;
            }

            txtIDDatPhong.Text = _datphongSelected.IDDatPhong.ToString();
            txtMoTa.Text = _datphongSelected.MoTa;
            txtSDT.Text = _datphongSelected.SDT;
            txtTienDaCoc.Text = _datphongSelected.TienDaCoc.ToString();
            txtTongTien.Text = _datphongSelected.TongTien.ToString();
            txtTenKhachHang.Text = _datphongSelected.TenKhachHang.ToString();
            pdThoiGianBatDau.SelectedDate = _datphongSelected.ThoiGianBatDau;
            pdThoiGianKetThuc.SelectedDate = _datphongSelected.ThoiGianKetThuc;
            cboSoPhong.SelectedValue = _datphongSelected.IDPhong;
            cboTrangThaiDat.SelectedValue = _datphongSelected.IDTrangThaiDat;
            btnSua.IsEnabled = true;
        }

  
    }
}

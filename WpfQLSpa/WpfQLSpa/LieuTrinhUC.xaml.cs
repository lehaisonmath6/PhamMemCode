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

namespace WpfQLSpa
{
    /// <summary>
    /// Interaction logic for LieuTrinhUC.xaml
    /// </summary>
    public partial class LieuTrinhUC : UserControl
    {
        private ObservableCollection<LieuTrinh> _list;
      

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public LieuTrinhUC()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
            _list = new ObservableCollection<LieuTrinh>(DataProvider.Instance.DB.LieuTrinhs);
            lsvData.ItemsSource = _list;

            cboDichVu.ItemsSource = new ObservableCollection<DichVu>(DataProvider.Instance.DB.DichVus);
            cboDichVu.DisplayMemberPath = "TenDichVu";
            cboDichVu.SelectedValuePath = "IDDichVu";

            cboKhachHang.ItemsSource = new ObservableCollection<KhachHang>(DataProvider.Instance.DB.KhachHangs);
            cboKhachHang.DisplayMemberPath = "IDKhachHang";
            cboKhachHang.SelectedValuePath = "IDKhachHang";

            cboNhanVien.ItemsSource = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            cboNhanVien.DisplayMemberPath = "HoTen";
            cboNhanVien.SelectedValuePath = "IDNhanVien";


            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
            txtIDLieuTrinh.IsReadOnly = true;
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDLieuTrinh.Text = "auto";
            txtHoaHong.Text = "";
            txtSoBuoiDaSuDung.Text = "";
            txtSoTienDaThanhToan.Text = "";
            txtTongSoBuoi.Text = "";
            txtTongTien.Text = "";
            txtMoTa.Text = "";
            txtTongTien.Text = "";

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
                int idlieutrinh = int.Parse(txtIDLieuTrinh.Text);
                var lieutrinh = DataProvider.Instance.DB.LieuTrinhs.SingleOrDefault(n => n.IDLieuTrinh == idlieutrinh);
                if (lieutrinh != null)
                {
                    DataProvider.Instance.DB.LieuTrinhs.Remove(lieutrinh);
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
                var lieuTrinh = new LieuTrinh();
                lieuTrinh.IDKhachhang = (string)cboKhachHang.SelectedValue;
                lieuTrinh.IDNhanVien = (string)cboNhanVien.SelectedValue;
                lieuTrinh.MoTa = txtMoTa.Text;
                lieuTrinh.NgayMua = dpNgayMua.SelectedDate;
                lieuTrinh.TongTien = int.Parse(txtTongTien.Text);
                lieuTrinh.TongSoBuoi = int.Parse(txtTongSoBuoi.Text);
                lieuTrinh.SoTienDaThanhToan = int.Parse(txtSoTienDaThanhToan.Text);
                lieuTrinh.IDDichVu = (int)cboDichVu.SelectedValue;
                lieuTrinh.SoBuoiDaSuDung = int.Parse(txtSoBuoiDaSuDung.Text);
                lieuTrinh.HoaHong = int.Parse(txtHoaHong.Text);
                //lieuTrinh.IDLieuTrinh = 5;

                DataProvider.Instance.DB.LieuTrinhs.Add(lieuTrinh);
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
            try
            {
                int lieutrinhid = int.Parse(txtIDLieuTrinh.Text);
                var lieutrinh = DataProvider.Instance.DB.LieuTrinhs.SingleOrDefault(n => n.IDLieuTrinh == lieutrinhid);

                if (lieutrinh != null)
                {
                    lieutrinh.IDKhachhang = (string)cboKhachHang.SelectedValue;
                    lieutrinh.IDNhanVien = (string)cboNhanVien.SelectedValue;
                    lieutrinh.MoTa = txtMoTa.Text;
                    lieutrinh.NgayMua = dpNgayMua.SelectedDate;
                    lieutrinh.TongTien = int.Parse(txtTongTien.Text);
                    lieutrinh.TongSoBuoi = int.Parse(txtTongSoBuoi.Text);
                    lieutrinh.SoTienDaThanhToan = int.Parse(txtSoTienDaThanhToan.Text);
                    lieutrinh.IDDichVu = (int)cboDichVu.SelectedValue;
                    lieutrinh.SoBuoiDaSuDung = int.Parse(txtSoBuoiDaSuDung.Text);
                    lieutrinh.HoaHong = int.Parse(txtHoaHong.Text);

                    DataProvider.Instance.DB.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        LieuTrinh _lieutrinhSelected;
        

        private void LsvData_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LichLieuTrinhWindow lichLieuTrinhWindow = new LichLieuTrinhWindow(_lieutrinhSelected.IDLieuTrinh);
            lichLieuTrinhWindow.ShowDialog();
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _lieutrinhSelected = item as LieuTrinh;
            if (_lieutrinhSelected == null)
            {
                return;
            }
            txtIDLieuTrinh.Text = _lieutrinhSelected.IDLieuTrinh.ToString();
            txtHoaHong.Text = _lieutrinhSelected.HoaHong.ToString();
            txtMoTa.Text = _lieutrinhSelected.MoTa;
            txtSoBuoiDaSuDung.Text = _lieutrinhSelected.SoBuoiDaSuDung.ToString();
            txtSoTienDaThanhToan.Text = _lieutrinhSelected.SoTienDaThanhToan.ToString();
            txtTongSoBuoi.Text = _lieutrinhSelected.TongSoBuoi.ToString();
            txtTongTien.Text = _lieutrinhSelected.TongTien.ToString();
            cboDichVu.SelectedItem = _lieutrinhSelected.IDDichVu;
            cboKhachHang.SelectedItem = _lieutrinhSelected.IDKhachhang;
            cboNhanVien.SelectedItem = _lieutrinhSelected.IDNhanVien;
            dpNgayMua.SelectedDate = _lieutrinhSelected.NgayMua;
            btnSua.IsEnabled = true;
        }
    }
}

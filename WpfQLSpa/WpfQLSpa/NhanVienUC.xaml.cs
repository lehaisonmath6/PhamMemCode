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
    /// Interaction logic for NhanVienUC.xaml
    /// </summary>
    public partial class NhanVienUC : UserControl
    {
        private static readonly KeyValuePair<int, string>[] tripLengthList = {
        new KeyValuePair<int, string>(0, "Nữ"),
        new KeyValuePair<int, string>(1, "Nam"),
        };
        public NhanVienUC()
        {
            _list = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);

            InitializeComponent();


        }


        private ObservableCollection<NhanVien> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private NhanVien _nhanvienSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDNhanVien.Text = "auto";
            txtHoTen.Text = "";
            txtCMT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";

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

                var nhanvien = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == txtIDNhanVien.Text);
                if (nhanvien != null)
                {
                    DataProvider.Instance.DB.NhanViens.Remove(nhanvien);
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
            double sdt;
            if (!double.TryParse(txtSDT.Text, out sdt))
            {
                MessageBox.Show("Số điện thoại phải là số");
                return;
            }
            if (!double.TryParse(txtCMT.Text, out sdt))
            {
                MessageBox.Show("Chứng minh thư phải là số");
                return;
            }
            try
            {
                var nhanvien = new NhanVien();
                nhanvien.IDNhanVien = "NV" + txtSDT.Text;
                var alreadynv = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == nhanvien.IDNhanVien);
                if (alreadynv != null)
                {
                    MessageBox.Show("Số điện thoại của nhân viên đã tồn tại");
                    return;
                }
                nhanvien.SDT = txtSDT.Text;
                nhanvien.HoTen = txtHoTen.Text;
                nhanvien.GioiTinh = (int)cboGioiTinh.SelectedValue == 0 ? false : true;
                nhanvien.SinhNhat = pdSinhNhat.SelectedDate;
                nhanvien.DiaChi = txtDiaChi.Text;
                nhanvien.CMT = txtCMT.Text;
                nhanvien.Email = txtEmail.Text;
                DataProvider.Instance.DB.NhanViens.Add(nhanvien);
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
            double sdt;
            if (!double.TryParse(txtSDT.Text, out sdt))
            {
                MessageBox.Show("Số điện thoại phải là số");
                return;
            }
            if (!double.TryParse(txtCMT.Text, out sdt))
            {
                MessageBox.Show("Chứng minh thư phải là số");
                return;
            }
            var nhanvien = DataProvider.Instance.DB.NhanViens.SingleOrDefault(n => n.IDNhanVien == txtIDNhanVien.Text);
            if (nhanvien != null)
            {
                nhanvien.HoTen = txtHoTen.Text;
                nhanvien.SDT = txtSDT.Text;
                nhanvien.GioiTinh = (int)cboGioiTinh.SelectedValue == 0 ? false : true;
                nhanvien.SinhNhat = pdSinhNhat.SelectedDate;
                nhanvien.Email = txtEmail.Text;
                nhanvien.CMT = txtCMT.Text;
                nhanvien.DiaChi = txtDiaChi.Text;

                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }
        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Không được để trống họ tên hoặc điện thoại");
                return;
            }
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
            cboGioiTinh.ItemsSource = tripLengthList;
            cboGioiTinh.DisplayMemberPath = "Value";
            cboGioiTinh.SelectedValuePath = "Key";
            txtIDNhanVien.IsReadOnly = true;
            _list = new ObservableCollection<NhanVien>(DataProvider.Instance.DB.NhanViens);
            lsvData.ItemsSource = _list;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _nhanvienSelected = item as NhanVien;
            if (_nhanvienSelected == null)
            {
                return;
            }
            txtIDNhanVien.Text = _nhanvienSelected.IDNhanVien;
            txtHoTen.Text = _nhanvienSelected.HoTen;
            txtEmail.Text = _nhanvienSelected.Email;
            txtSDT.Text = _nhanvienSelected.SDT;
            txtCMT.Text = _nhanvienSelected.CMT;
            txtDiaChi.Text = _nhanvienSelected.DiaChi;
            cboGioiTinh.SelectedValue = _nhanvienSelected.GioiTinh == false ? 0 : 1;
            btnSua.IsEnabled = true;
        }
    }
}

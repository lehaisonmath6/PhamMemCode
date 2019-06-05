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
    /// Interaction logic for KhachHangUC.xaml
    /// </summary>
    public partial class KhachHangUC : UserControl
    {
        private static readonly KeyValuePair<int, string>[] tripLengthList = {
        new KeyValuePair<int, string>(0, "Nữ"),
        new KeyValuePair<int, string>(1, "Nam"),
        };
        public KhachHangUC()
        {
            _list = new ObservableCollection<KhachHang>(DataProvider.Instance.DB.KhachHangs);
           
            InitializeComponent();
           
          
        }
       
        private ObservableCollection<KhachHang> _list;
        
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private KhachHang _khachhangSelected;
       

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDKhachHang.Text = "auto";
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
               
                var khachhang = DataProvider.Instance.DB.KhachHangs.SingleOrDefault(n => n.IDKhachHang == txtIDKhachHang.Text);
                if (khachhang != null)
                {
                    DataProvider.Instance.DB.KhachHangs.Remove(khachhang);
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
            if( !double.TryParse(txtSDT.Text,out sdt))
            {
                MessageBox.Show("Số điện thoại phải là số");
                return;
            }
            if(!double.TryParse(txtCMT.Text,out sdt))
            {
                MessageBox.Show("Chứng minh thư phải là số");
                return;
            }
            try
            {
                var khachhang = new KhachHang();
                khachhang.IDKhachHang = "KH" + txtSDT.Text;
                var alreadykhach = DataProvider.Instance.DB.KhachHangs.SingleOrDefault(n => n.IDKhachHang == khachhang.IDKhachHang);
                if(alreadykhach != null)
                {
                    MessageBox.Show("Số điện thoại của khách đã tồn tại");
                    return;
                }
                khachhang.SDT = txtSDT.Text;
                khachhang.GioiTinh = (int)cboGioiTinh.SelectedValue == 0 ? false : true;
                khachhang.SinhNhat = pdSinhNhat.SelectedDate;
                khachhang.DiaChi = txtDiaChi.Text;
                khachhang.CMT = txtCMT.Text;
                khachhang.Email = txtEmail.Text;
                khachhang.HoTen = txtHoTen.Text;
                DataProvider.Instance.DB.KhachHangs.Add(khachhang);
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

            var khachHang = DataProvider.Instance.DB.KhachHangs.SingleOrDefault(n => n.IDKhachHang == txtIDKhachHang.Text);
            if (khachHang != null)
            {
                khachHang.HoTen = txtHoTen.Text;
                khachHang.SDT = txtSDT.Text;
                khachHang.GioiTinh = (int)cboGioiTinh.SelectedValue == 0 ? false : true;
                khachHang.SinhNhat = pdSinhNhat.SelectedDate;
                khachHang.Email = txtEmail.Text;
                khachHang.CMT = txtCMT.Text;
                khachHang.DiaChi = txtDiaChi.Text;

                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }
        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            if(txtSDT.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại không được quá 10 đơn vị");
                return;
            }

            if(txtHoTen.Text == "" || txtSDT.Text == "")
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
            txtIDKhachHang.IsReadOnly = true;
            _list = new ObservableCollection<KhachHang>(DataProvider.Instance.DB.KhachHangs);
           
            
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
            _khachhangSelected = item as KhachHang;
            if (_khachhangSelected == null)
            {
                return;
            }
            txtIDKhachHang.Text = _khachhangSelected.IDKhachHang;
            txtHoTen.Text = _khachhangSelected.HoTen;
            txtEmail.Text = _khachhangSelected.Email;
            txtSDT.Text = _khachhangSelected.SDT;
            txtCMT.Text = _khachhangSelected.CMT;
            txtDiaChi.Text = _khachhangSelected.DiaChi;
            cboGioiTinh.SelectedValue = _khachhangSelected.GioiTinh == false ? 0 : 1;
            btnSua.IsEnabled = true;
        }

        private void TxtSDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TxtSDT_KeyDown(object sender, KeyEventArgs e)
        {
        
        }
    }
}

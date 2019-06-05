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
using System.Windows.Shapes;

namespace WpfQLSpa
{
    /// <summary>
    /// Interaction logic for DichVuSanPhamWindow.xaml
    /// </summary>
    public partial class DichVuSanPhamWindow : Window
    {
        int iddichvu;
       
        public DichVuSanPhamWindow(int iddichvu)
        {
            this.iddichvu = iddichvu;
            InitializeComponent();
        }

        private ObservableCollection<DichVu_SanPham> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private DichVu_SanPham _dichvuSanPhamSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
           
            //txtTenDichVu.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuong.Text = "";
           

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
                int idsanpham = (int)cboSanPham.SelectedValue;
                var dichvuSanpham = DataProvider.Instance.DB.DichVu_SanPham.SingleOrDefault(n => n.IDDichVu == this.iddichvu && n.IDSanPham ==  idsanpham );
                if (dichvuSanpham != null)
                {
                    DataProvider.Instance.DB.DichVu_SanPham.Remove(dichvuSanpham);
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

                var dichvuSanPham = new DichVu_SanPham();
                dichvuSanPham.IDDichVu = this.iddichvu;
                dichvuSanPham.IDSanPham = (int)cboSanPham.SelectedValue;
                dichvuSanPham.SoLuong = int.Parse(txtSoLuong.Text);
                dichvuSanPham.DonViTinh = txtDonViTinh.Text;
                
                DataProvider.Instance.DB.DichVu_SanPham.Add(dichvuSanPham);
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
            int idsanpham = (int)cboSanPham.SelectedValue;
            var dichvu = DataProvider.Instance.DB.DichVu_SanPham.SingleOrDefault(n => n.IDDichVu == iddichvu && n.IDSanPham == idsanpham);
            if (dichvu != null)
            {
                dichvu.SoLuong = int.Parse(txtSoLuong.Text);
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

           
            _list = new ObservableCollection<DichVu_SanPham>(DataProvider.Instance.DB.DichVu_SanPham.Where(n=>n.IDDichVu==this.iddichvu));


            cboSanPham.ItemsSource = new ObservableCollection<SanPham>(DataProvider.Instance.DB.SanPhams);
            lsvData.ItemsSource = _list;

            txtTenDichVu.Text = DataProvider.Instance.DB.DichVus.SingleOrDefault(n => n.IDDichVu == iddichvu).TenDichVu;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _dichvuSanPhamSelected = item as DichVu_SanPham;
            if (_dichvuSanPhamSelected == null)
            {
                return;
            }
            txtDonViTinh.Text = _dichvuSanPhamSelected.DonViTinh;
            txtTenDichVu.Text = DataProvider.Instance.DB.DichVus.SingleOrDefault(n => n.IDDichVu == _dichvuSanPhamSelected.IDDichVu).TenDichVu;
            txtSoLuong.Text = _dichvuSanPhamSelected.SoLuong.ToString();
            btnSua.IsEnabled = true;
        }
    }
}

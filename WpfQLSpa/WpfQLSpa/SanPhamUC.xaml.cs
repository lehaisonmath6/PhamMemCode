using Microsoft.Win32;
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
    /// Interaction logic for SanPhamUC.xaml
    /// </summary>
    public partial class SanPhamUC : UserControl
    {
        private ObservableCollection<SanPham> _list;
        private ObservableCollection<HangSanXuat> _listTypes;
      
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public SanPhamUC()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //lsProduct.ItemsSource = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);
            _list = new ObservableCollection<SanPham>(DataProvider.Instance.DB.SanPhams);
            _listTypes = new ObservableCollection<HangSanXuat>(DataProvider.Instance.DB.HangSanXuats);
         

            lsData.ItemsSource = _list;
            cboLoaiSanPham.ItemsSource = _listTypes;
         

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDSanPham.Text = "auto";
            txtTenSanPham.Text = "";
            txtDonVi.Text = "";
            txtImage.Text = "";
            
            txtDonGia.Text = "";
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
                int idproducer = int.Parse(txtIDSanPham.Text);
                var producer = DataProvider.Instance.DB.SanPhams.SingleOrDefault(n => n.IDSanPham == idproducer);
                if (producer != null)
                {
                    DataProvider.Instance.DB.SanPhams.Remove(producer);
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
                var product = new SanPham();

                product.TenSanPham = txtTenSanPham.Text;
                product.IDHangSanXuat = (int)cboLoaiSanPham.SelectedValue;
                product.DonVi = txtDonVi.Text;

                product.DonGia = int.Parse(txtDonGia.Text);
                product.MoTa = txtMoTa.Text;
                product.UrlAnh = txtImage.Text;

                DataProvider.Instance.DB.SanPhams.Add(product);
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
            int producerid = int.Parse(txtIDSanPham.Text);
            var product = DataProvider.Instance.DB.SanPhams.SingleOrDefault(n => n.IDSanPham == producerid);
            if (product != null)
            {
                product.TenSanPham = txtTenSanPham.Text;
                product.IDHangSanXuat = (int)cboLoaiSanPham.SelectedValue;
                product.MoTa = txtMoTa.Text;
                product.DonGia = int.Parse(txtDonGia.Text);
                product.UrlAnh = txtImage.Text;

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

        SanPham _productSelected;
        private void LsData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _productSelected = item as SanPham;
            if (_productSelected == null)
            {
                return;
            }
            txtIDSanPham.Text = _productSelected.IDSanPham.ToString();
            txtTenSanPham.Text = _productSelected.TenSanPham;
            txtDonGia.Text = _productSelected.DonGia.ToString();
            cboLoaiSanPham.SelectedValue = _productSelected.IDHangSanXuat;
            //txtLoaiSanPham.Text = _productSelected.Type.Name;
            txtImage.Text = _productSelected.UrlAnh;

            txtMoTa.Text = _productSelected.MoTa;
            btnSua.IsEnabled = true;
        }

        private void TxtImage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtImage.Text = openFileDialog.FileName;
            }
        }
    }
}

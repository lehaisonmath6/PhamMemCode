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
    /// Interaction logic for HangSanXuatUC.xaml
    /// </summary>
    public partial class HangSanXuatUC : UserControl
    {
        

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }

        UserAction userAction;

        public HangSanXuatUC()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //lsProduct.ItemsSource = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);

            lsvData.ItemsSource = new ObservableCollection<HangSanXuat>(DataProvider.Instance.DB.HangSanXuats);
        

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDHangSanXuat.Text = "auto";
            txtMoTa.Text = "";
            txtTenHang.Text = "";
            txtDiaChi.Text = "";



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
                int idproducer = int.Parse(txtIDHangSanXuat.Text);
                var producer = DataProvider.Instance.DB.HangSanXuats.SingleOrDefault(n => n.IDHangSanXuat == idproducer);
                if (producer != null)
                {
                    DataProvider.Instance.DB.HangSanXuats.Remove(producer);
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
                var producer = new HangSanXuat();

                producer.TenHang = txtTenHang.Text;
                producer.DiaChi = txtDiaChi.Text;
                producer.MoTa = txtMoTa.Text;
                
               

                DataProvider.Instance.DB.HangSanXuats.Add(producer);
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
            int producerid = int.Parse(txtIDHangSanXuat.Text);
            var product = DataProvider.Instance.DB.HangSanXuats.SingleOrDefault(n => n.IDHangSanXuat == producerid);
            if (product != null)
            {
                product.TenHang = txtTenHang.Text;
            
                product.MoTa = txtMoTa.Text;
                product.DiaChi = txtDiaChi.Text;

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

        HangSanXuat _productSelected;
        private void LsData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _productSelected = item as HangSanXuat;
            if (_productSelected == null)
            {
                return;
            }
            txtIDHangSanXuat.Text = _productSelected.IDHangSanXuat.ToString();
            txtDiaChi.Text = _productSelected.DiaChi;
            txtTenHang.Text = _productSelected.TenHang;

            txtMoTa.Text = _productSelected.MoTa;
            btnSua.IsEnabled = true;
        }

    }
}

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
    /// Interaction logic for DichVuUC.xaml
    /// </summary>
    public partial class DichVuUC : UserControl
    {
      
        public DichVuUC()
        {
            _list = new ObservableCollection<DichVu>(DataProvider.Instance.DB.DichVus);
            InitializeComponent();
        }

        private ObservableCollection<DichVu> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private DichVu _dichvuSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDDichVu.Text = "auto";
            txtTenDichVu.Text = "";
            txtMoTa.Text = "";
            txtDonGia.Text = "";

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
                int iddichvu = int.Parse(txtIDDichVu.Text);
                var dichvu = DataProvider.Instance.DB.DichVus.SingleOrDefault(n => n.IDDichVu == iddichvu);
                if (dichvu != null)
                {
                    DataProvider.Instance.DB.DichVus.Remove(dichvu);
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

                var dichvu = new DichVu();

                dichvu.TenDichVu = txtTenDichVu.Text;
                dichvu.MoTa = txtMoTa.Text;
                dichvu.DonGia = int.Parse(txtDonGia.Text);
                
                DataProvider.Instance.DB.DichVus.Add(dichvu);
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
            int iddichvu = int.Parse(txtIDDichVu.Text);
            var dichvu = DataProvider.Instance.DB.DichVus.SingleOrDefault(n => n.IDDichVu == iddichvu);
            if (dichvu != null)
            {
                dichvu.TenDichVu = txtTenDichVu.Text;
                dichvu.MoTa  = txtTenDichVu.Text;
                dichvu.DonGia = int.Parse(txtDonGia.Text);
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
           
            txtIDDichVu.IsReadOnly = true;
            _list = new ObservableCollection<DichVu>(DataProvider.Instance.DB.DichVus);


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
            _dichvuSelected = item as DichVu;
            if (_dichvuSelected == null)
            {
                return;
            }
            txtIDDichVu.Text = _dichvuSelected.IDDichVu.ToString();
            txtTenDichVu.Text = _dichvuSelected.TenDichVu;
            txtDonGia.Text = _dichvuSelected.DonGia.ToString();
            txtMoTa.Text = _dichvuSelected.MoTa;
            btnSua.IsEnabled = true;
        }

        private void LsvData_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DichVuSanPhamWindow dichVuSanPhamWindow = new DichVuSanPhamWindow(_dichvuSelected.IDDichVu);
            dichVuSanPhamWindow.ShowDialog();

        }
    }
}

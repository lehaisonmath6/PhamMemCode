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
    /// Interaction logic for LichLieuTrinhWindow.xaml
    /// </summary>
    public partial class LichLieuTrinhWindow : Window
    {
        public LichLieuTrinhWindow(int idlieutrinh)
        {
            this.mIDLieuTrinh = idlieutrinh;
            InitializeComponent();
           
        }

        private ObservableCollection<LichLieuTrinh> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private LichLieuTrinh _lichlieutrinhSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {

            txtIDLichLieuTrinh.Text = "auto";
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
        int mIDLieuTrinh;
        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            userAction = UserAction.Xoa;
            if (MessageBox.Show("Xóa", "Bạn có chắc sẽ xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int idlichlieutrinh = int.Parse(txtIDLichLieuTrinh.Text);
                var lichlieutrinh = DataProvider.Instance.DB.LichLieuTrinhs.SingleOrDefault(n => n.IDLichLieuTrinh == idlichlieutrinh);
                if (lichlieutrinh != null)
                {
                    DataProvider.Instance.DB.LichLieuTrinhs.Remove(lichlieutrinh);
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

                var lichlieutrinh = new LichLieuTrinh();
                lichlieutrinh.IDLieuTrinh = mIDLieuTrinh;
                lichlieutrinh.MoTa = txtMoTa.Text;
                lichlieutrinh.ThoiGianDieuTri = dpThoiGianDieuTri.SelectedDate;
                lichlieutrinh.ThoiGianBaoTruoc = dpThoiGianBaoTruoc.SelectedDate;
                lichlieutrinh.DaThucHien = false;

                DataProvider.Instance.DB.LichLieuTrinhs.Add(lichlieutrinh);
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
            int idlichlieutrinh = int.Parse(txtIDLichLieuTrinh.Text);
            var lichLieuTrinh = DataProvider.Instance.DB.LichLieuTrinhs.SingleOrDefault(n => n.IDLichLieuTrinh == idlichlieutrinh);
            if (lichLieuTrinh != null)
            {
                lichLieuTrinh.DaThucHien = chkDaThucHien.IsChecked;
                lichLieuTrinh.ThoiGianBaoTruoc = dpThoiGianBaoTruoc.SelectedDate;
                lichLieuTrinh.ThoiGianDieuTri = dpThoiGianDieuTri.SelectedDate;
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
            txtIDLichLieuTrinh.Text = "auto";

            txtIDLichLieuTrinh.IsReadOnly = true;
            _list = new ObservableCollection<LichLieuTrinh>(DataProvider.Instance.DB.LichLieuTrinhs.Where(n=>n.IDLieuTrinh == mIDLieuTrinh));
            txtIDLieuTrinh.Text = this.mIDLieuTrinh.ToString();

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
            _lichlieutrinhSelected = item as LichLieuTrinh;
            if (_lichlieutrinhSelected == null)
            {
                return;
            }
            txtIDLichLieuTrinh.Text = _lichlieutrinhSelected.IDLichLieuTrinh.ToString();
            txtMoTa.Text = _lichlieutrinhSelected.MoTa;
            dpThoiGianBaoTruoc.SelectedDate = _lichlieutrinhSelected.ThoiGianBaoTruoc;
            dpThoiGianDieuTri.SelectedDate = _lichlieutrinhSelected.ThoiGianDieuTri;
            chkDaThucHien.IsChecked = _lichlieutrinhSelected.DaThucHien;
            btnSua.IsEnabled = true;
        }

        private void LsvData_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LichLieuTrinhWindow lichLieuTrinhWindow = new LichLieuTrinhWindow((int)_lichlieutrinhSelected.IDLieuTrinh);
            lichLieuTrinhWindow.ShowDialog();
        }
    }
}

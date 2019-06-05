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
    /// Interaction logic for LichHenUC.xaml
    /// </summary>
    public partial class LichHenUC : UserControl
    {
        public LichHenUC()
        {
            InitializeComponent();
        }

        private ObservableCollection<LichHen> _list;

        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;

        private LichHen _lichhenSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {

            txtIDLichHen.Text = "auto";
            txtNoiDung.Text = "";

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
            try
            {
                userAction = UserAction.Xoa;
                if (MessageBox.Show("Xóa", "Bạn có chắc sẽ xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int iddichvu = int.Parse(txtIDLichHen.Text);
                    var dichvu = DataProvider.Instance.DB.LichHens.SingleOrDefault(n => n.IDLichHen == iddichvu);
                    if (dichvu != null)
                    {
                        DataProvider.Instance.DB.LichHens.Remove(dichvu);
                        DataProvider.Instance.DB.SaveChanges();
                        UserControl_Loaded(null, null);
                        MessageBox.Show("Xóa thành công");
                        return;
                    }
                    MessageBox.Show("Xóa không thành công");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Them()
        {
            try
            {

                var lichen = new LichHen();
                lichen.IDKhachHang = (string)cboKhachHang.SelectedValue;
                lichen.IDTrangThaiHen = (int)cboTrangThai.SelectedValue;
                lichen.NoiDung = txtNoiDung.Text;
                lichen.ThoiGianBaoTruoc = DateTime.Parse(dpThoiGianBaoTruoc.Text);
                lichen.ThoiGianHen = DateTime.Parse(dpThoiGianHen.Text);
              
                DataProvider.Instance.DB.LichHens.Add(lichen);
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
            int idlichhen = int.Parse(txtIDLichHen.Text);
            var lichhen = DataProvider.Instance.DB.LichHens.SingleOrDefault(n => n.IDLichHen == idlichhen);
            if (lichhen != null)
            {
                lichhen.IDKhachHang = (string)cboKhachHang.SelectedValue;
                lichhen.IDTrangThaiHen = (int)cboTrangThai.SelectedValue;
                lichhen.NoiDung = txtNoiDung.Text;
                lichhen.ThoiGianHen = DateTime.Parse(dpThoiGianHen.Text);
                lichhen.ThoiGianBaoTruoc = DateTime.Parse(dpThoiGianBaoTruoc.Text);
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
            txtIDLichHen.Text = "auto";

            txtIDLichHen.IsReadOnly = true;
            _list = new ObservableCollection<LichHen>(DataProvider.Instance.DB.LichHens);
            cboKhachHang.ItemsSource = new ObservableCollection<KhachHang>(DataProvider.Instance.DB.KhachHangs);
            cboTrangThai.ItemsSource = new ObservableCollection<TrangThaiHen>(DataProvider.Instance.DB.TrangThaiHens);
            
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
            _lichhenSelected = item as LichHen;
            if (_lichhenSelected == null)
            {
                return;
            }
            txtIDLichHen.Text = _lichhenSelected.IDLichHen.ToString();
            txtNoiDung.Text = _lichhenSelected.NoiDung;
            dpThoiGianBaoTruoc.SelectedDate = _lichhenSelected.ThoiGianBaoTruoc;
            dpThoiGianHen.SelectedDate = _lichhenSelected.ThoiGianHen;
            cboKhachHang.SelectedValue = _lichhenSelected.IDKhachHang;
            cboTrangThai.SelectedValue = _lichhenSelected.IDTrangThaiHen;
            btnSua.IsEnabled = true;
        }

    }
}

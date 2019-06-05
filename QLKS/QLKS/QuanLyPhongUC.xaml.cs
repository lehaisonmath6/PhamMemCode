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
    /// Interaction logic for QuanLyPhongUC.xaml
    /// </summary>
    public partial class QuanLyPhongUC : UserControl
    {
        public QuanLyPhongUC()
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

        private tblPhong _phongSelected;


        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtSoPhong.Text = "";
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
                int idphong = int.Parse(txtSoPhong.Text);
                var phong = DataProvider.Instance.DB.tblPhongs.SingleOrDefault(n => n.IDPhong == idphong);
                if (phong != null)
                {                  
                    DataProvider.Instance.DB.tblPhongs.Remove(phong);
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
                var phong = new tblPhong();
                phong.IDPhong = int.Parse(txtSoPhong.Text);
                phong.IDTrangThaiPhong = 3;
                phong.MoTa = txtMoTa.Text;
               

                DataProvider.Instance.DB.tblPhongs.Add(phong);
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
            int idphong = int.Parse(txtSoPhong.Text);
            var phong = DataProvider.Instance.DB.tblPhongs.SingleOrDefault(n => n.IDPhong ==idphong);
            if (phong != null)
            {
                phong.MoTa = txtMoTa.Text;
                phong.IDTrangThaiPhong = (int)cboTrangThaiPhong.SelectedValue;

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

            cboTrangThaiPhong.ItemsSource = new ObservableCollection<tblTrangThaiPhong>(DataProvider.Instance.DB.tblTrangThaiPhongs);

            lsvData.ItemsSource = new ObservableCollection<tblPhong>(DataProvider.Instance.DB.tblPhongs);

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }

        private void LsvData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _phongSelected = item as tblPhong;
            if (_phongSelected == null)
            {
                return;
            }

            txtSoPhong.Text = _phongSelected.IDPhong.ToString();
            txtMoTa.Text = _phongSelected.MoTa;
            cboTrangThaiPhong.SelectedValue = _phongSelected.IDTrangThaiPhong;
            btnSua.IsEnabled = true;
        }

      


    }
}

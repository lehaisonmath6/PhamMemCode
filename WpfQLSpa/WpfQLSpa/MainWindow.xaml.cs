using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemKhachHang":
                    {
                        txtTitle.Text = "Khách hàng";
                        KhachHangUC khachHangUC = new KhachHangUC();
                        khachHangUC.Width = GridMain.Width - GridMain.Width / 10;
                        khachHangUC.Height = GridMain.Height - GridMain.Height / 10;
                        GridMain.Children.Add(khachHangUC);
                        //GridMain.Children.Add(khachHangUC);
                        break;
                    }
                case "ItemNhanVien":
                    {
                        txtTitle.Text = "Nhân viên";
                        NhanVienUC nhanVienUC = new NhanVienUC();
                        nhanVienUC.Width = GridMain.Width * 0.9;
                        nhanVienUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(nhanVienUC);
                        break;
                    }
                case "ItemSanPham":
                    {
                        txtTitle.Text = "Sản phẩm";
                        SanPhamUC sanPhamUC = new SanPhamUC();
                        sanPhamUC.Width = GridMain.Width * 0.9;
                        sanPhamUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(sanPhamUC);
                        break;
                    }
                case "ItemDichVu":
                    {
                        txtTitle.Text = "Dịch vụ";
                        DichVuUC dichVuUC = new DichVuUC();
                        dichVuUC.Width = GridMain.Width * 0.9;
                        dichVuUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(dichVuUC);
                        break;
                    }
                case "ItemLichHen":
                    {
                        txtTitle.Text = "Lên lịch hẹn";
                        LichHenUC lichHenUC = new LichHenUC();
                        lichHenUC.Width = GridMain.Width * 0.9;
                        lichHenUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(lichHenUC);
                        break;
                    }
                case "ItemLieuTrinh":
                    {
                        txtTitle.Text = "Liệu trình";
                        LieuTrinhUC lieuTrinhUC = new LieuTrinhUC();
                        lieuTrinhUC.Width = GridMain.Width * 0.9;
                        lieuTrinhUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(lieuTrinhUC);
                        break;
                    }
                case "ItemTrangChu":
                    {
                        txtTitle.Text = "Trang chủ";
                        TrangChuUC trangChuUC = new TrangChuUC();
                        trangChuUC.Width = GridMain.Width * 0.9;
                        trangChuUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(trangChuUC);
                        break;
                    }
                case "ItemHangSanXuat":
                    {
                        txtTitle.Text = "Hãng sản xuất";
                        HangSanXuatUC hangSanXuatUC = new HangSanXuatUC();
                        hangSanXuatUC.Width = GridMain.Width * 0.9;
                        hangSanXuatUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(hangSanXuatUC);
                        break;
                    }
                case "ItemNoiDungSMS":
                    {
                        txtTitle.Text = "Nội dung tin nhắn";
                        NoiDungTinNhanUC noiDungTinNhanUC = new NoiDungTinNhanUC();
                        noiDungTinNhanUC.Width = GridMain.Width * 0.9;
                        noiDungTinNhanUC.Height = GridMain.Height * 0.9;
                        GridMain.Children.Add(noiDungTinNhanUC);
                        break;
                    }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}

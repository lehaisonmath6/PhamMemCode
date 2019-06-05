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

namespace QLKS
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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemDatPhong":
                    DatPhongUC datPhongUC = new DatPhongUC();
                    GridMain.Children.Add(datPhongUC);
                    break;
                case "ItemPhongNghi":
                    QuanLyPhongUC quanLyPhongUC = new QuanLyPhongUC();
                    GridMain.Children.Add(quanLyPhongUC);
                    break;
                case "ItemTraPhong":
                    TraPhongUC traPhong = new TraPhongUC();
                    GridMain.Children.Add(traPhong);
                    break;
                case "ItemQuanLyDatPhong":
                    QuanLyDatPhongUC quanLyDatPhongUC = new QuanLyDatPhongUC();
                    GridMain.Children.Add(quanLyDatPhongUC);
                    break;
                    
            }
        }
    }
}

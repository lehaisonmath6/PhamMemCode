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

namespace QLBHwpf
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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemOrder":
                    {
                        var usc = new OrderWindow();
                       
                        usc.ShowDialog();
                        break;
                    }
                case "ItemProducer":
                    {
                        var usc = new ProducerWindow();
                        usc.ShowDialog();
                        break;
                    }
                case "ItemProduct":
                    {
                        var usc = new ProductDemoWindow();
                      
                        usc.ShowDialog();
                        break;
                    }
                case "ItemType":
                    {
                        var usc = new TypeWindow();
                      
                        usc.ShowDialog();
                        break;
                    }
                case "ItemUser":
                    {
                        var usc = new UserWindow();
                        usc.ShowDialog();
                        break;
                    }

            }
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LsvOrder_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            Order _hoadonSelected = item as Order;
            if (_hoadonSelected == null)
            {
                return;
            }
            
            var orderDetails = DataProvider.Instance.DB.OrderDetails.Where(n => n.IDOrder == _hoadonSelected.IDOrder).ToList();
            if(orderDetails.Count == 0)
            {
                return;
            }
            ObservableCollection<OrderDetail> hoaDons = new ObservableCollection<OrderDetail>(DataProvider.Instance.DB.OrderDetails.Where(n=>n.IDOrder == _hoadonSelected.IDOrder));

            
            lsvDataOrderDetails.ItemsSource = hoaDons;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lsvOrder.ItemsSource = new ObservableCollection<Order>(DataProvider.Instance.DB.Orders);
        }
    }
}

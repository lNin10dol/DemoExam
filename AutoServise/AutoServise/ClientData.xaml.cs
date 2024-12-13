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

namespace AutoServise
{
    /// <summary>
    /// Логика взаимодействия для ClientData.xaml
    /// </summary>
    public partial class ClientData : Page
    {
        public ClientData()
        {
            InitializeComponent();
            SqlConnect.GetDatas();
            ClientFrame.ItemsSource = SqlConnect.ListBar.clients;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClient());
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var a = ClientFrame.SelectedItem;
            SqlConnect.ClientDelete(a);
        }
    }
}

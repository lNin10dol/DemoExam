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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnect.AddClient(ClientSurname.Text, ClientName.Text, ClientSecond.Text, ClientDateOf.Text, ClientNumber.Text);
            NavigationService.Navigate(new ClientData());

        }
    }
}

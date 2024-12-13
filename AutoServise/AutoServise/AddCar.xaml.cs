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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Page
    {
        public AddCar()
        { 
            
            InitializeComponent();
            List<int> ids = new List<int>();
            for (int i = 0; i < SqlConnect.ListBar.id_Clietns.Count ; i++)
            {
                ids.Add(SqlConnect.ListBar.id_Clietns[i].idClietn);
            }
            id_clientSelect.ItemsSource = ids;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnect.AddCar(CarBrend.Text,CarModel.Text,CarColor.Text, id_clientSelect.Text);
            NavigationService.Navigate(new CarData());
        }
    }
}

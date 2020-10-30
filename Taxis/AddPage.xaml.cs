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

namespace Taxis
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private Order order = new Order();
        public AddPage(Order Porder)
        {
            InitializeComponent();

            if (Porder != null)
                order = Porder;

            DataContext = order;
            TaxiBox.ItemsSource = TaxisEntities1.GetContect().Cars.ToList();
            DriverBox.ItemsSource = TaxisEntities1.GetContect().Drivers.ToList();
            ClientBox.ItemsSource = TaxisEntities1.GetContect().Clients.ToList();
        }

        private void Sava_Click(object sender, RoutedEventArgs e)
        {

            TaxisEntities1.GetContect().Orders.Add(order);
            try
            {
                TaxisEntities1.GetContect().SaveChanges();
                Meneger.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

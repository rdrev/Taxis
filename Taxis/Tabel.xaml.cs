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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meneger.MainFrame.Navigate(new AddPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                TaxisEntities1.GetContect().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                DGrid.ItemsSource = TaxisEntities1.GetContect().Orders.ToList();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Meneger.MainFrame.Navigate(new AddPage((sender as Button).DataContext as Order));
        }
    }
}

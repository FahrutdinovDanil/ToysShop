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
using ToysShop.DB;

namespace ToysShop
{
    /// <summary>
    /// Логика взаимодействия для ToysPage.xaml
    /// </summary>
    public partial class ToysPage : Page
    {
        public static ObservableCollection<Product> products { get; set; }
        public ToysPage()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>(db_connection.connection.Product.ToList());
            var Prod = new Product();
            this.DataContext = this;
            HashSet<string> proiz = new HashSet<string>();

            foreach (var i in products)
            {
                proiz.Add(i.Manufacturer);
            }

            foreach (var i in proiz)
            {
                cb_Proizvod.Items.Add(i);
            }
        }

        private void prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Product;

            NavigationService.Navigate(new BuyingPage(n));
        }

        private void tb_Poisk_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tb_Poisk.Text != "")
            {
                prod.SelectedItem = null;
                prod.ItemsSource = new ObservableCollection<Product>(db_connection.connection.Product.Where(z => (z.Name.Contains(tb_Poisk.Text) || z.Description.Contains(tb_Poisk.Text))).ToList());
            }
        }

        private void cb_Proizvod_Selected(object sender, RoutedEventArgs e)
        {
            prod.SelectedItem = null;
            prod.ItemsSource = new ObservableCollection<Product>(db_connection.connection.Product.Where(z => (z.Manufacturer.Contains((cb_Proizvod.SelectedItem).ToString()))).ToList());
        }

        private void btn_Filtr_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(btn_Filtr.Content) == "По убыванию")
            {
                prod.ItemsSource = products.OrderBy(x => x.Price).ToList();
                var temp = products.OrderBy(x => x.Price).ToList();
                temp.Reverse();
                prod.ItemsSource = temp;
                btn_Filtr.Content = "По возрастанию";
            }
            else if (Convert.ToString(btn_Filtr.Content) == "По возрастанию")
            {
                prod.ItemsSource = products.OrderBy(x => x.Price).ToList();
                btn_Filtr.Content = "По убыванию";
            }
        }
    }
}

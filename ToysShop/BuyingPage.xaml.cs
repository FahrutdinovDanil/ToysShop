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
using ToysShop.DB;

namespace ToysShop
{
    /// <summary>
    /// Логика взаимодействия для BuyingPage.xaml
    /// </summary>
    public partial class BuyingPage : Page
    {
        public static Product tovar;
        public static int count = 0;
        public BuyingPage(Product n)
        {
            InitializeComponent();
            tb_Name.Text = n.Name;
            tovar = n;

            cb_VidOplaty.Items.Add("Наличными при получении");
            cb_VidOplaty.Items.Add("Банковская карта");
            cb_VidOplaty.Items.Add("Google Pay");
            cb_VidOplaty.Items.Add("Apple Pay");

            cb_Poluch.Items.Add("Самовывоз");
            cb_Poluch.Items.Add("Доставка");
            cb_Poluch.Items.Add("Срочная доставка");

            tb_Adr.Text = "Самовывоз";
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToysPage());
        }

        private void cb_Poluch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Poluch.SelectedItem.ToString() != "Самовывоз")
            {
                tb_Adr.Text = "";
                tb_Adr.Visibility = Visibility.Visible;
                tb_Adres.Visibility = Visibility.Visible;
            }
            else
            {
                tb_Adr.Text = " ";
                tb_Adr.Visibility = Visibility.Hidden;
                tb_Adres.Visibility = Visibility.Hidden;
            }
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            count = Convert.ToInt32((tb_Kol.Text));
            if (tovar.Count > Convert.ToInt32((tb_Kol.Text)))
            {
                count++;
                tb_Kol.Text = count.ToString();
            }
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            count = Convert.ToInt32((tb_Kol.Text));
            if (0 < Convert.ToInt32((tb_Kol.Text)))
            {
                count--;
                tb_Kol.Text = count.ToString();
            }
        }

        private void btn_buy_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tb_Kol.Text) != 0 && tb_FIO.Text != "" && tb_Tel.Text.Length == 11 && tb_Adr.Text != " ")
            {
                MessageBox.Show("ОК");
                NavigationService.Navigate(new ToysPage());
            }
            else
            {
                MessageBox.Show("Вы не ввели все данные");
            }
        }

        private void tb_Tel_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}

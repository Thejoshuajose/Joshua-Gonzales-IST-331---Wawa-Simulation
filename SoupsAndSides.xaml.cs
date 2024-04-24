using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Joshua_Gonzales___IST_331___Wawa_Simulation
{
    /// <summary>
    /// Interaction logic for SoupsAndSides.xaml
    /// </summary>
    public partial class SoupsAndSides : Window
    {
        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item SoupsAndSidesWindowItem = new Item();
        public int item1count = 0;
        public int item2count = 0;
        public int item3count = 0;
        public int item4count = 0;
        public bool imgINIT = false;
        public SoupsAndSides(Item soupsAndSidesWindowItem)
        {
            InitializeComponent();
            SoupsAndSidesWindowItem = soupsAndSidesWindowItem;
            InitalizeSoupsAndSides();
        }
        private void InitalizeSoupsAndSides()
        {

            String line;
            try
            {
                StreamReader reader = new StreamReader("TextFiles/SoupsNSides.txt");
                line = reader.ReadLine();
                while (line != null)
                {
                    items.Add(line);
                    itemNames.Add(line.Split('~')[0].Trim());
                    itemTypes.Add(line.Split('~')[1].Trim());
                    itemDescripts.Add(line.Split('~')[2].Trim());
                    itemPrice.Add(double.Parse(line.Split('~')[3].Trim()));
                    itemPath.Add(line.Split('~')[4].Trim());


                    line = reader.ReadLine();
                }
                imgINIT = true;
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing final Stock.");
            }


        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            SoupsAndSidesWindowItem.itemCart = itemCart;
            wnSoupsAndSides.Close();
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (imgSoupsAndSides1.IsInitialized && imgINIT == true)
            {
                BitmapImage soupsAndSidesImg1 = new BitmapImage();
                soupsAndSidesImg1.BeginInit();
                soupsAndSidesImg1.UriSource = new Uri(itemPath[0], UriKind.Relative);
                soupsAndSidesImg1.EndInit();
                imgSoupsAndSides1.Stretch = Stretch.UniformToFill;
                imgSoupsAndSides1.Source = soupsAndSidesImg1;

                BitmapImage soupsAndSidesImg2 = new BitmapImage();
                soupsAndSidesImg2.BeginInit();
                soupsAndSidesImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                soupsAndSidesImg2.EndInit();
                imgSoupsAndSides2.Stretch = Stretch.UniformToFill;
                imgSoupsAndSides2.Source = soupsAndSidesImg2;

                BitmapImage soupsAndSidesImg3 = new BitmapImage();
                soupsAndSidesImg3.BeginInit();
                soupsAndSidesImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                soupsAndSidesImg3.EndInit();
                imgSoupsAndSides3.Stretch = Stretch.UniformToFill;
                imgSoupsAndSides3.Source = soupsAndSidesImg3;

                BitmapImage soupsAndSidesImg4 = new BitmapImage();
                soupsAndSidesImg4.BeginInit();
                soupsAndSidesImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                soupsAndSidesImg4.EndInit();
                imgSoupsAndSides4.Stretch = Stretch.UniformToFill;
                imgSoupsAndSides4.Source = soupsAndSidesImg4;

                txtSoupsAndSidesTotal.Text = "Total: $" + SoupsAndSidesWindowItem.GetPriceOfCart();
            }
        }

        private void btnAddSoupsAndSides1_Click(object sender, RoutedEventArgs e)
        {

            item1count += 1;
            txtQuantitySoupsAndSides1.Text = item1count.ToString();
            SoupsAndSidesWindowItem.AddToCart(itemNames[0], itemPrice[0]);


            if (item1count == 0)
            {
                btnRemoveSoupsAndSides1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveSoupsAndSides1.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveSoupsAndSides1_Click(object sender, RoutedEventArgs e)
        {

            if (item1count > 0)
            {
                item1count -= 1;
                txtQuantitySoupsAndSides1.Text = item1count.ToString();
                SoupsAndSidesWindowItem.RemoveFromCart(itemNames[0], itemPrice[0]);
            }

            if (item1count == 0)
            {
                btnRemoveSoupsAndSides1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveSoupsAndSides1.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnAddSoupsAndSides2_Click(object sender, RoutedEventArgs e)
        {

            item2count += 1;
            txtQuantitySoupsAndSides2.Text = item2count.ToString();
            SoupsAndSidesWindowItem.AddToCart(itemNames[1], itemPrice[1]);

            if (item2count == 0)
            {
                btnRemoveSoupsAndSides2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveSoupsAndSides2.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveSoupsAndSides2_Click(object sender, RoutedEventArgs e)
        {

            if (item2count > 0)
            {
                item2count -= 1;
                txtQuantitySoupsAndSides2.Text = item2count.ToString();
                SoupsAndSidesWindowItem.RemoveFromCart(itemNames[1], itemPrice[1]);
            }

            if (item2count == 0)
            {
                btnRemoveSoupsAndSides2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveSoupsAndSides2.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnAddSoupsAndSides3_Click(object sender, RoutedEventArgs e)
        {

            item3count += 1;
            txtQuantitySoupsAndSides3.Text = item3count.ToString();
            SoupsAndSidesWindowItem.AddToCart(itemNames[2], itemPrice[2]);


            if (item3count == 0)
            {
                btnRemoveSoupsAndSides3.IsEnabled = false;
            }
            else if (item3count >= 1)
            {
                btnRemoveSoupsAndSides3.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveSoupsAndSides3_Click(object sender, RoutedEventArgs e)
        {
            if (item3count > 0)
            {
                item3count -= 1;
                txtQuantitySoupsAndSides3.Text = item3count.ToString();
                SoupsAndSidesWindowItem.RemoveFromCart(itemNames[2], itemPrice[2]);

            }

            if (item3count == 0)
            {
                btnRemoveSoupsAndSides3.IsEnabled = false;
            }

            else if (item3count >= 1)
            {
                btnRemoveSoupsAndSides3.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();


        }

        private void btnAddSoupsAndSides4_Click(object sender, RoutedEventArgs e)
        {

            item4count += 1;
            txtQuantitySoupsAndSides4.Text = item4count.ToString();
            SoupsAndSidesWindowItem.AddToCart(itemNames[3], itemPrice[3]);

            if (item4count == 0)
            {
                btnRemoveSoupsAndSides4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveSoupsAndSides4.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveSoupsAndSides4_Click(object sender, RoutedEventArgs e)
        {
            if (item4count > 0)
            {
                item4count -= 1;
                txtQuantitySoupsAndSides4.Text = item4count.ToString();
                SoupsAndSidesWindowItem.RemoveFromCart(itemNames[3], itemPrice[3]);
            }

            if (item4count == 0)
            {
                btnRemoveSoupsAndSides4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveSoupsAndSides4.IsEnabled = true;
            }

            lstSoupsAndSidesWawaReciept.ItemsSource = SoupsAndSidesWindowItem.GetItemCart().ToArray();

        }
    }
}

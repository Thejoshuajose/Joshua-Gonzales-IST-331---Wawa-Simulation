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
    /// Interaction logic for ColdDrinks.xaml
    /// </summary>
    public partial class ColdDrinks : Window
    {
        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item ColdDrinksWindowItem = new Item();
        public int item1count = 0;
        public int item2count = 0;
        public int item3count = 0;
        public int item4count = 0;
        public bool imgINIT = false;
        public ColdDrinks(Item coldDrinkWindowItem)
        {
            InitializeComponent();
            ColdDrinksWindowItem = coldDrinkWindowItem;
            InitalizeColdDrinks();
        }

        private void InitalizeColdDrinks()
        {

            String line;
            try
            {
                StreamReader reader = new StreamReader("TextFiles/ColdBeverages.txt");
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
            wnColdDrinks.Close();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (imgColdDrink1.IsInitialized && imgINIT == true)
            {
                BitmapImage coldDrinkImg1 = new BitmapImage();
                coldDrinkImg1.BeginInit();
                coldDrinkImg1.UriSource = new Uri(itemPath[0], UriKind.Relative);
                coldDrinkImg1.EndInit();
                imgColdDrink1.Stretch = Stretch.UniformToFill;
                imgColdDrink1.Source = coldDrinkImg1;

                BitmapImage coldDrinkImg2 = new BitmapImage();
                coldDrinkImg2.BeginInit();
                coldDrinkImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                coldDrinkImg2.EndInit();
                imgColdDrink2.Stretch = Stretch.UniformToFill;
                imgColdDrink2.Source = coldDrinkImg2;

                BitmapImage coldDrinkImg3 = new BitmapImage();
                coldDrinkImg3.BeginInit();
                coldDrinkImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                coldDrinkImg3.EndInit();
                imgColdDrink3.Stretch = Stretch.UniformToFill;
                imgColdDrink3.Source = coldDrinkImg3;

                BitmapImage coldDrinkImg4 = new BitmapImage();
                coldDrinkImg4.BeginInit();
                coldDrinkImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                coldDrinkImg4.EndInit();
                imgColdDrink4.Stretch = Stretch.UniformToFill;
                imgColdDrink4.Source = coldDrinkImg4;

                txtColdDrinkTotal.Text = "Total: $" + ColdDrinksWindowItem.GetPriceOfCart();
            }
        }

        private void btnAddColdDrink1_Click(object sender, RoutedEventArgs e)
        {

            item1count += 1;
            txtQuantityColdDrink1.Text = item1count.ToString();
            ColdDrinksWindowItem.AddToCart(itemNames[0], itemPrice[0]);


            if (item1count == 0)
            {
                btnRemoveColdDrink1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveColdDrink1.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveColdDrink1_Click(object sender, RoutedEventArgs e)
        {

            if (item1count > 0)
            {
                item1count -= 1;
                txtQuantityColdDrink1.Text = item1count.ToString();
                ColdDrinksWindowItem.RemoveFromCart(itemNames[0], itemPrice[0]);
            }

            if (item1count == 0)
            {
                btnRemoveColdDrink1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveColdDrink1.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnAddColdDrink2_Click(object sender, RoutedEventArgs e)
        {

            item2count += 1;
            txtQuantityColdDrink2.Text = item2count.ToString();
            ColdDrinksWindowItem.AddToCart(itemNames[1], itemPrice[1]);

            if (item2count == 0)
            {
                btnRemoveColdDrink2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveColdDrink2.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveColdDrink2_Click(object sender, RoutedEventArgs e)
        {

            if (item2count > 0)
            {
                item2count -= 1;
                txtQuantityColdDrink2.Text = item2count.ToString();
                ColdDrinksWindowItem.RemoveFromCart(itemNames[1], itemPrice[1]);
            }

            if (item2count == 0)
            {
                btnRemoveColdDrink2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveColdDrink2.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnAddColdDrink3_Click(object sender, RoutedEventArgs e)
        {

            item3count += 1;
            txtQuantityColdDrink3.Text = item3count.ToString();
            ColdDrinksWindowItem.AddToCart(itemNames[2], itemPrice[2]);


            if (item3count == 0)
            {
                btnRemoveColdDrink3.IsEnabled = false;
            }
            else if (item3count >= 1)
            {
                btnRemoveColdDrink3.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveColdDrink3_Click(object sender, RoutedEventArgs e)
        {
            if (item3count > 0)
            {
                item3count -= 1;
                txtQuantityColdDrink3.Text = item3count.ToString();
                ColdDrinksWindowItem.RemoveFromCart(itemNames[2], itemPrice[2]);

            }

            if (item3count == 0)
            {
                btnRemoveColdDrink3.IsEnabled = false;
            }

            else if (item3count >= 1)
            {
                btnRemoveColdDrink3.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();


        }

        private void btnAddColdDrink4_Click(object sender, RoutedEventArgs e)
        {

            item4count += 1;
            txtQuantityColdDrink4.Text = item4count.ToString();
            ColdDrinksWindowItem.AddToCart(itemNames[3], itemPrice[3]);

            if (item4count == 0)
            {
                btnRemoveColdDrink4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveColdDrink4.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveColdDrink4_Click(object sender, RoutedEventArgs e)
        {
            if (item4count > 0)
            {
                item4count -= 1;
                txtQuantityColdDrink4.Text = item4count.ToString();
                ColdDrinksWindowItem.RemoveFromCart(itemNames[3], itemPrice[3]);
            }

            if (item4count == 0)
            {
                btnRemoveColdDrink4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveColdDrink4.IsEnabled = true;
            }

            lstColdDrinkWawaReciept.ItemsSource = ColdDrinksWindowItem.GetItemCart().ToArray();

        }

    }
}

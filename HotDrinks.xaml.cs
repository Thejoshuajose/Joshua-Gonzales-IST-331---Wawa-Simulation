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
    /// Interaction logic for HotDrinks.xaml
    /// </summary>
    public partial class HotDrinks : Window
    {
        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item HotDrinksWindowItem = new Item();
        public int item1count = 0;
        public int item2count = 0;
        public int item3count = 0;
        public int item4count = 0;
        public bool imgINIT = false;
        public HotDrinks(Item hotDrinksWindowItem)
        {
            InitializeComponent();
            HotDrinksWindowItem = hotDrinksWindowItem;
            InitalizeHotDrinks();
        }
        private void InitalizeHotDrinks()
        {

            String line;
            try
            {
                StreamReader reader = new StreamReader("TextFiles/HotBeverages.txt");
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
            HotDrinksWindowItem.itemCart = itemCart;
            wnHotBeverages.Close();
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (imgHotDrink1.IsInitialized && imgINIT == true)
            {
                BitmapImage hotDrinkImg1 = new BitmapImage();
                hotDrinkImg1.BeginInit();
                hotDrinkImg1.UriSource = new Uri(itemPath[0], UriKind.Relative);
                hotDrinkImg1.EndInit();
                imgHotDrink1.Stretch = Stretch.UniformToFill;
                imgHotDrink1.Source = hotDrinkImg1;

                BitmapImage hotDrinkImg2 = new BitmapImage();
                hotDrinkImg2.BeginInit();
                hotDrinkImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                hotDrinkImg2.EndInit();
                imgHotDrink2.Stretch = Stretch.UniformToFill;
                imgHotDrink2.Source = hotDrinkImg2;

                BitmapImage hotDrinkImg3 = new BitmapImage();
                hotDrinkImg3.BeginInit();
                hotDrinkImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                hotDrinkImg3.EndInit();
                imgHotDrink3.Stretch = Stretch.UniformToFill;
                imgHotDrink3.Source = hotDrinkImg3;

                BitmapImage hotDrinkImg4 = new BitmapImage();
                hotDrinkImg4.BeginInit();
                hotDrinkImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                hotDrinkImg4.EndInit();
                imgHotDrink4.Stretch = Stretch.UniformToFill;
                imgHotDrink4.Source = hotDrinkImg4;

                txtHotDrinkTotal.Text = "Total: $" + HotDrinksWindowItem.GetPriceOfCart();
            }
        }
        private void btnAddHotDrink1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveHotDrink1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddHotDrink2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveHotDrink2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddHotDrink3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveHotDrink3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddHotDrink4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveHotDrink4_Click(object sender, RoutedEventArgs e)
        {

        }

        
        }
    }

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
    /// Interaction logic for Hoagies.xaml
    /// </summary>
    public partial class Hoagies : Window
    {
        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item HoagieWindowItem = new Item();
        public int item1count = 0;
        public int item2count = 0;
        public int item3count = 0;
        public int item4count = 0;
        public bool imgINIT = false;

        public Hoagies(Item MainWindowItem)
        {
            InitializeComponent();
            HoagieWindowItem = MainWindowItem;
            InitalizeHoagies();
        }
        private void InitalizeHoagies()
        {

            String line;
            try
            {
                StreamReader reader = new StreamReader("TextFiles/Hoagies.txt");
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
           
            wnHoagies.Close();
            
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (imgHoagie1.IsInitialized && imgINIT == true)
            {
                BitmapImage hoagieImg1 = new BitmapImage();
                hoagieImg1.BeginInit();
                hoagieImg1.UriSource = new Uri(itemPath[0], UriKind.Relative);
                hoagieImg1.EndInit();
                imgHoagie1.Stretch = Stretch.UniformToFill;
                imgHoagie1.Source = hoagieImg1;
                txtHoagie1.Text = itemNames[0] + ": $" + itemPrice[0];

                BitmapImage hoagieImg2 = new BitmapImage();
                hoagieImg2.BeginInit();
                hoagieImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                hoagieImg2.EndInit();
                imgHoagie2.Stretch = Stretch.UniformToFill;
                imgHoagie2.Source = hoagieImg2;
                txtHoagie2.Text = itemNames[1] + ": $" + itemPrice[1];


                BitmapImage hoagieImg3 = new BitmapImage();
                hoagieImg3.BeginInit();
                hoagieImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                hoagieImg3.EndInit();
                imgHoagie3.Stretch = Stretch.UniformToFill;
                imgHoagie3.Source = hoagieImg3;
                txtHoagie3.Text = itemNames[2] + ": $" + itemPrice[2];


                BitmapImage hoagieImg4 = new BitmapImage();
                hoagieImg4.BeginInit();
                hoagieImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                hoagieImg4.EndInit();
                imgHoagie4.Stretch = Stretch.UniformToFill;
                imgHoagie4.Source = hoagieImg4;
                txtHoagie4.Text = itemNames[3] + ": $" + itemPrice[3];


                txtHoagieTotal.Text = "Total: $" + HoagieWindowItem.GetPriceOfCart();
            }

        }

        private void btnAddHoagie1_Click(object sender, RoutedEventArgs e)
        {

            item1count += 1;
            txtQuantityHoagie1.Text = item1count.ToString();
            HoagieWindowItem.AddToCart(itemNames[0], itemPrice[0]);


            if (item1count == 0)
            {
                btnRemoveHoagie1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveHoagie1.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHoagie1_Click(object sender, RoutedEventArgs e)
        {

            if (item1count > 0)
            {
                item1count -= 1;
                txtQuantityHoagie1.Text = item1count.ToString();
                HoagieWindowItem.RemoveFromCart(itemNames[0], itemPrice[0]);
            }

            if (item1count == 0)
            {
                btnRemoveHoagie1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveHoagie1.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnAddHoagie2_Click(object sender, RoutedEventArgs e)
        {
     
            item2count += 1;
            txtQuantityHoagie2.Text = item2count.ToString();
            HoagieWindowItem.AddToCart(itemNames[1], itemPrice[1]);

            if (item2count == 0)
            {
                btnRemoveHoagie2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveHoagie2.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHoagie2_Click(object sender, RoutedEventArgs e)
        {

            if (item2count > 0)
            {
                item2count -= 1;
                txtQuantityHoagie2.Text = item2count.ToString();
                HoagieWindowItem.RemoveFromCart(itemNames[1], itemPrice[1]);
            }

            if (item2count == 0)
            {
                btnRemoveHoagie2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveHoagie2.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnAddHoagie3_Click(object sender, RoutedEventArgs e)
        {

            item3count += 1;
            txtQuantityHoagie3.Text = item3count.ToString();
            HoagieWindowItem.AddToCart(itemNames[2], itemPrice[2]);


            if (item3count == 0)
            {
                btnRemoveHoagie3.IsEnabled = false;
            }
            else if (item3count >= 1)
            {
                btnRemoveHoagie3.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHoagie3_Click(object sender, RoutedEventArgs e)
        {
            if (item3count > 0)
            {
                item3count -= 1;
                txtQuantityHoagie3.Text = item3count.ToString();
                HoagieWindowItem.RemoveFromCart(itemNames[2], itemPrice[2]);

            }

            if (item3count == 0)
            {
                btnRemoveHoagie3.IsEnabled = false;
            }

            else if (item3count >= 1)
            {
                btnRemoveHoagie3.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();


        }

        private void btnAddHoagie4_Click(object sender, RoutedEventArgs e)
        {

            item4count += 1;
            txtQuantityHoagie4.Text = item4count.ToString();
            HoagieWindowItem.AddToCart(itemNames[3], itemPrice[3]);

            if (item4count == 0)
            {
                btnRemoveHoagie4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveHoagie4.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHoagie4_Click(object sender, RoutedEventArgs e)
        {
            if (item4count > 0)
            {
                item4count -= 1;
                txtQuantityHoagie4.Text = item4count.ToString();
                HoagieWindowItem.RemoveFromCart(itemNames[3], itemPrice[3]);
            }

            if (item4count == 0)
            {
                btnRemoveHoagie4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveHoagie4.IsEnabled = true;
            }

            lstHoagieWawaReciept.ItemsSource = HoagieWindowItem.GetItemCart().ToArray();

        }
    }
}

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
        Item HoagieWindowItem = new Item();
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
                StreamReader reader = new StreamReader("/TextFiles/Hoagies.txt");
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
            /*if (imgHoagie1.IsInitialized||imgINIT == true)
            {
                BitmapImage hoagieImg1 = new BitmapImage();
                hoagieImg1.BeginInit();
                hoagieImg1.UriSource = new Uri(itemPath[0], UriKind.Relative);
                hoagieImg1.EndInit();
                imgHoagie1.Stretch = Stretch.UniformToFill;
                imgHoagie1.Source = hoagieImg1;

                BitmapImage hoagieImg2 = new BitmapImage();
                hoagieImg2.BeginInit();
                hoagieImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                hoagieImg2.EndInit();
                imgHoagie2.Stretch = Stretch.UniformToFill;
                imgHoagie2.Source = hoagieImg2;

                BitmapImage hoagieImg3 = new BitmapImage();
                hoagieImg3.BeginInit();
                hoagieImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                hoagieImg3.EndInit();
                imgHoagie3.Stretch = Stretch.UniformToFill;
                imgHoagie3.Source = hoagieImg3;

                BitmapImage hoagieImg4 = new BitmapImage();
                hoagieImg4.BeginInit();
                hoagieImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                hoagieImg4.EndInit();
                imgHoagie4.Stretch = Stretch.UniformToFill;
                imgHoagie4.Source = hoagieImg4;
            }*/
        }
    }
}

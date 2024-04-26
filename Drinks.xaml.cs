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
using System.Windows.Shapes;

namespace Joshua_Gonzales___IST_331___Wawa_Simulation
{
    /// <summary>
    /// Interaction logic for Drinks.xaml
    /// </summary>
    public partial class Drinks : Window
    {
        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item DrinksWindowItem = new Item();
        public int item1count = 0;
        public int item2count = 0;
        public int item3count = 0;
        public int item4count = 0;
        public bool imgINIT = false;
        public Drinks(Item drinksWindowItem)
        {
            InitializeComponent();
            DrinksWindowItem = drinksWindowItem;
        }
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            wnDrinks.Close();
        }

        private void btnColdBeverages_Click(object sender, RoutedEventArgs e)
        {
            ColdDrinks wnColdDrinks = new ColdDrinks(DrinksWindowItem);
            wnDrinks.Hide();
            wnColdDrinks.ShowDialog();
            wnDrinks.BringIntoView();

        }

        private void btnHotBeverages_Click(object sender, RoutedEventArgs e)
        {
            HotDrinks wnHotDrinks = new HotDrinks(DrinksWindowItem);
            wnDrinks.Hide();
            wnHotDrinks.ShowDialog();
            wnDrinks.BringIntoView();


        }
    }
}

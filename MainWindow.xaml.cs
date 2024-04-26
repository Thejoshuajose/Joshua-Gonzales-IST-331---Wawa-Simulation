using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Joshua_Gonzales___IST_331___Wawa_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {

        public List<string> itemNames = new List<string>();
        public List<string> itemTypes = new List<string>();
        public List<string> itemDescripts = new List<string>();
        public List<double> itemPrice = new List<double>();
        public List<string> itemPath = new List<string>();
        public List<string> items = new List<string>();
        public List<string> itemCart = new List<string>();
        public Item MainWindowItem = new Item();


        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you Sure?", "Do you want to Exit?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            lstMainWawaReciept.ItemsSource = MainWindowItem.GetItemCart().ToArray();
            txtTotalPrice.Text ="Total: $" + MainWindowItem.GetPriceOfCart().ToString();

        }

        private void lstMainWawaReciept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowItem.itemCart.Count != 0)
            {
                MessageBoxResult result = MessageBox.Show("Checkout with: \n" + MainWindowItem.GetItemCart().ToArray().ToString(), "Do You Want to Check Out" , MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Order #"+ MainWindowItem.itemCart.Count + " Confirmed");
                    MainWindowItem.itemCart.Clear();
                    MainWindowItem.itemPriceCart.Clear();
                    MainWindowItem.ClearPriceCart();
                    txtTotalPrice.Text = "Total: $0";

                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MainWindowItem.itemCart.Clear();
            itemCart.Clear() ;
        }

        private void btnHoagies_Click(object sender, RoutedEventArgs e)
        {

           Hoagies wnHoagies = new Hoagies(MainWindowItem);
            wnWawaSimulation.Hide();
            wnHoagies.ShowDialog();
            wnWawaSimulation.Visibility = Visibility.Visible;
        }

        private void btnDrinks_Click(object sender, RoutedEventArgs e)
        {
            Drinks wnDrinks = new Drinks(MainWindowItem);
            wnWawaSimulation.Hide();
            wnDrinks.ShowDialog();
            wnWawaSimulation.BringIntoView();
        }

        private void btnSoupsNSides_Click(object sender, RoutedEventArgs e)
        {
            SoupsAndSides wnSoupsAndSides = new SoupsAndSides(MainWindowItem);
            wnWawaSimulation.Hide();
            wnSoupsAndSides.ShowDialog();
            wnWawaSimulation.s();
        }
    }
}
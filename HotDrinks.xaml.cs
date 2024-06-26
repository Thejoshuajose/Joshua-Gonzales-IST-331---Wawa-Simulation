﻿using System;
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
                txtHotDrink1.Text = itemNames[0] + ": $" + itemPrice[0];


                BitmapImage hotDrinkImg2 = new BitmapImage();
                hotDrinkImg2.BeginInit();
                hotDrinkImg2.UriSource = new Uri(itemPath[1], UriKind.Relative);
                hotDrinkImg2.EndInit();
                imgHotDrink2.Stretch = Stretch.UniformToFill;
                imgHotDrink2.Source = hotDrinkImg2;
                txtHotDrink2.Text = itemNames[1] + ": $" + itemPrice[1];


                BitmapImage hotDrinkImg3 = new BitmapImage();
                hotDrinkImg3.BeginInit();
                hotDrinkImg3.UriSource = new Uri(itemPath[2], UriKind.Relative);
                hotDrinkImg3.EndInit();
                imgHotDrink3.Stretch = Stretch.UniformToFill;
                imgHotDrink3.Source = hotDrinkImg3;
                txtHotDrink3.Text = itemNames[2] + ": $" + itemPrice[2];


                BitmapImage hotDrinkImg4 = new BitmapImage();
                hotDrinkImg4.BeginInit();
                hotDrinkImg4.UriSource = new Uri(itemPath[3], UriKind.Relative);
                hotDrinkImg4.EndInit();
                imgHotDrink4.Stretch = Stretch.UniformToFill;
                imgHotDrink4.Source = hotDrinkImg4;
                txtHotDrink4.Text = itemNames[3] + ": $" + itemPrice[3];


                txtHotDrinkTotal.Text = "Total: $" + HotDrinksWindowItem.GetPriceOfCart();
            }
        }
        private void btnAddHotDrink1_Click(object sender, RoutedEventArgs e)
        {

            item1count += 1;
            txtQuantityHotDrink1.Text = item1count.ToString();
            HotDrinksWindowItem.AddToCart(itemNames[0], itemPrice[0]);


            if (item1count == 0)
            {
                btnRemoveHotDrink1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveHotDrink1.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHotDrink1_Click(object sender, RoutedEventArgs e)
        {

            if (item1count > 0)
            {
                item1count -= 1;
                txtQuantityHotDrink1.Text = item1count.ToString();
                HotDrinksWindowItem.RemoveFromCart(itemNames[0], itemPrice[0]);
            }

            if (item1count == 0)
            {
                btnRemoveHotDrink1.IsEnabled = false;
            }
            else if (item1count >= 1)
            {
                btnRemoveHotDrink1.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnAddHotDrink2_Click(object sender, RoutedEventArgs e)
        {

            item2count += 1;
            txtQuantityHotDrink2.Text = item2count.ToString();
            HotDrinksWindowItem.AddToCart(itemNames[1], itemPrice[1]);

            if (item2count == 0)
            {
                btnRemoveHotDrink2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveHotDrink2.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHotDrink2_Click(object sender, RoutedEventArgs e)
        {

            if (item2count > 0)
            {
                item2count -= 1;
                txtQuantityHotDrink2.Text = item2count.ToString();
                HotDrinksWindowItem.RemoveFromCart(itemNames[1], itemPrice[1]);
            }

            if (item2count == 0)
            {
                btnRemoveHotDrink2.IsEnabled = false;
            }
            else if (item2count >= 1)
            {
                btnRemoveHotDrink2.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnAddHotDrink3_Click(object sender, RoutedEventArgs e)
        {

            item3count += 1;
            txtQuantityHotDrink3.Text = item3count.ToString();
            HotDrinksWindowItem.AddToCart(itemNames[2], itemPrice[2]);


            if (item3count == 0)
            {
                btnRemoveHotDrink3.IsEnabled = false;
            }
            else if (item3count >= 1)
            {
                btnRemoveHotDrink3.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHotDrink3_Click(object sender, RoutedEventArgs e)
        {
            if (item3count > 0)
            {
                item3count -= 1;
                txtQuantityHotDrink3.Text = item3count.ToString();
                HotDrinksWindowItem.RemoveFromCart(itemNames[2], itemPrice[2]);

            }

            if (item3count == 0)
            {
                btnRemoveHotDrink3.IsEnabled = false;
            }

            else if (item3count >= 1)
            {
                btnRemoveHotDrink3.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();


        }

        private void btnAddHotDrink4_Click(object sender, RoutedEventArgs e)
        {

            item4count += 1;
            txtQuantityHotDrink4.Text = item4count.ToString();
            HotDrinksWindowItem.AddToCart(itemNames[3], itemPrice[3]);

            if (item4count == 0)
            {
                btnRemoveHotDrink4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveHotDrink4.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }

        private void btnRemoveHotDrink4_Click(object sender, RoutedEventArgs e)
        {
            if (item4count > 0)
            {
                item4count -= 1;
                txtQuantityHotDrink4.Text = item4count.ToString();
                HotDrinksWindowItem.RemoveFromCart(itemNames[3], itemPrice[3]);
            }

            if (item4count == 0)
            {
                btnRemoveHotDrink4.IsEnabled = false;
            }
            else if (item4count >= 1)
            {
                btnRemoveHotDrink4.IsEnabled = true;
            }

            lstHotDrinkWawaReciept.ItemsSource = HotDrinksWindowItem.GetItemCart().ToArray();

        }


    }
    }

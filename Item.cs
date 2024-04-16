using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joshua_Gonzales___IST_331___Wawa_Simulation
{
    class Item
    {
        string itemName;
        double itemPrice;
        string itemDescription;
        string itemType;
        string itemImgPath;
        public List<string> itemCart = new List<string>();
        public List<double> itemPriceCart = new List<double>();


        public Item(string itemName, string itemDescription, string itemType, double itemPrice, string itemImgPath)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemDescription = itemDescription;
            this.itemType = itemType;
            this.itemImgPath = itemImgPath;
        }

        public Item(string itemName, double itemPrice, string itemType,string itemImgPath)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemType = itemType;
            this.itemImgPath = itemImgPath;
        }

        public List<string> GetItemCart()
        {
            return this.itemCart;
        }

        public string GetItemName()
        {
            return itemName;
        }

        public double GetItemPrice()
        {
            return itemPrice;
        }

        public string GetItemDescription()
        {
            return itemDescription;
        }

        public string GetItemType()
        {
            return itemType;
        }
        public string GetItemImgPath()
        {
            return itemImgPath;
        }

        public void AddToCart (string itemName, double itemPrice)
        {
            itemCart.Add(itemName);
            itemPriceCart.Add(itemPrice);

        }

        public void RemoveFromCart(string itemName, double itemPrice) 
        { 
            itemCart.Remove(itemName); 
            itemPriceCart.Remove(itemPrice);
        }
        public void SetItemImgPath(string imgPath)
        {
            this.itemImgPath = imgPath;
        }

        public void SetItemName(string name)
        {
            itemName = name;
        }

        public void SetItemPrice(double price)
        {
            itemPrice = price;
        }

        public void SetItemDescription(string description)
        {
            itemDescription = description;
        }

        public void SetItemType(string type)
        {
            itemType = type;
        }

    }
}

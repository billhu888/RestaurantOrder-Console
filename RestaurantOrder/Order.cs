using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public class Order
    {
        public Order(string customername)
        {
            CustomerName = customername;
            CustomerItems = new List<FoodItem>();
            TotalPrice = 0.00F;
        }

        public string CustomerName { get; set; }

        // List can hold objects of type FoodItem or any of
        // its derived classes, such as Drink
        public List<FoodItem> CustomerItems { get; set; }

        //public void AddCustomerItem(FoodItem item) 
        //{
        //    CustomerItems.Add(item);
        //}

        public float TotalPrice { get; set; }

        public void AddOrderPrice(float price)
        {
            TotalPrice = price + TotalPrice;
        }

        public void Display()
        {

            Console.WriteLine("Here is a summary of your order " + CustomerName);
            Console.WriteLine();

            foreach (FoodItem item in CustomerItems)
            {
                item.DisplayItem();
            }

            Console.WriteLine("Your total cost is: $" + TotalPrice);
            Console.WriteLine();
        }
    }
}
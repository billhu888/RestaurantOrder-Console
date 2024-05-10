using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantOrder
{
    public class Drink : FoodItem
    {
        public Drink (string name, float price, int size) : base(name, price) 
        { 
            Size = size; 
        }

        public int Size { get; set; }

        public override void DisplayItem()
        {
            base.DisplayItem();
            Console.WriteLine("Size: " + Size);
            Console.WriteLine();
        }
    } 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public abstract class FoodItem
    {
        public FoodItem(string name, float price)
        { 
            Name = name;
            Price = price;
        }

        public virtual string Name { get; set; }
        public virtual float Price { get; set; }

        public virtual void DisplayItem()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
        }
    }
}
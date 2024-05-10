using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public class Side : FoodItem
    {
        public Side (string name, float price) : base (name, price) { }

        public override void DisplayItem()
        {
            base.DisplayItem();
            Console.WriteLine();
        }
    }
}
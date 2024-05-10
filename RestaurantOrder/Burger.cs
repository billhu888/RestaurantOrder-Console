using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public class Burger : FoodItem
    {
        public Burger (string name, float price) : base(name, price)
        {
            Condiments = new List<string>();
        }

        public List<string> Condiments { get; set; }

        public void AddCondiments(string condiment)
        {
            Condiments.Add(condiment);
        }

        public override void DisplayItem()
        {
            base.DisplayItem();
            Console.WriteLine("Condiments: ");

            foreach (string condiment in Condiments)
            {
                Console.WriteLine(condiment);
            }

            Console.WriteLine();
        }
    }
}
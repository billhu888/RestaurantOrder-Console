using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public class Combo : FoodItem
    {
        public Combo(string name, float price, Burger burgerpart, Drink drinkpart, Side sidepart) 
            : base (name, price) 
        {
            BurgerPart = burgerpart;
            DrinkPart = drinkpart;
            SidePart = sidepart;
        }

        public Burger BurgerPart { get; set; }
        public Drink DrinkPart { get; set; }
        public Side SidePart { get; set; }

        public override void DisplayItem()
        {
            base.DisplayItem();
            Console.WriteLine("The burger you ordered has the following condiments: ");

            foreach (string condiment in BurgerPart.Condiments)
            {
                Console.WriteLine(condiment);
            }

            Console.WriteLine("The drink you ordered is: " + DrinkPart.Name);
            Console.WriteLine("The drink size you ordered is: " + DrinkPart.Size + "oz");
            Console.WriteLine("The side you ordered is: " + SidePart.Name);
            Console.WriteLine();    
        }
    }
}
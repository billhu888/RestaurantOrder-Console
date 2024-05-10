using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    public class Repo
    {
        string BurgerName = "Burger";
        float BurgerPrice = 3.99F;
        string[] BurgerCondiments = { "tomatoes", "lettuce", "onions", "cheese" };

        string[] DrinkOptions = { "fanta", "coca cola", "sprite" };
        int[] DrinkSizes = { 12, 16, 20 };
        float[] DrinkPrices = { 1.49F, 1.79F, 1.99F };
        float DrinkPrice = 0.00F;

        float SidePrice = 2.99F;
        string[] SideOptions = { "fries", "coleslaw", "salad" };

        string ComboName = "Combo";
        float ComboDiscount = 1.29F;
        float ComboPrice = 0.00F;

        public Burger GetBurgerOrder()
        {
            Burger burger1 = new Burger(BurgerName, BurgerPrice);

            foreach (string condiment in  BurgerCondiments) 
            {
                Console.WriteLine("Do you want " + condiment + " on your burger? (Press y for yes): ");
                string CondimentSelection = Console.ReadLine();

                if (CondimentSelection.ToLower() == "y")
                {
                    burger1.AddCondiments(condiment);
                }
            }

            Console.WriteLine("Your burger price is $" + BurgerPrice);
            Console.WriteLine();

            return burger1;
        }

        public Drink GetDrinkOrder() 
        {
            string DrinkChoice = null;
            int SizeChoice = 0;
            bool indication = true;
            Console.WriteLine("Below you will see all the drink options");

            foreach(string item in DrinkOptions)
            {
                Console.WriteLine(item);
            }

            while (indication == true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the drink you want: ");
                DrinkChoice = Console.ReadLine();

                if (Array.Exists(DrinkOptions, option => option.ToLower() == DrinkChoice))
                {
                    Console.WriteLine("Your drink is: " + DrinkChoice);
                    Console.WriteLine();

                    indication = false; 
                }
                else
                {
                    Console.WriteLine("Your drink choice is not available. Please try again.");
                }
            }

            indication = true;
            int length = DrinkSizes.Length;
            Console.WriteLine("Below you will see all the drink sizes and each size's price");

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(DrinkSizes[i] + ", " + DrinkPrices[i]);
            }

            Console.WriteLine();

            while (indication == true)
            {
                Console.WriteLine("Please enter the drink size you want: ");
                string sizechoice = Console.ReadLine();
                Console.WriteLine();
                SizeChoice = int.Parse(sizechoice);

                if (Array.Exists(DrinkSizes, option => option == SizeChoice))
                {
                    Console.WriteLine();
                    Console.WriteLine("Your drink size is: " + SizeChoice + " ounces");
                    Console.WriteLine();

                    int index = Array.IndexOf(DrinkSizes, SizeChoice);
                    DrinkPrice = DrinkPrices[index];

                    Console.WriteLine("Your drink price is: $" + DrinkPrice);
                    indication = false;
                }
                else
                {
                    Console.WriteLine("Your drink size is not available. Please try again.");
                }
            }

            Console.WriteLine();

            Drink drink1 = new Drink(DrinkChoice, DrinkPrice, SizeChoice);

            return drink1;
        }

        public Side GetSideOrder()
        {
            string SideChoice = null;
            bool indication = true;
            Console.WriteLine("Below you will see all the side options");

            foreach(string item in SideOptions)
            {
                Console.WriteLine(item);
            }

            while (indication == true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the side you want: ");
                SideChoice = Console.ReadLine();
                Console.WriteLine();

                if (Array.Exists(SideOptions, option => option == SideChoice))
                {
                    Console.WriteLine("Your side choice is " + SideChoice);
                    indication = false;
                }
                else
                {
                    Console.WriteLine("Your side choice is not available. Please try again.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Your side price is $" + BurgerPrice);
            Console.WriteLine();

            Side side1 = new Side(SideChoice, SidePrice);

            return side1;
        }

        public Combo GetComboOrder()
        {
            Console.WriteLine("Now you will be taken to order your burger");
            Console.WriteLine();
            Burger BurgerPart = GetBurgerOrder();
            Console.WriteLine();

            Console.WriteLine("Now you will be taken to order your drink");
            Console.WriteLine();
            Drink DrinkPart = GetDrinkOrder();
            Console.WriteLine();

            Console.WriteLine("Now you will be taken to order your side");
            Console.WriteLine();
            Side SidePart = GetSideOrder();
            Console.WriteLine();

            ComboPrice = BurgerPrice + DrinkPrice + SidePrice - ComboDiscount;

            Console.WriteLine("The combo discount is $" + ComboDiscount);
            Console.WriteLine("Your combo price is $" + ComboPrice);
            Console.WriteLine();

            Combo combo1 = new Combo(ComboName, ComboPrice, BurgerPart, DrinkPart, SidePart);

            return combo1;
        }

        public Order OrderMany()
        {
            Console.WriteLine("Welcome to Classic Delights! ");
            Console.WriteLine();

            string CustomerName;
            Console.WriteLine("Please enter your name: ");
            CustomerName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Hello " + CustomerName);
            Console.WriteLine();

            Order CustomerOrder = new Order(CustomerName);

            bool indication = true;

            while (indication == true)
            {
                Console.WriteLine("Enter 1 for burger");
                Console.WriteLine("Enter 2 for drink");
                Console.WriteLine("Enter 3 for side");
                Console.WriteLine("Enter 4 for combo");
                Console.WriteLine();

                Console.WriteLine("Please enter your choice: ");
                string selection = Console.ReadLine();
                Console.WriteLine();

                switch (selection)
                {
                    case "1":
                        Burger burger = GetBurgerOrder();
                        CustomerOrder.CustomerItems.Add(burger);
                        //CustomerOrder.AddCustomerItem(burger);
                        CustomerOrder.AddOrderPrice(BurgerPrice);
                        break;

                    case "2":
                        Drink drink = GetDrinkOrder();
                        CustomerOrder.CustomerItems.Add(drink);
                        CustomerOrder.AddOrderPrice(DrinkPrice);
                        break;

                    case "3":
                        Side side = GetSideOrder();
                        CustomerOrder.CustomerItems.Add(side);
                        CustomerOrder.AddOrderPrice(SidePrice);
                        break;

                    case "4":
                        Combo combo = GetComboOrder();
                        CustomerOrder.CustomerItems.Add(combo);
                        CustomerOrder.AddOrderPrice(ComboPrice);
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please enter a valid selection");
                        break;
                }

                Console.WriteLine("Do you want more items. Press n to finish your order");
                string ContinueOrder = Console.ReadLine();

                if (ContinueOrder.ToLower() != "n")
                {
                    indication = true;
                }
                else
                {
                    indication = false;
                }
            }

            Console.WriteLine();
            
            return CustomerOrder;
        }
    }
}
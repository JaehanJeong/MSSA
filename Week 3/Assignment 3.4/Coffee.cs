using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3._4
{
    public enum MilkType { None, Whole, Oat, Almond } // 4 types of Milk (adds to price later)
    public enum BeanType { House, DarkRoast, Premium } // Different beans (didn't change price)
    public enum CoffeeName { Espresso, Americano, Latte, Cappuccino, Mocha } // Just giving options for diff coffees

    internal class Coffee : Beverage
    {
        public CoffeeName CoffeeName { get; set; } // Enums coffee names
        public MilkType Milk {  get; set; } // Enums Milks
        public BeanType Bean { get; set; } // Enums Bean types
        //public bool GotMilk {  get; set; } // For those lactose intolerant
        //Started as a bool but decided to make it enums.

        public int Shots { get; set; } // How addicted they are to caffeine
        public double Price => GetPrice(); // Price is gona be calculated dynamically!
        public double GetPrice () // Function to calculate Price
        {
            double basePrice = 0; // Start at 0
            switch (BeverageSize) // Size adds to base price
            {
                case beverageSize.Small:
                    basePrice = 3.0;
                    break;
                case beverageSize.Medium:
                    basePrice = 4.5;
                    break;
                case beverageSize.Large:
                    basePrice = 5.5;
                    break;
                case beverageSize.ExtraLarge:
                    basePrice = 6.0;
                    break;
            }
            basePrice += Shots * 0.5; // Shots get added
            
            switch (Milk) // Milk get added
            {
                case MilkType.Whole:
                    basePrice += 0.2;
                    break;
                case MilkType.Oat:
                    basePrice += 0.3;
                    break;
                case MilkType.Almond:
                    basePrice += 0.5;
                    break;
            }

            return basePrice; // Final price. Maybe variable name should be different.

        }


    }
}

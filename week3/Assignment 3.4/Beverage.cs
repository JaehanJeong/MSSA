using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3._4
{
    public enum beverageSize
    {
        Small = 0, Medium = 1, Large = 2, ExtraLarge = 3
    }
    internal abstract class Beverage
    {
        //public string? Name { get; set; } decided I wanted to eliminate potential for error when picking names.

        //public abstract double GetPrice(); // No abstract methods per Sensei

        public beverageSize BeverageSize { get; set; } // All beverages should have size.. right?
    }
}

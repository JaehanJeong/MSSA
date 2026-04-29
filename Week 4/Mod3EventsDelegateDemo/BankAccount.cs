using System;
using System.Collections.Generic;
using System.Text;

namespace Mod3EventsDelegateDemo 
{
    delegate void LowBalDel(double bal); // Delegate signature
    internal class BankAccount //How to define delegates in user defined classes
    {
        // When lowbalance event is raised, the low balance delegate we have written will point to the event handler.
        // Which event handler?
        // We didn't write yet. When we create bankacc obj we'll take care of that.
        public event LowBalDel LowBalDel;
        public int AccountNumber { get; set; } // Property Account Numba
        private double accountbalance; //private - all lower case
        public double AccountBalance
        {
            get { return this.accountbalance; }
            set 
            { 
                if(accountbalance < 200)
                {
                    LowBalDel(value);// Raising an event - use the value to display the event.
                    // value isn't defined - inbuilt keyword only in the properties. 
                    // Which ever value you're assigning from client code 
                }
            }
        }
    }
}

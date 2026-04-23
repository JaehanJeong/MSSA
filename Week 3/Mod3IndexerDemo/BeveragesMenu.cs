using System;
using System.Collections.Generic;
using System.Text;

namespace Mod3IndexerDemo
{
    internal class BeveragesMenu
    {
        private string[] beverages; // data members (values where you store info) HAS TO BE PRIVATE
        public BeveragesMenu (int size) // Know size based on day of the week?
        {
            beverages = new string[size]; // Size depend on the instance.
            // fooditems = new string[size]; Multiple index is not allowed for a class
        }
        public int Count//Helper property current legnth of beverages menu
        {
            get { return beverages.Length; }
        }// Not necessary but showing the use of a read only property.
        
        
        //indexer - Needs to be public cuz  client needs to access
        // access specifier, data type of the array, 'this' keyword, [int index] square brackets, with int index 

        
        public string this[int index]
        {
            get // get the value back
            {
                if(index<beverages.Length && !(index<0)) // verify that the index is valid.
                    return beverages[index];// Don't need curly braces cuz we only have if block

                return "No data at this index";
            }
            set // opposite of get --> containing the data that you're passing from client code.
            {
                if (index < beverages.Length && !(index<0))
                    beverages[index] = value; // Don't need curly braces cuz we only have if block

            }
        }
    }
}

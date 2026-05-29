using System;
using System.Collections.Generic;
using System.Text;

namespace Add_Binary
{
    public class MyAttempt
    {
        public string AddBinary(string a, string b)
        {
            //Resulting string
            string c = "";
            //If given empty strings, just return an empty string?
            if (a.Length == 0 && b.Length == 0)
            {
                return c;
            }
            //Come up with a logic that does the binary addition math
            //1. Line them up; which ever is longer goes first?
            if (a.Length > b.Length)
            {
                // for(int i = a.Length-1; i >0; i--)
                // {

                // }
                //Combine the two digits?
                for (int j = b.Length - 1; j > 0; j--)
                {
                    a[a.Length - j] + b[b.Length - j]
                }

                //Some logic to compute the total carrying the 2's (or 10's) to the front.
            }


            return c;
        }
    }
    //Initial Thought
    //1. Convert strings to decimal
    //2. Compute the sum
    //3. Convert the sum to binary string
    //4. Return the string



}

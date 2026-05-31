using System;
using System.Collections.Generic;
using System.Text;

namespace Sqrt_x_
{
    public class MyAttempt
    {
        public int MySqrt(int x)
        {
            int y = 0; // The result we will return
                       //Edge case - if x is 0 then just finish
            if (x == 0) return y;


            while (x > 0)
            {
                y = x / 2; //Start by cutting in half
                if (y * y == x) { return y; } // Somehow if it's exact sqrt then return.
                if (y * y > x) { x /= 2; } // If bigger, try again chop in half.
                                           // Problem is... we could get to where x is super tiny but continues without finding the solution.
                                           // Also this changes the x... i think.. potential for critical error?
                                           //Not sure how to find the decimals that would work here below.
                                           //if(y * y < x) {}

            }
            return y;
        }
    }
    // Lets say x = 16
}

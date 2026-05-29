using System;
using System.Collections.Generic;
using System.Text;

namespace Add_Binary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            string result = "";
            int i = a.Length - 1;  // pointer starting at end of a
            int j = b.Length - 1;  // pointer starting at end of b
            int carry = 0;

            while (i >= 0 || j >= 0 || carry != 0)
            {
                int sum = carry;  // start with whatever carried over

                if (i >= 0)
                {
                    sum += a[i] - '0';  // add a's current bit (if any left)
                    i--;
                }
                if (j >= 0)
                {
                    sum += b[j] - '0';  // add b's current bit (if any left)
                    j--;
                }

                // sum is now 0, 1, 2, or 3
                // sum % 2 gives the bit to write (0 or 1)
                // sum / 2 gives the carry (0 or 1)
                result = (sum % 2).ToString() + result;  // prepend to front
                carry = sum / 2;
            }

            return result.Length == 0 ? "0" : result;
        }
    }
}

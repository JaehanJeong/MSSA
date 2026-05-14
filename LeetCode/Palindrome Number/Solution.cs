using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrome_Number
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;//x is negative, so return false.

            string nums = Convert.ToString(x);
            for (int i = 0; i < nums.Length / 2; i++)
            {
                if (nums[i] == nums[nums.Length - 1 - i])
                {
                    continue;
                }
                return false;
            }
            return true;
            /*
                Was figuring out where I went wrong. Realized i was missing -i
                1001 --> "1001"
                i = 0 --> 1001[0] == 1001["1001".Length-1 aka 3] --> 1 == 1 --> Continue
                i = 1 --> 1001[1] == 1001["1001".Length-1]
            */


        }
    }
}

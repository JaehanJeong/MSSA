using System;
using System.Collections.Generic;
using System.Text;

namespace Plus_One
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            //Unsure how to address edge case of needing to increase the array size.
            int i = 1;
            int index = digits.Length - i;
            if (digits[digits.Length - 1] + 1 == 10)
            {
                //If all digits are 9's, then add a new digit by creating a new array or resize?
                //if()

                digits[digits.Length - 1] = 0;
                while (index > 0 && digits[digits.Length - index] == 9)
                {
                    digits[digits.Length - index] = 0;
                    i++;
                }
                if (index == 0)
                {
                    digits[0] = 1;
                }

            }
            else
            {
                digits[digits.Length - 1]++;
            }
            return digits;

        }
    }
}

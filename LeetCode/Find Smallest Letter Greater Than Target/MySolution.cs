using System;
using System.Collections.Generic;
using System.Text;

namespace Find_Smallest_Letter_Greater_Than_Target
{
    public class Solution
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            //97 = a, goes up to 122 = z
            //nothing is greater than the great 'z'
            //if(target == 'z'){return letters[0];}

            //if target is anything greater than or equal to the last element, return index 0.
            //if(Convert.ToInt32(target) >= Convert.ToInt32(letters[letters.Length-1])){return letters[0];}

            //if target is smaller than any of the letters, then return index 0.
            //if(Convert.ToInt32(target) < Convert.ToInt32(letters[0])){return letters[0];}

            // if(Convert.ToInt32(target) == Convert.ToInt32(letters[0]))
            // {
            //     int i = 0;
            //     while(letters[i] == target)
            //     {
            //         i++;
            //     }return letters[i];
            // }

            int left = 0;
            int right = letters.Length - 1;

            while (left <= right)
            {
                // Safe midpoint calculation preventing integer overflow
                int mid = left + (right - left) / 2;

                if (letters[mid] <= target)
                {
                    left = mid + 1; // Barely larger than target.
                }
                else
                {
                    right = mid - 1; // Discard the right half
                }
            }
            //while(letters[left] == target){left +=1;}
            return letters[left % letters.Length];

        }

    }


}

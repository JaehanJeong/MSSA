using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_Element
{
    //Where I got to.
    public class MySolution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int k = 0;

            // Count how many vals are inside this array.
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val && i + 1 <= nums.Length)
                {
                    //While the following indicies are not val,
                    while (nums[i + 1] != val)
                    {
                        //Set the index's value to the value of the next index.
                        nums[i] = nums[i + 1];
                    }
                    k++;
                }
                else break;
            }

            // Replace or skip the val in the array.

            Console.WriteLine($"{k}, nums = {string.Join(", ", nums)}");
            return k;
        }
    }
    // If I got my code to work.. (still wouldnt cuz it's o n^2
    //public class Solution
    //{
    //    public int RemoveElement(int[] nums, int val)
    //    {
    //        int k = 0;

    //        for (int i = 0; i < nums.Length; i++)
    //        {
    //            if (nums[i] == val)
    //            {
    //                // Shift everything after i one position to the left
    //                for (int j = i; j < nums.Length - 1; j++)
    //                {
    //                    nums[j] = nums[j + 1];
    //                }
    //                // Step back since the element at i is now a new value
    //                i--;
    //                // Track how many we removed
    //                k++;
    //            }
    //        }

    //        // k was counting removals, so kept = total - removed
    //        int kept = nums.Length - k;
    //        Console.WriteLine($"{kept}, nums = {string.Join(", ", nums)}");
    //        return kept;
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_Duplicates_from_Sorted_Array
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int k = 1; // first element is always unique

            for (int i = 1; i < nums.Length; i++)
            {
                // Since array is sorted, duplicates are always adjacent
                if (nums[i] != nums[k - 1])
                {
                    nums[k] = nums[i]; // place next unique element at front
                    k++;
                }
            }

            return k; // just return the count, not the array
        }
    }
}

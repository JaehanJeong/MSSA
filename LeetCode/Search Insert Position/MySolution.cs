using System;
using System.Collections.Generic;
using System.Text;

namespace Search_Insert_Position
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int targetLocation = 0;
            if (target < nums[0]) { return 0; }
            if (target > nums[nums.Length - 1]) { return nums.Length; }
            //int i = 0;
            while (target > nums[targetLocation])
            {
                targetLocation++;
            }
            return targetLocation;
        }
    }
}

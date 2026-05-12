using System;
using System.Collections.Generic;
using System.Text;

namespace Contains_Duplicate
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!seen.Add(num)) return true;
            }

            return false;
        }
    }
}

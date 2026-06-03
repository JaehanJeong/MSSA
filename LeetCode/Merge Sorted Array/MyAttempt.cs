using System;
using System.Collections.Generic;
using System.Text;

namespace Merge_Sorted_Array
{
    public class MyAttempt
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //Taking care of edge cases
            if (nums1.Length == 0 && nums2.Length == 0) { nums1 = []; }
            if (nums1.Length == 0) { nums1 = nums2; }
            if (nums2.Length == 0) { nums1 = nums1; }

            //One pointer for nums1
            //Another for nums2
            int i = 0;
            int j = 0;
            //Something's wrong about the condition
            while (i < nums1.Length - 1 && j < nums2.Length - 1)
            {
                if (nums1[i] > nums2[j])
                {
                    //we're overwriting so something is going wrong here.
                    nums1[i] = nums2[j];
                    j++;
                }
                i++;
            }
            Console.WriteLine(string.Join(", ", nums1));
        }
    }
}

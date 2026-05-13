using System;
using System.Collections.Generic;
using System.Text;

namespace Product_of_Arryay_Except_Self
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];

            // --- Pass 1: Left prefix products ---
            // answer[i] = product of everything to the LEFT of i
            answer[0] = 1; // nothing to the left of index 0
            for (int i = 1; i < n; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // --- Pass 2: Right suffix products ---
            // Multiply each answer[i] by the product of everything to the RIGHT of i
            int right = 1; // nothing to the right of the last index
            for (int i = n - 1; i >= 0; i--)
            {
                answer[i] *= right;
                right *= nums[i];
            }

            return answer;
        }
    }
}

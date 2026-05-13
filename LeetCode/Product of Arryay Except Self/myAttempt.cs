using System;
using System.Collections.Generic;
using System.Text;

namespace Product_of_Arryay_Except_Self
{
    internal class myAttempt
    {
        public int[] ProductExceptSelf(int[] nums)
        {

            //Create an output Array
            int[] answer = new int[nums.Length];

            //Edge case? empty array of nums
            if (nums.Length == 0) return answer;

            int product = 0;

            //As we iterate, multiply by the next value aka nums[i] 
            //EXCEPT for the given i.
            for (int i = 0, j = 0; i < answer.Length; i++)
            {
                if (i == j)
                {
                    //If it's THAT index you gota skip
                    continue;
                }
                else if (product == 0)
                {
                    nums[i] = product;
                    //continue;
                }
                else if (product != 0)
                {
                    product *= nums[i];
                }
            }
            return answer;
        }


        // Working version of 'Brute Force Approach'
        //public class Solution
        //{
        //    public int[] ProductExceptSelf(int[] nums)
        //    {

        //        int[] answer = new int[nums.Length];

        //        for (int i = 0; i < nums.Length; i++)
        //        {
        //            int product = 1;
        //            for (int j = 0; j < nums.Length; j++)
        //            {
        //                if (i != j)
        //                {
        //                    product *= nums[j];
        //                }
        //            }
        //            answer[i] = product;
        //        }

        //        return answer;
        //    }
        //}



    }
}

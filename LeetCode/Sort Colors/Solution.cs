public class Solution
{
    public void SortColors(int[] nums)
    {
        //Three Pointers
        //Low = Starting Point
        //Mid = Value we're checking as we iterate
        //High = End Point
        int low = 0, mid = 0, high = nums.Length - 1;

        while (mid <= high)
        //Stop condition is once the value we're checking passes the end point.
        {
            // 3 rules.

            // Rule 1: If the value we're checking is 0
            //         Then we swap it with low, and increment both
            //         Therefore, the head of the array upto where we check gets sorted.
            if (nums[mid] == 0)
            {
                // swap nums[mid] and nums[low], increment both
                int temp;
                temp = nums[mid];
                nums[mid] = nums[low];
                nums[low] = temp;
                low++;
                mid++;
            }

            //Rule 2: The number we're checking
            //        Is already where we want them to be.
            //        Therefore, we just increment mid to move along.
            else if (nums[mid] == 1)
            {
                // just move on
                mid++;
            }

            //Rule 3: The number we're checking is highest value (for sorting purposes)
            //        So we give that value to high and decrement high
            //        Now the 'high's are getting filled in from the right side
            //        As we decrement the high.
            else // nums[mid] == 2
            {
                // swap nums[mid] and nums[high], decrement high only
                int temp;
                temp = nums[mid];
                nums[mid] = nums[high];
                nums[high] = temp;
                high--;
            }
        }
    }
}
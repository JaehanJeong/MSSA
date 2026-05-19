namespace Mod7MergeSort
{
    internal class Program
    {

        //O (nlogn)
        // space: extra temp array : O(n)  
        static void Divide(int[]nums, int left, int right)
        {
            if (left<right)
            {
                int mid = (left + right) / 2;
                Divide(nums, left, mid); // dividing left half
                Divide(nums, mid + 1, right); // dividing right half
                Merge(nums , left, mid, right);
            }
        }

        static void Merge(int[] nums, int left, int mid, int right)
        {
            int i = left; // first index of left subarray
            int j = mid + 1; //first index of right subarray
            int[] temp = new int[right + 1]; // temp array to hold merged results
            int k = left; // index for temp array
            while(i<=mid && j<=right)
            {
                if (nums[i] <= nums[j])
                {
                    temp[k] = nums[i]; // smaller element from left subarray added to temp
                    i++;
                }
                else
                {
                    temp[k] = nums[j];
                    j++;
                }
                k++;
            }

            while(i<=mid) // more elements remaining in left subarray
            {
                temp[k] = nums[i];
                i++;
                k++;
            }
            while(j<=right)
            {
                temp[k] = nums[j];
                j++;
                k++;
            }
            //Can we avoid doing this step if
            for(int x = left; x<= right; x++)
            {
                nums[x] = temp[x]; // sorted subgroups are copied back in nums array.
            }


        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 12, 45, 1, 2, 67, 100, 56 };
            Divide(nums, 0, nums.Length - 1);
        }
    }
}

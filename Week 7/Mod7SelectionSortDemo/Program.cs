namespace Mod7SelectionSortDemo
{
    internal class Program
    {
        //O(n^2) time complexity || O(1) space complexity
        static void SelectionSort(int[] nums)
        {
            int minPosition, temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                //tracks the index of the smallest element found in the unsorted portion of array
                //assume the first element is the smallest
                minPosition = i;
                for(int j = i+1; j<nums.Length; j++)
                {
                    if (nums[j] < nums[minPosition])//found a smaller number
                    {
                        minPosition = j;
                    }
                }
                
                if(minPosition != i) //to avoid unnecessary swaps (aka with itself)
                {
                    temp = nums[i];
                    nums[i] = nums[minPosition];
                    nums[minPosition] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { 12, 1, 23, 15, 45, 90 };
            SelectionSort(nums); // If i have breakpoint here, then u wana have it in ur function to see debugging.
        }
    }
}

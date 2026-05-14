namespace Mod6BubbleSort
{
    internal class Program
    {
        static void BubbleSort(int[]nums)
        {
            for (int pass = nums.Length - 1; pass >= 0; pass--)
            {
                bool swapped = false;
                for(int i =0; i<pass; i++)
                {
                    if (nums[i] > nums[i+1])
                    {
                        int temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 9, 8, 8, 30, 12, 100, 1 };
            BubbleSort(nums);
            foreach(var i in nums)
            {
                Console.WriteLine(i);
            }
        }
    }
}

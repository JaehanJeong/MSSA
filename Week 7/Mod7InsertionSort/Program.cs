namespace Mod7InsertionSort
{
    internal class Program
    {

        static void InsertionSort(int[] nums)
        {
            int temp, position = 0;
            for(int i = 1; i<nums.Length; i++)//i = 1 cuz assume theres nothing to the left.
            {
                temp = nums[i]; //temp is the value to be inserted at correct position
                position = i; // index where the temp is to be inserted.
                while(position>0 && nums[position-1] > temp) // keeps on going till you find a lesser number on left
                {
                    nums[position] = nums[position - 1];//shift the larger number to rigiht
                    position--; // Necessary, otherwise how will we go to left?
                    // 11, 12, 34
                    
                }
                //nums[position] = temp; // skip the step when temp was already on the correct spot?
                if (position != i)
                {
                    nums[position] = temp;
                }
                //nums[0] = 4
                //position = 0
                // nums[position] = 4 
                // this is what we're trying to avoid.
            }
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 8, 9, 6, 2 };
            InsertionSort(nums);
        }
    }
}

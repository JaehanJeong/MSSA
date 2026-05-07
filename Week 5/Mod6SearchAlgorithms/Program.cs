namespace Mod6SearchAlgorithms
{
    internal class Program
    {
        // O(n)
        // Constant space complexity (we aren't declaring extra stuff)
        static bool LinearSearch(int[]arr, int target, out int index)
        {//out int index is a reference variable. You cant input value 
            for(int i = 0; i<arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        static int BinarySearch(int[]arr,int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid = 0;
            while(left<=right) // Terminating condition where they crossed each other
            {
                mid = (left+right)/2;
                if (target == mid) return mid; // If mid = target, we're done.
                else if (target < arr[mid]) right = mid - 1; // If target is smaller than mid, we narrow the right bound.
                else left = mid + 1; // Otherwise, (If target is bigger than mid), we raise the lower bound

            }
            return -1;
        }
        static void Main(string[] args)
        {
            
            if (LinearSearch(new int[] { 23, 34, 12, 45, 67, 444 }, 5555, out int index))
            {
                Console.WriteLine($"Element is found at {index}");
            }
            else { Console.WriteLine("Element was not found."); }

            Console.WriteLine("Binary Search");
            int val = BinarySearch(new int[] { 12, 34, 56, 788, 899 }, 56);
            if (val >= 0) // Make sure it's sorted. >=0 Ensures that we found it
            {
                Console.WriteLine($"Number found. at {val}");
            }
            else
                Console.WriteLine("Number not found :(");
        }
    }
}

//3.Given an integer array nums, move all 0's to the end of it
//while maintaining the relative order of the non-zero elements.

//Hard coded nums array
int[] nums = new int [] { 1, 2, 3, 0, 0, 4, 5, 6 };


//Count all the digits that aren't zeros.
int nonZeroCounter = 0;

//Before we start cookin, if nums null, we end.
if (nums == null || nums.Length == 0) return;

foreach (int num in nums)
{
    if (num != 0)
    //***We assign that number to the nums array of the index nonZeroCounter BEFORE we increment. ***
    { nums[nonZeroCounter++] = num; }
}

// Fill remaining indices with 0.
while (nonZeroCounter < nums.Length)
{
    nums[nonZeroCounter++] = 0;
}

//Printing out the nums array 
Console.WriteLine(string.Join(", ", nums));
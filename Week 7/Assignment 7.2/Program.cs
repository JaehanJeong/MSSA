static void Divide(int[]nums, int left, int right)
{
    if(left<right)
    {
        int mid = (left + right) / 2;
        Divide(nums, left, mid);
        Divide(nums, mid + 1, right);
        Merge(nums, left, mid, right);
    }
}

static void Merge(int[] nums, int left, int mid, int right)
{
    int i = left;      // Head of left subarray
    int j = mid + 1;   // Head of right subarray

    int[] temp = new int[right - left + 1];
    int k = 0;         // Reset k to 0 because temp starts at index 0

    while (i <= mid && j <= right)
    {
        if (nums[i] <= nums[j])
        {
            temp[k] = nums[i];
            i++;
        }
        else
        {
            temp[k] = nums[j];
            j++;
        }
        k++;
    }

    while (i <= mid)
    {
        temp[k] = nums[i];
        i++;
        k++;
    }
    while (j <= right)
    {
        temp[k] = nums[j];
        j++;
        k++;
    }
    for (int x = 0; x < temp.Length; x++)
    {
        nums[left + x] = temp[x];
    }
}


Console.Write("How many numbers do you want to enter? ");
int size = int.Parse(Console.ReadLine());

// Initialize the array with the size specified
int[] nums = new int[size];
int index = 0;

while (index < nums.Length)
{
    Console.Write($"Enter number for slot [{index}]: ");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int result))
    {
        nums[index] = result;
        index++; // Manually increment the tracking index to move to the next slot
    }
    else
    {
        Console.WriteLine("Invalid number. Please try again.");
    }
}

// 1. Call the Divide function to sort the array
// Pass 0 as the starting index (left) and nums.Length - 1 as the last index (right)
Divide(nums, 0, nums.Length - 1);

// 2. Print out the sorted array to verify it worked!
Console.WriteLine("\nYour array has been sorted using Merge Sort:");
Console.WriteLine(string.Join(", ", nums));


//Given a non - empty array of integers nums,
//every element appears twice except for one.
//Find that single one

int userInput = 0;


//User setting the array size.
while(true)
{
    Console.WriteLine("Enter the number of elements for your numbers array");
    if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0)
        break;
    Console.WriteLine("Please enter a valid positive whole integer.");
}

//Create the integer array with given size.
int[] numbers = new int[userInput];

//Have the user fill the int array.
for(int i = 0; i < userInput; i++)
{
    Console.WriteLine($"Please enter the number for index {i}");
    numbers[i] = int.Parse(Console.ReadLine());
}

Dictionary<int, int> count = new Dictionary<int, int>();

foreach (int num in numbers)
{

    if(count.ContainsKey(num))
    {
        count[num]++;
    }
    else
    {
        count[num] = 1;
    }
}

foreach (var pair in count)
{
    if(pair.Value ==1)
    {
        Console.WriteLine(pair.Key);
    }
}

//2. Given an array nums containing n distinct numbers in the range [0, n],
//return the only number in the range that is missing from the array.

Console.WriteLine("*****************NEXT QUESTION *****************");
//Set up a hypothetical range array.
int[] givenRange = {9, 6, 4, 2, 3, 5, 7, 0, 1};

//First attempt - Fails cuz once an element goes missing, everything after falls apart too.
//Loop thru the range
//for(int i = 0; i < givenRange.Length; i++)
//{
//    // Compare the index with what the value should be
//    if (givenRange[i] == i) 
//    {
//        Console.WriteLine($"The value of i is {i}.");
//        //Console.WriteLine($"The number missing from the array is {i}.");
//    }
//}

//Loop thru the range
for(int i = 0; i < givenRange.Length;i++)
{
    if (!givenRange.Contains(i)) //If the array does not contain that particular index's number,
    {
        Console.WriteLine($"The missing number is {i}.");
    }
}
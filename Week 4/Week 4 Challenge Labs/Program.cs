#region Question#1
// Question # 1

//1.If number contains 3

//Write a method that checks if given number (positive integer) contains digit 3.
//Do not convert number to other type.
//Do not use built-in functions like Contains(), StartsWith(), etc.

//Expected input and output
//IfNumberContains3(7201432) → true IfNumberContains3(87501) → false
bool IfNumberContains3()
{

    Console.WriteLine("Please enter the number you'd like to check for a 3.");
    // Step 1. Get the user input
    string input = Console.ReadLine();

    // Step 2. If parseable, continue. out _ means we aren't storing it anywhere.
    if (double.TryParse(input, out _))
    {
        //Check through the input string, one index at a time;
        for (int i = 0; i < input.Length; i++)
        {
            //if the value of the index is 3, return true
            if (input[i] == '3')
            {
                Console.WriteLine("True");
                return true;
            }
        }
        Console.WriteLine("False");
        return false;
    }
    Console.WriteLine("Invalid input. Please try again.");
    return false;
}
IfNumberContains3();
#endregion

#region Question#2
// Question # 2
//2.Divisible by 2 or 3

//Given two integers, write a method that returns their multiplication
//if they are both divisible by 2 or 3, otherwise returns their sum.

//Expected input and output
//DivisibleBy2Or3(15, 30) → 450
//DivisibleBy2Or3(2, 90) → 180
//DivisibleBy2Or3(7, 12) → 19

int DivisibleBy2Or3()
{
    Console.WriteLine("Please enter the first number for this operation.");
    bool validA = int.TryParse(Console.ReadLine(), out int a); // Get first Input

    Console.WriteLine("Please enter the second number for this operation.");
    bool validB = int.TryParse(Console.ReadLine(), out int b); // Get second Input

    if (!validA || !validB) // If either is invalid turn them away.
    {
        Console.WriteLine("Invalid input. Please try again.");
        return 0;
    }

    if ((a % 2 == 0 || a % 3 == 0) && (b % 2 == 0 || b % 3 == 0))
    {// If a is divisible by 2 or 3 AND b is divisible by 2 or 3, then
        int c = a * b; // get their product.
        Console.WriteLine(c);
        return c;
    }
    else
    { // Otherwise
        int d = a + b; // get their sum
        Console.WriteLine(d);
        return d;
    }
}
DivisibleBy2Or3();
#endregion

#region Question#3
// Question #3
//3.Write a function that reverses a string.
//The input string is given as an array of characters s.

//You must do this by modifying the input array in-place. (Problem 344 in leetcode)

void Leetcode344()
{
    Console.WriteLine("Please input an array of characters (string) for us to reverse.");
    string s = Console.ReadLine() ?? ""; //Even if user enters empty string we don't crash.
    char[] array = s.ToCharArray(); // Convert string to char array cuz strings are immutable

    for (int i = 0; i < s.Length / 2; i++) // Loop thru half way only cuz that's all we need
    {
        char temp = array[i]; // store the first value in a temporary variable
        array[i] = array[array.Length - 1 - i]; // assign the last value as the first
        array[array.Length - 1 - i] = temp; // assign the temp value as the last.
    }
    string reversedString = new string(array); // Make our new string with the char array
    Console.WriteLine(reversedString);
}
Leetcode344(); 
#endregion
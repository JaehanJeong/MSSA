#region Question#1
// Quesiton#1
//1.Given an integer x, return true if x is a palindrome, and false otherwise.

bool IsNumPalindrome()
{
    Console.WriteLine("Please enter the number you'd like to check.");
    string userInput = Console.ReadLine();
    //First check if the user input is valid number
    if (!int.TryParse(userInput, out int number))
        return false;

    //If number is negative, then it's gona be false right away.
    if (number < 0)
        return false;

    //Finally good ol' palindrome
    for (int i = 0; i < userInput.Length / 2; i++)
    {
        if (userInput[i] != userInput[userInput.Length - 1])
        {
            return false;
        }
    }
    Console.WriteLine("TRUE!");
    return true;
}
IsNumPalindrome();
#endregion

#region Question#2
//Question #2
//2.Write a program in C# Sharp to create a function to calculate
//the sum of the individual digits of a given number.
//Special Instruction: Don't convert the input type.

int SumOfDigits()
{
    Console.WriteLine("Please enter the number you'd like to sum up.");
    string userInput = Console.ReadLine();

    //First check if the user input is valid number
    if (!int.TryParse(userInput, out int number))
    {
        Console.WriteLine("Invalid input. Please try again");
        return 0;
    }
    //Call the recursive function with the input
    int result = RecursionAddition(number);

    // Output the result
    Console.WriteLine(result);
    return result;


    //Recursive function 
    int RecursionAddition(int number) // Take in the user input
    {
        if (number == 0) // If the number is 0, end the function; nothing to add
        {
            return 0;
        }
        int lastDigit = number % 10; // Current digit of the number we're working with

        // Get this digit and then call itself again without the last digit.
        return lastDigit + RecursionAddition(number / 10);
    }
}
SumOfDigits();
#endregion

// Question # 3
// 3.Given an integer array nums,
// return true if any value appears at least twice in the array,
// and return false if every element is distinct.

bool RepeatOrNot ()
{
    Console.WriteLine("Please enter the number you'd like to check for duplicates.Put a space between each number");
    string input = Console.ReadLine();
    string[] inputPieces = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //Dictionary<int, int> dict = new Dictionary<int, int>();
    //Was using dictionary but learned Hash cuz apparently it's better fit for this problem.
    HashSet<int> set = new HashSet<int>();
    for (int i = 0; i < inputPieces.Length; i++)
    {
        if (!int.TryParse(inputPieces[i], out int number))
        {
            return false;
        }
        
        //if (dict.ContainsKey(number))
        //if (set.Contains(number))
        //{
        //    return true;
        //}
        //else
        //{
        //    //dict.Add(number, 1);
        //    set.Add(number);
        //}
        if (!set.Add(number)) // If adding the number failed
            //Hash add is a bool function that will try to add
            // and only add if there is no duplicate.
            // So if it adds, then there was no duplicate.
            // If it fails to add, thent here is a duplicate.
        {
            return true; // Means there was a duplicate so return true.
        }
    }return false;
}
// LINQ One liner
//bool hasDuplicates = nums.Distinct().Count() != nums.Length;
// Translation: True or false: does it have duplicate?
// Distinct() removes duplicates and then Count(), counts.
// nums.Length means how many items are in the original array
// If the length is different, after removing duplicates, that means duplicates exist.

RepeatOrNot ();


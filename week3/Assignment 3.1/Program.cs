// Assignment 3.1 
// By. Jaehan Jeong
// Date: 2026 April 20th

//Return even numbers
//Write a method that returns a string of even numbers greater than 0 and less than 100.

//(Use StringBuilder class)

//Expected input and output

//ReturnEvenNumbers() → "2 4 6 8 10 12 14 16 18 20 22 24 26 28 30 32 34 36 38 40 42 44 46 48 50 52 54 56 58 60 62 64 66 68 70 72 74 76 78 80 82 84 86 88 90 92 94 96 98"

using System.ComponentModel;
using System.Numerics;
using System.Text;

ReturnEvenNumbers();


// What I went with. 
void ReturnEvenNumbers()
{
    string evenNumbers = "";
    StringBuilder stringBuilder = new StringBuilder();
    
    for (int i = 2; i < 100;  i++)
    {
        if(i % 2 == 0)
        {
            //evenNumbers += i.ToString(); This is how we would do it using concatenation, but we want to use string builder for memory optimization.
            stringBuilder.Append($"{i} ");

        }
        else
        {
            continue;
        }

    }
    string finalOutput = stringBuilder.ToString().TrimEnd();
    Console.WriteLine(finalOutput);

}


// How Gemini suggested I could improve:
//void ReturnEvenNumbers()
//{
//    string evenNumbers = "";
//    StringBuilder stringBuilder = new StringBuilder();



// THAT IS GENIUS!!
// WE DONT NEED THIS LOGIC IF WE INCREMENT BY 2!!!!!
//    for (int i = 2; i < 100; i+=2)
//    {
//            stringBuilder.Append($"{i} ");
//    }


//    }
//    string finalOutput = stringBuilder.ToString().TrimEnd();
//    Console.WriteLine(finalOutput);

//}

// =======================END OF QUESTION 1====================================================================================================================================================
//2.If year is leap

//Given a year as integer, write a method that checks if year is leap.
// I didn't know what specifications exist for leap year besides divisible by 4, so I looked up and got the 3 conditions:
//The Basic Rule: The year must be evenly divisible by 4.

//The Exception: If the year is also evenly divisible by 100, it is NOT a leap year...

//The Exception to the Exception: ...UNLESS the year is also evenly divisible by 400. Then it is a leap year.

//Expected input and output

//IfYearIsLeap(2016) → true IfYearIsLeap(2018) → false


Console.WriteLine("Please enter your year."); 
int year = Convert.ToInt32(Console.ReadLine());  // Take the user's input the year they want to test.
IfYearIsLeap(year); // Call the function with user input as the argument

//Function to test if the year is a leap year.
bool IfYearIsLeap(int year) { //Returns true or false with user input as the argument
    if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) // If  a) year is divisible by 4 b) AND not divisible by100 OR c) year is not divisible by 400
    {
        Console.WriteLine($"Your year {year} is a leap year."); // Then the year is a leap year.
        return true;
    }
    else
        Console.WriteLine($"Your year {year} is not a leap year."); // Otherwise, it's not a leapy year.
    return false;
}

// ===============================    END OF QUESTION 2 ==========================

//3.Write a program in C# Sharp to create a function to input a string and count number of spaces that are in the string.
//Test Data :
//Please input a string : This is a test string.
//Expected Output :
//"This is a test string." contains 4 spaces


void countSpaces () //Creating a function to run Question 3 - counting spaces
{
    Console.WriteLine("Please enter the string you would like to test.");
    string userInput = Console.ReadLine(); // Take user input to test
    int numberOfSpaces = 0;
    foreach (char c in userInput) // For each character in userInput String, do the following:
    {
        if (c == ' ') // If the given character IS ' ' aka SPACE,
        {
            numberOfSpaces++; // Then add to the numberOfSpaces counter.
        }
    }

    Console.WriteLine($"{userInput} contains {numberOfSpaces} spaces!"); // Print to console that user input has x number of spaces.
}
countSpaces();


// ==============================================   END OF QUESTION 3 ===========================================
//4.Write a function which takes an array as input and finds the first occurrence of 2 consecutive 1s and changes their value to 0.

//For e.g: Input: [0, 2, 1, 1, 9, 1, 1]

//Output: [0, 2, 0, 0, 9, 1, 1]

void replaceFirstTwoOnes () // Create a function to run Question 4 - replace the first two 1's.
{
    string[] userInputs = new string[7]; // Declare a string array with size 7. Don't know list well enough yet to make the list size (user entry) dynamic.
    Console.WriteLine("Please enter the seven numbers you would like to go through this beautification :) "); // Prompt user to input the numbers to go into this method.
    for (int i = 0; i < 7; i++) // Fill our userInputs string array with user inputs 7 times.
    {
        userInputs[i] = Console.ReadLine();
    }

    //Now that we have the string array filled with user inputs, we add logic to find the first consecutive 1's and replace them with 0s.
    int replaceableCounter = 1; // To ensure that we only replace the very first one.
    for (int i = 0; i < userInputs.Length-1; i++) // Go through the string array userInputs (-1 because we can't compare last index with last index + 1).
    {
        // Convert userInput's string values and check if it's 1 AND if the next index's value is also 1 AND check if replacement has been made
        if (Convert.ToInt32(userInputs[i]) == 1 && Convert.ToInt32(userInputs[i+1]) == 1 && replaceableCounter > 0) // Values inside string array needs to be converted to get tested.
        {
            //If passes the above test
            userInputs[i] = "0"; // This index's value will be 0
            userInputs[i + 1] = "0"; // The next index's value will also be 0
            replaceableCounter --; // Subtract counter so we don't repeat this.
        }
    }
    //Console.WriteLine(userInputs); I gota memorize this syntax to print string arrays.
    Console.WriteLine(string.Join(",", userInputs));
}

replaceFirstTwoOnes();
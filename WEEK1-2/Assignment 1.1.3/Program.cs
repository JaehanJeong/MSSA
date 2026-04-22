//Assignment 1.1.3
//By. Jaehan Jeong
//APR 07 2026

// 1. Write a program in C# to calculate area of triangle, square and rectangle.
// Write 3 different functions for each shape to take dimensions of figure and display the area. You may create menus.

bool runProgram = true;

double calculateTriangleArea(double b, double h)
{
    double triangleArea = (b * h) / 2;
    return triangleArea;
}

/* Not needed! Cuz we'll pass widths to rectangle)
double calculateSquareArea(double squareWidth)
{
    double squareArea = (squareWidth * squareWidth);
    return squareArea;
}
*/
double calculateRectangleArea(double l, double w)
{
    double calculateRectangleArea = (l * w);
    return calculateRectangleArea;
}

do
{
    Console.WriteLine("We will calculate area of the shape you choose. Choose one to begin shape maxing.");
    Console.WriteLine("1. Triangle.");
    Console.WriteLine("2. Square.");
    Console.WriteLine("3. Rectangle.");
    Console.WriteLine("4. Exit Program.");
    int userInput = Convert.ToInt32(Console.ReadLine());
    switch (userInput)
    {
        case 1: //Triangle
            Console.WriteLine("Please enter the length of the base of the triangle");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the length of the height of the triangle");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"The area of your triangle is {calculateTriangleArea(b, h)}");
            break;
        case 2: //Square
            Console.WriteLine("Please enter the width of the square");
            double squareWidth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"The area of your square is {calculateRectangleArea(squareWidth, squareWidth)}");
            break;

        case 3: //Rectangle
            Console.WriteLine("Please enter the width of the rectangle");
            double w = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the length of the rectangle");
            double l = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"The area of your rectangle is {calculateRectangleArea(l, w)}");
            break;
        case 4: //Exit Program
            Console.WriteLine("Thanks for playing. Good bye.");
            runProgram = false;
            break;
        default:
            Console.WriteLine("Please enter a valid option.");
            break;
    }

}
while (runProgram == true);

// 2. Write a console application in C# to explore different ways in which
//    array is declared and initialized and explore different properties and methods of Array class.

// Ways to declare an Array
// 1. string[] cars;
// 2. 


// From W3 Schools
// Create an array of four elements, and add values later
// string[] cars = new string[4];
// When would this get used? 
// A: When you know the size of the array, but don't know the elements yet.

// Create an array of four elements and add values right away 
// string[] cars = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };
// When would this get used?
// A: When you know the size and elements of your array.

// Create an array of four elements without specifying the size 
// string[] cars = new string[] { "Volvo", "BMW", "Ford", "Mazda" };
// When would this get used?
// When you know the elements of your array, but don't know the size of the array.
// Extra comments: Good when you want to declare and initialize on the same line.

// Create an array of four elements, omitting the new keyword, and without specifying the size
// string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
// When would this get used?
// Only time you NEED 'new' is when you want to separate assignment and declaration.

// Array BAD WHEN:
// 1. You want the size to be flexible.
// 2. Hard to search
// 3. Expensive processing (hard to delete or insert)
// 4. Can fail at runtime (compiler may crash it)
// 5. Doesn't let you decide HOW to process your data.
/*
// Create 12 slots for MSSA attendees. We can fill up each slot whenever a candidates is accepted.
string[] mssaAttendees = new string[12];

// Create an array for my stock portfolio that contains 3 different stocks.
string[] myStocks = new string[3] { "MSFT", "GOOG", "FB" };

// Create an array of pokemons. If we were to add pokemon later, you don't have to manually change the size - since it will update accordingly.
string[] pokemon = new string[] { "Pikachu", "Bulbasaur", "Charmander" };

// Most concise textbook way of delcaring an array in 1 line. DECLARE AND INITIALIZE AT ONCE!
string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

// Implicitly Typed the VAR way
var colors = new[] { "Yellow", "Blue", "Purple" };

// Target typed
string 

    */
// 3. Write a program in C# to read n number of values in an array and display it in reverse order.
// Create 
//First attempt.No go cuz it uses two arrays.
/*
int[] testArray = new int[3] { 2, 5, 7 };
int[] reverseArray = new int[3];
//Print array sanity check
Console.WriteLine($" The values store into the array are: {string.Join(",", testArray)}");


// j for the index of reverseArray
int j = 0;
for (int i = testArray.Length - 1; i >= 0; i--)
{
    //Console.WriteLine($"The values store into the array in reverse are : {testArray[i]}");
    reverseArray[j] = testArray[i];
    j++;
}

Console.WriteLine($"The values store into the array in reverse are : {string.Join(",",reverseArray)}");
*/

// Second way found bouncing ideas with higher beings
// Learned there's a reverse function lol
//var reversed = testArray.Reverse().ToArray();
//Console.WriteLine(string.Join(",", reversed));
// Can't use for class :) just for personal knowledge.




//For(i = 0; i < n / 2; i++)
//3 way swap for 1/2 length of the array using temp.
//n is the length of the array.
/* working version
int[] testArray = new int[3] { 2, 5, 7 };
Console.WriteLine($"The values store into the array are: {string.Join(",", testArray)}");
int temp = 0;
for(int i = 0; i < (testArray.Length)/2; i++)
{
    temp = testArray[i]; //First, store the first value in a temporary variable.
    testArray[i] = testArray[testArray.Length - 1 - i]; //Now, the first element will be assigned with the last element of the array that needs change.
    testArray[testArray.Length - 1] = temp; // Then, we assign the last element that we took away with the temp variable to complete the swap.
    //Console.WriteLine(temp);
    //Console.WriteLine(testArray[i]);
    //Console.WriteLine(testArray[testArray.Length - 1]);

}

Console.WriteLine($"The values store into the array in reverse are : {string.Join(",", testArray)}");
*/



//Let's try to allow the user to make the array themselves.
//First, Have them enter the size
Console.WriteLine("Lets make your array of numbers! First, enter the number of elements you will have in your array.");

int arraySize = Convert.ToInt32(Console.ReadLine()); // User's input gets converted to int, which will be the size of our array.
int [] userArray = new int[arraySize]; // We define user's array, using the size they just gave. No values entered yet.
int temp = 0; // temp variable to do swaperoni (reversal)
Console.WriteLine("Okay. Now we will ask you to input the value of each element one at a time.");


//Loop that will allow user to fill up their array with values for each element.
//For now we'll assume that the user has to fill all the elements (no empty slots)
for (int i = 0; i < arraySize; i++)
{
    Console.WriteLine($"Please enter the value for spot {i}");
    userArray[i] = Convert.ToInt32(Console.ReadLine());
}

//Show what great work the user has done so far.
Console.WriteLine($"Your array looks like this: {string.Join(",", userArray)}");
Console.WriteLine("Now, we shall flip it.");

//Reversal
for (int i = 0; i < (userArray.Length) / 2; i++) //Starting with first index, we go half way because each flip takes care of 1 element from both ends.
{
    temp = userArray[i]; //First, store the first value in a temporary variable.
    userArray[i] = userArray[userArray.Length - 1 - i]; //Now, the first element will be assigned with the last element of the array that needs change.
    userArray[userArray.Length - 1 - i] = temp; // Finally, the last element is assigned temp which stored the very first value of the array.
}

Console.WriteLine($"Your original array in reverse looks like : {string.Join(",", userArray)}");
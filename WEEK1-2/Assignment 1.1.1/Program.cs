/*
 * 1. Create a console application in C# to store and print personal details of a person like name, age and address on console screen. Madke use of appropriate variables.
   2. Write a C# program to print the sum of two numbers. Get the input from user.
   3. Write a C# program to print the result of dividing two numbers. Print the quotient and remainder as well. Get the input from the user.
 */
//1. 
string name = "Jaehan";
string address = "123 Joe ST";
int age = 12;
//Console.WriteLine("Your name is " + name + "," + " and your address is " + address + "," + " and your age is " + age);
//Convert using string interpolation
Console.WriteLine($"Your name is {name}, and your address is {address}, and your age is {age}");

//2.
Console.WriteLine("We will add the two numbers you give. Please enter your first number here");
string firstEntry = Console.ReadLine();

Console.WriteLine("Please enter your second number");
string secondEntry = Console.ReadLine();

int answer = Convert.ToInt32(firstEntry) + Convert.ToInt32(secondEntry);

Console.WriteLine("The sum of the two numbers you entered is " + answer);

//3.
Console.WriteLine("We will divide your first number by the second number to give you a quotient and a remainder. Please enter the first number");
string firstNum = Console.ReadLine();

Console.WriteLine("Now please enter the second number, the one that you will divide the first number by");
string secondNum = Console.ReadLine();

double quotient = Convert.ToInt32(firstNum) / Convert.ToInt32(secondNum);
double remainder = Convert.ToInt32(firstNum) % Convert.ToInt32(secondNum);
double divisionResult = Convert.ToDouble(firstNum) / Convert.ToDouble(secondNum);

//Console.WriteLine("When you divide the " + firstNum + " by the " + secondNum + ", you get " + divisionResult + ".");
//Converting to string interpolation
Console.WriteLine($"When you divide {firstNum} by {secondNum}, you get {divisionResult}. ");

//Console.WriteLine("Your quotient is " + quotient + "," + " and your remainder is " + remainder);
//Using string interpolation
Console.WriteLine($"Your quotient is {quotient}, and your remainder is {remainder}.");

/*Ways to improve
    1. Input validation: This program will fail if user enters string for integer, or try to divide by 0. 
        Solution would be using tryParse? to see if you can take user input and work with it, and give error message otherwise.


*/
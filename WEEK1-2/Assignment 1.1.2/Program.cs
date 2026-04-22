/* Assignment Detail
 * 1. Write a C# Sharp program to accept two integers and check whether they are equal or not.
 * 2. Write a C# Sharp program to find the sum of first 10 natural numbers.
 * 3. Write a menu driven application to perform calculation functions like addition, subtraction, multiplication, and division. 
 * Call them appropriately when user selects the option. Give the user the option to continue or exit the program.
 */

//BY. Jaehan Jeong
//Assignment 1.1.2
//April 07 2026


//1. Write a C# Sharp program to accept two integers and check whether they are equal or not.
bool repeatTask1 = true;
do
{
    Console.Clear();
    Console.WriteLine("We will compare whether your two numbers are equal or not! Now, please enter your first number. ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();


    Console.WriteLine("Please enter your second number");
    int number2 = Convert.ToInt32(Console.ReadLine());
    if (number1 == number2)
    {
        Console.WriteLine($"Your numbers: {number1} and {number2} are indeed equal!");
    }
    else
    {
        Console.WriteLine($"Your numbers {number1} and {number2} were not equal!");
    }

    Console.WriteLine("\nWould you like to run this program again? Type YES to continue, type Quit to end the program.");
    string keepGoing = Console.ReadLine();
    if (keepGoing == "YES")
    {
        repeatTask1 = true;
        Console.WriteLine("Restarting the program.");
    }
    else if (keepGoing == "Quit")
    {
        repeatTask1 = false;
    }
    else
    {
        repeatTask1 = false;
        Console.WriteLine("Invalid input. Exiting the program.");
    }
}
while (repeatTask1 == true);


//2. Write a C# Sharp program to find the sum of first 10 natural numbers.
//Mistake 1: Again, forgot to add parenthesis for the while loop.
//Mistake 2: forgot to i++ to iterate thru the loop
//Mistake 3: made it i<10 instead of 11. Gota include our boy #10.
/* Tried using while loop before class portion 
 * We shouldn't use while loop (from my understanding) because for loop is healthier for variable scope.
 * int sumOfFirstTen = 0;
int i = 1;
while (i < 11){
    sumOfFirstTen += i;
    i++;
}
Console.WriteLine($"The sum of the first 10 natural numbers is {sumOfFirstTen}");
*/
int[] tenNums = new int[10];
int sumofFirstTen = 0;
for (int i = 0; i < 10; i++) {
    sumofFirstTen += i+1;
    tenNums[i] = i+1;
}
// Console.WriteLine($"The first 10 natural number is : {tenNums}"); this pointed me to the array's location. Googled to find the next line.
Console.WriteLine($"The first 10 natural number is: {string.Join(", ", tenNums)}");
Console.WriteLine($"The Sum is : {sumofFirstTen}");




//3. Write a menu driven application to perform calculation functions like addition, subtraction, multiplication, and division. 
//   Call them appropriately when user selects the option. Give the user the option to continue or exit the program.
bool powerOn = true; //Power on the calculator
double startingNum = 0; // We start the calculator at 0
do
{
    //Console.Clear();
    Console.WriteLine($"Your current total is {startingNum}. \nNow, please enter a number choose from the following options.");
    Console.WriteLine("1. Change the starting number.");
    Console.WriteLine("2. Add");
    Console.WriteLine("3. Subtract");
    Console.WriteLine("4. Multiply");
    Console.WriteLine("5. Divide");
    Console.WriteLine("6. Exit the program");

    int menuChoice = Convert.ToInt32(Console.ReadLine());

    switch (menuChoice)
    {
        case 1:
            // Change the starting number
            Console.WriteLine("Please enter a number you would like to start with.");
            string? newNum = Console.ReadLine();
            startingNum = Convert.ToDouble(newNum);
            break;
        case 2:
            //Addition
            Console.WriteLine("Please enter the number you would like to add.");
            string? addNum = Console.ReadLine();
            startingNum += Convert.ToDouble(addNum);
            break;
        case 3:
            // Subtraction
            Console.WriteLine("Please enter the number you would like to subtract.");
            string? subtractNum = Console.ReadLine();
            startingNum -= Convert.ToDouble(subtractNum);
            break;
        case 4:
            // Multiplication
            Console.WriteLine("Please enter the number you would like to multiply.");
            string? multiplyNum = Console.ReadLine();
            startingNum *= Convert.ToDouble(multiplyNum);
            break;
        case 5:
            // Division
            Console.WriteLine("Please enter the number you would like to divide");
            string? divideNum = Console.ReadLine();
            startingNum /= Convert.ToDouble(divideNum);
            break;
        case 6:
            // Exit the program
            powerOn = false;
            Console.WriteLine("Turning off power");
            break;
        default:
            //In case user mistypes an option or trolls
            Console.WriteLine("Please enter a valid input. Try again.");
            break;
    }
}

while (powerOn == true) ;



string startNum? =  Console.ReadLine();

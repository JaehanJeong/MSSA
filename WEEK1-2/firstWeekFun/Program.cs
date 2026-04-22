static void Assignment111()
{
    //1. 
    string name = "Jaehan";
    string address = "123 Joe ST";
    int age = 12;
    //Console.WriteLine("Your name is " + name + "," + " and your address is " + address + "," + " and your age is " + age);
    //Convert using string interpolation
    Console.WriteLine($"Your name is {name}, and your address is {address}, and your age is {age}");
}

static void Assignment112()
{
    //2.
    Console.WriteLine("We will add the two numbers you give. Please enter your first number here");
    string firstEntry = Console.ReadLine();

    Console.WriteLine("Please enter your second number");
    string secondEntry = Console.ReadLine();

    int answer = Convert.ToInt32(firstEntry) + Convert.ToInt32(secondEntry);

    Console.WriteLine("The sum of the two numbers you entered is " + answer);
}

static void Assignment113()
{
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
}
// ============================================== END OF ASSIGNMENT 111 ===========================================

static void Assignment121()
{

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
}

static void Assignment122()
{
    int[] tenNums = new int[10];
    int sumofFirstTen = 0;
    for (int i = 0; i < 10; i++)
    {
        sumofFirstTen += i + 1;
        tenNums[i] = i + 1;
    }
    // Console.WriteLine($"The first 10 natural number is : {tenNums}"); this pointed me to the array's location. Googled to find the next line.
    Console.WriteLine($"The first 10 natural number is: {string.Join(", ", tenNums)}");
    Console.WriteLine($"The Sum is : {sumofFirstTen}");
}

static void Assignment123()
{
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

    while (powerOn == true);



    string startNum = Console.ReadLine();
}
// ============================================== END OF ASSIGNMENT 112 ===========================================
// START OF EDABIT QUESTS
static void ConvertMinutesToSeconds()
{
    Console.WriteLine("We will convert the minutes you give us into seconds.\nPlease enter the minutes. ");
    double userMinutes = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"You entered {userMinutes} minutes. That is {userMinutes * 60} seconds.");
}
static void ReturnTheNextNumberFromTheIntegerPassed()
{
    Console.WriteLine("We will return the next number from the integer you give us. \nPlease enter the integer. ");
    int userInteger = Convert.ToInt32((Console.ReadLine()));
    Console.WriteLine($"You entered {userInteger}. The next integer would OBVIOUSLY be {userInteger + 1}");
}

static void CircuitPowerCalculator ()
{
    Console.WriteLine("We will calculate the power by multiplying the voltage and current you give us. Please enter the voltage to begin.");
    double userVoltage = Convert.ToDouble((Console.ReadLine()));
    Console.WriteLine("Please enter the current to continue.");
    double userCurrent = Convert.ToDouble((Console.ReadLine()));
    Console.WriteLine($"The power is {userVoltage * userCurrent}.");
}


// END OF EDABIT QUESTS


bool programOn = true;
do
{
    //Console.Clear();
    Console.WriteLine("Please choose from the following assignments you would like to see!\n");
    Console.WriteLine("1. Assignment 111 - store and print personal details of a person like name, age and address on console screen.\n");
    Console.WriteLine("2. Assignment 112 - write a C# program to print the sum of two numbers. Get the input from user.\n");
    Console.WriteLine("3. Assignment 113 - write a C# program to print the result of dividing two numbers. Print the quotient and remainder as well. Get the input from the user.\n");
    Console.WriteLine("4. Assignment 121 - Write a C# Sharp program to accept two integers and check whether they are equal or not.\n");
    Console.WriteLine("5. Assignment 122 - Write a C# Sharp program to find the sum of first 10 natural numbers.\n");
    Console.WriteLine("6. Assignment 123 - Write a menu driven application to perform calculation functions like addition, subtraction, multiplication, and division. Call them appropriately when user selects the option. Give the user the option to continue or exit the program.\n");
    Console.WriteLine("7. Edabit assignment1 - Convert minutes to seconds\n");
    Console.WriteLine("8. Return the next integer passed.\n");
    Console.WriteLine("9. Circuit Power Calculator\n");
    Console.WriteLine("10. Done exploring. Let me out!\n ");
    Console.WriteLine("===================================================================");

    int menuOption = Convert.ToInt32(Console.ReadLine());

    switch (menuOption)
    {
        case 1: Assignment111();break;
        case 2: Assignment112();break;
        case 3: Assignment113();break;
        case 4: Assignment121();break;
        case 5: Assignment122();break;
        case 6: Assignment123();break;
        case 7: ConvertMinutesToSeconds();break;
        case 8: ReturnTheNextNumberFromTheIntegerPassed();break;
        case 9: CircuitPowerCalculator();break;
        case 10:
            Console.WriteLine("Thank you for checking out! Have a nice day");
            programOn = false;break;
    }
}

while (programOn == true);
//1.Write a console application to create a text file
//and save your basic details like name, age, address ( use dummy data).
//Read the details from same file and print on console.

using System.Globalization;

int programOn = 1;
do
{
    
    Console.WriteLine("Please choose from the following.");
    Console.WriteLine("Enter 1 if you'd like to save your personal info to a text file.");
    Console.WriteLine("Enter 2 if you'd like to use our tip calculator");
    Console.WriteLine("Enter 3 if you'd like to exit the program.");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1: assignmentTwoPointThreePartOne();
            break;
        case 2: assignmentTwoPointThreePartTwo();
            break;
        case 3:
            programOn = programOn - 1;
            break;
        default:
            break;
    }
} while (programOn == 1);


void assignmentTwoPointThreePartOne()
{
    int powerOn = 1;

    do
    {
        Console.WriteLine("Please type in your name.");
        string userName = Console.ReadLine();
        Console.WriteLine("Please type in your age.");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please type in your address.");
        string address = Console.ReadLine();

        // Set a variable to the Documents path.
        string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Exact file location
        string filePath = Path.Combine(docPath, "PersonInfo.txt");

        // Create a string array with the lines of text
        string[] userInfo =
        {
            userName,
            age.ToString(),
            address
        };

        // Now test if #1 and #2 work by calling those 2 methods with data we sent up at the start.
        WriteFile(filePath, userInfo); // 1. Write the text to the file
        string text = ReadFile(filePath); // 2. Read the file from the file
        Console.WriteLine(text); // 3. Output the text to the console
        Console.WriteLine("Type continue to try again, or exit to exit.");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "continue")
        {
            powerOn = 1;
        }
        else if (userInput == "exit")
        {
            powerOn = 0;
        }
    } while (powerOn == 1);
}

// Left these file I/O outside because maybe this kind of methods will be used outside of simple functions.
// Function to write the string array into a file in the given file path.
void WriteFile(string filePath, string[] lines)
{
    File.WriteAllLines(filePath, lines);
}

// Try to read the file we wrote.
string ReadFile(string filePath)
{
    try
    {
        return File.ReadAllText(filePath);
    }
    catch (IOException)
    {
        return "Error reading file.";
    }
}

//2. Design a tip calculator : enter the bill total, tip % and display grand total after adding tip.

//Use the format specifiers to display currency, % symbol.
void assignmentTwoPointThreePartTwo()
{
    int powerOn = 1;
    do
    {
        Console.WriteLine("Welcome to tip calculator.");
        Console.WriteLine("We will calculate your grand total after adding tip.");

        Console.WriteLine("First, please enter your total bill.");
        decimal totalBill = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Next, enter the percentage of tip you would like to give");
        decimal tipPercentage = Convert.ToDecimal(Console.ReadLine())/100;
        decimal grandTotal = totalBill + totalBill*(tipPercentage / 100);

        Console.WriteLine($"Your total bill was {totalBill.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
        Console.WriteLine($"Your tip was {tipPercentage:P}");
        Console.WriteLine($"Your grand total is {grandTotal.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

        Console.WriteLine("Type continue to try again, or exit to exit.");
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "continue")
        {
            powerOn = 1;
        }
        else if (userInput == "exit")
        {
            powerOn = 0;
        }
    } while (powerOn == 1);



} 
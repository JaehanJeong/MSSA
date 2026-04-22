
using Week2ChallengeLabs.Models;
using System.Linq;

int programOn = 1;
do
{
    Console.WriteLine("Please choose from the following.");
    Console.WriteLine("Enter 1 if you'd like to use the bizarre weather interpretation.");
    Console.WriteLine("Enter 2 if you'd like to try the login attempt application.");
    Console.WriteLine("Enter 3 if you'd like to try the triangle using user input application.");
    Console.WriteLine("Enter 4 if you'd like to try the student grade presentation.");
    Console.WriteLine("Enter 5 if you'd like to exit the program.");
    int userInput = Convert.ToInt32(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            challengePart1();
            break;
        case 2:
            challengePart2();
            break;
        case 3:
            challengePart3();
            break;
        case 4: 
            challengePart4();
            break;
        case 5:
            programOn = programOn - 1;
            break;
        default:
            break;
    }

} while (programOn == 1);


//challengePart1();

//Write a C# Sharp program to read temperature in Fahrenheit and display a suitable message according to temperature state below :
//Temp 0< 10 then Freezing weather
//Temp 11-20 then Very Cold weather
//Temp 21-35 then Cold weather
//Temp 36-50 then Normal in Weather
//Temp 51-65 then Its Hot
//Temp 66-80 then Its Very Hot
//Test Data :
//67
//Expected Output :
//Its very hot.
//powerOn = powerOn - 1;
void challengePart1()
{
    int powerOn = 1;

    do
    {
        Console.WriteLine("We will tell you how bad or nice your current temperature is. ");
        Console.WriteLine("Please enter your temperature or type 999 to exit the program.");
        int userInput = Convert.ToInt32(Console.ReadLine());
        if (userInput == 999)
        {
            powerOn = 0;
            continue;
        }

        switch (userInput)
        {
            case int n when (n > 80):
                Console.WriteLine("Your area is inhabitable!!");
                break;

            case int n when (n <= 80 && n >= 66):
                Console.WriteLine("Your area is very hot!");
                break;
            case int n when (n <= 65 && n >= 51):
                Console.WriteLine("Your area is pretty normal.");
                break;
            case int n when (n <= 50 && n >= 36):
                Console.WriteLine("Your area is kinda cold.");
                break;
            case int n when (n <= 35 && n >= 21):
                Console.WriteLine("Your area is pretty cold.");
                break;
            case int n when (n <= 20 && n >= 11):
                Console.WriteLine("Your area is cold.");
                break;
            case int n when (n < 10):
                Console.WriteLine("Your area is pretty FREEZING!");
                break;
                //case int n when (n == 999):
                //    powerOn = powerOn - 1;
                //    break;
                //case 999:
                //    powerOn = powerOn - 1;
                //    break;
        }


    } while (powerOn == 1);
}

//2.Write a C# Sharp program that takes userid and password as input (type string).
//After 3 wrong attempts, user will be rejected.

//challengePart2();

void challengePart2()
{
    int remainingAttempt = 3;
    bool loginStatus = false;
    string correctUserName = "testLogin";
    string correctPassWord = "1234";

    while (remainingAttempt > 0 && !loginStatus)
    {
        Console.WriteLine("Please enter your user name.");
        string userName = Console.ReadLine();

        Console.WriteLine("Please enter your password");
        string passWord = Console.ReadLine();

        if (userName == correctUserName && passWord == correctPassWord)
        {
            Console.WriteLine("You're logged in!");
            loginStatus = true;
        }
        else
        {
            remainingAttempt--;
            Console.WriteLine($"Your username and password don't match one in our records. You have {remainingAttempt} attempts remaining.");
        }
    }
    if (!loginStatus)
    {
        Console.WriteLine("You failed to login. Unlucky.");
    }

}


//using System.Diagnostics.Metrics;

//3.Write a C# Sharp program that takes a number and a width also a number, as input and then displays a triangle of that width, using that number.
//Test Data
//Enter a number: 6
//Enter the desired width: 6
//Expected Output:

//666666

//66666

//6666

//666

//66

//6


//challengePart3();
void challengePart3()
{
    Console.WriteLine("Let's make a trinagle the size of the number you provide us!");
    Console.WriteLine("Please enter the size you would like to use.");
    int triangleSize = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    for (int i = triangleSize; i > 0; i--) //Loop to do it {triangleSize} many times
    {
        for (int j = 0; j < i; j++) //For that line of triangleSize, do the following
        {
            Console.Write(triangleSize + " "); //Print the number (j) and then add a space
            //Note: Write and not writeLine so that these numbers stay on the same line.
        }
        Console.WriteLine(); // Add a space
    }

}




//4.Write a C# Sharp program to read
//roll no, name and marks of three subjects and calculate the total, percentage and division.
//(May use a struct / class to represent the student)
//Test Data :
//Input the Roll Number of the student :784
//Input the Name of the Student :James
//Input the marks of Physics, Chemistry and Computer Application : 70 80 90
//Expected Output :
//Roll No : 784
//Name of Student : James
//Marks in Physics : 70
//Marks in Chemistry : 80
//Marks in Computer Application : 90
//Total Marks = 240
//Percentage = 80.00
//Division = First
//challengePart4();
void challengePart4()
{
    Student firstStudent = new Student//Instantiate a student with given data
    {
        RollNumber = 784,
        Name = "James"
    };

    List<SubjectGrade> grades = new List<SubjectGrade>
{
    new SubjectGrade { Subject = "Physics", Grade = 70 },
    new SubjectGrade { Subject = "Chemistry", Grade = 80 },
    new SubjectGrade { Subject = "Computer Application", Grade = 90 }
};

    GradeCalculator gradeCalculator = new GradeCalculator();
    double average = gradeCalculator.CalculateAverage(grades);
    string division = gradeCalculator.GetDivision(average);

    Console.WriteLine("Student information:");
    Console.WriteLine($"Roll No: {firstStudent.RollNumber}");
    Console.WriteLine($"Student Name: {firstStudent.Name}");

    foreach (var g in grades)
    {
        Console.WriteLine($"{g.Subject}: {g.Grade}");
    }
    int total = grades.Sum(g => g.Grade);
    Console.WriteLine($"Your total mark is: {total}");
    Console.WriteLine($"Your average, in otherwords, would be {average:F2}%");
    Console.WriteLine($"Division: {division}");
}
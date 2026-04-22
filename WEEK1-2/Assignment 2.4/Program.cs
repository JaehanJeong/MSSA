//using System.Xml.Linq;

//1.Write a program in C# Sharp to find the sum of all array elements.
//Test Data :
//Input the number of elements to be stored in the array :3
//Input 3 elements in the array :
//element - 0 : 2
//element - 1 : 5
//element - 2 : 8
//Expected Output :
//Sum of all elements stored in the array is : 15



arraySumQuestion();
void arraySumQuestion()
{
    double [] userArray = new double [3];
    double userSum = 0;
    Console.WriteLine("We'll add the 3 numbers you give us.");
    for (int i = 0; i <= 2; i++)
    {
        Console.WriteLine($"Please enter the number for index {i}.");
        userArray[i] = Convert.ToInt32(Console.ReadLine());
        userSum += userArray[i];
        Console.WriteLine($"Number given for index {i} is {userArray[i]}");
    }
    Console.WriteLine($"Sum of all elements stored in the array is : {userSum}");
}



//2.Write a C# Sharp program to find the largest of three numbers.
//Test Data :
//Input the 1st number :25
//Input the 2nd number :63
//Input the 3rd number :10
maxQuestion();

void maxQuestion()
{
    Console.WriteLine("We'll take your three numbers and let you know which is the highest number.");
    Console.WriteLine("Please enter the first number.");
    double firstNumber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please enter the second number.");
    double secondNumber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please enter the third number.");
    double thirdNumber = Convert.ToInt32(Console.ReadLine());
    // Not using max function so I can demonstrate algorithm
    double[] numbers = { firstNumber, secondNumber, thirdNumber };

    int maxIndex = 0;
    bool isEqualValue = false;

    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] > numbers[maxIndex])
        {
            maxIndex = i;
        }
        else if (numbers[i] == numbers[maxIndex])
        {
            isEqualValue = true;
        }
    }

    string[] labels = { "1st", "2nd", "3rd" };
    // Expected Output :
    // The 2nd Number is the greatest among three
    if (isEqualValue = true)
    {
        Console.WriteLine($"There were numbers of equal value. Of those, the {labels[maxIndex]} number was the first number in the array to be the max value.");
    }
    else
    {
        Console.WriteLine($"The {labels[maxIndex]} number is the greatest among three");
    }
    
    // I don't like that I hard coded 1st 2nd 3rd, but for this level of assignment we'll cope :)
}


//3. Write a C# Sharp program to accept a coordinate point in an XY coordinate system and determine in which quadrant the coordinate point lies.
//Test Data :
//Input the value for X coordinate :7
//Input the value for Y coordinate :9
//Expected Output :
//The coordinate point(7, 9) lies in the First quadrant.

quadrantQuestion();
void quadrantQuestion()
{
    Console.WriteLine("We'll determine which quadrant your point falls on.");
    Console.WriteLine("Please enter the X coordinate.");
    double xCoordinate = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Please enter the Y coordinate.");
    double yCoordinate = Convert.ToDouble(Console.ReadLine());

    if (xCoordinate == 0 && yCoordinate == 0)
    {
        Console.WriteLine("Your point falls exactly on the origin.");
        Console.WriteLine($"The coordinate point {xCoordinate}, {yCoordinate} lies right on the origin.");
    }


    else if (xCoordinate == 0 || yCoordinate == 0)
    {
        Console.WriteLine("Your point falls either on the x-axis or the y-axis and therefore is not inside a particular quadrant.");

    }
    else if (xCoordinate > 0 && yCoordinate > 0)
    {
        Console.WriteLine($"The coordinate point({xCoordinate}, {yCoordinate}) lies in the first quadrant.");
    }
    else if (xCoordinate < 0 && yCoordinate > 0)
    {
        Console.WriteLine($"The coordinate point({xCoordinate}, {yCoordinate}) lies in the second quadrant.");
    }
    else if (xCoordinate < 0 && yCoordinate < 0)
    {
        Console.WriteLine("Your point falls on the bottom left quadrant of the graph.");
        Console.WriteLine($"The coordinate point({xCoordinate}, {yCoordinate}) lies in the third quadrant.");
    }
    else if (xCoordinate > 0 && yCoordinate < 0)
    {
        Console.WriteLine("Your point falls on the bottom right quadrant of the graph.");
        Console.WriteLine($"The coordinate point({xCoordinate}, {yCoordinate}) lies in the fourth quadrant.");
    }




    
}

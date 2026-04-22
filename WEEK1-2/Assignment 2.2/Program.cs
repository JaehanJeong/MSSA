// Assignment 2.2
// Exercise 1 - Until 11:15 PDT

using Assignment_2._2.Models;
using Assignment_2._2.Models.Shapes;


assignment2SecondPart();


    static void assignment2SecondPart()
    {
    int powerOn = 1;

        do
        {
            Console.WriteLine("Please choose from the following menu options. ");
            Console.WriteLine("1. Add two numbers.");
            Console.WriteLine("2. Multiply two numbers.");
            Console.WriteLine("3. Exit the program.");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Please enter the first number you would like to add");
                    decimal firstAdd = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Please enter the second number you would like to add");
                    decimal secondAdd = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Please enter the third number you would like to add");
                    decimal thirdAdd = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine($"The sum of your numbers is {Maths.addNums(firstAdd, secondAdd, thirdAdd)}");
                    break;
                case 2:
                    Console.WriteLine("Please enter the first number you would like to multiply");
                    float firstMultiply = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the second number you would like to multiply");
                    float secondMultiply = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the third number you would like to multiply");
                    float thirdMultiply = float.Parse(Console.ReadLine());
                    Console.WriteLine($"The multiplied result of your numbers is {Maths.multiplyNums(firstMultiply, secondMultiply, thirdMultiply)}");
                    break;
                case 3:
                    powerOn = powerOn - 1;
                    break;

                case 4:
                    Console.WriteLine("You have entered an invalid input. Please make sure you're entering 1 or 2");
                    break;


            }
        } while (powerOn == 1);


    }


assignment2ThirdPart();


    static void assignment2ThirdPart()
    {
        int powerOn = 1;

        do
        {
            Console.WriteLine("Please choose from the following menu options. ");
            Console.WriteLine("1. Calculate the area of your circle.");
            Console.WriteLine("2. Calculate the area of your square.");
            Console.WriteLine("3. Exit the program.");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
        {
            case 1:
                Console.WriteLine("Please enter the radius of your circle.");
                double circleRadius = Convert.ToDouble(Console.ReadLine());


                //Circle circle = new(); REMOVED CUZ APPARENTLY NOT BEST
                //circle.radius = radius;
                Circle circle = new(circleRadius);  // complete and ready to use immediately

                Console.WriteLine($"The area of your circle is {circle.calculateArea()}");
                break;

            case 2:
                Console.WriteLine("Please enter the width of your square.");
                double width = Convert.ToDouble(Console.ReadLine());

                //Square square = new();REMOVED CUZ APPARENTLY NOT BEST
                //square.width = width;
                Square square = new(width);

                Console.WriteLine($"The area of your square is {square.calculateArea()}");
                break;
            case 3:
                powerOn = powerOn - 1;
                break;
        }


        }while (powerOn == 1) ;
    }


     













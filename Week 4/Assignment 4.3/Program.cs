#region 4.3.1
//Write a program in C# Sharp to calculate and
//print the Electricity bill of a given customer.
//The customer id., name and unit consumed by the user
//should be taken from the keyboard and display the total
//amount to pay to the customer.
//The charge are as follows: (you may change the charge sheet values)
// x < 199 --> @1.2
// 200 <= x < 400 --> @1.5
// 400 <= x < 600 --> @1.8
// 600 < x --> @2.00
// If bill > $400, then surcharge x += (x*0.15)



void Assignment4_3_1()
{
    int customerId;
    while (true)
    {
        Console.WriteLine("Please enter the customer id.");
        if (int.TryParse(Console.ReadLine(), out customerId))
            break;
        Console.WriteLine("Please make sure you are entering a valid ID");
    }

    string? customerName;
    while (true)
    {
        Console.WriteLine("Please enter the customer name.");
        customerName = Console.ReadLine();

        if (!string.IsNullOrEmpty(customerName))
            break;
        Console.WriteLine("Please make sure to enter your name.");
    }

    double unitConsumed;
    while (true)
    {
        Console.WriteLine("Please enter the electricity unit consumed");
        if (double.TryParse(Console.ReadLine(), out unitConsumed))
            break;
        Console.WriteLine("Please make sure you are entering numbers.");
    }
    double electricityBill;

    Console.WriteLine($"Customer IDNO:{customerId}");
    Console.WriteLine($"Customer Name :{customerName}");
    Console.WriteLine($"Unit Consumed:{unitConsumed}");


    if (unitConsumed <= 199) // upto 199
    {
        electricityBill = unitConsumed * 1.2;
        Console.WriteLine($"Amount Charges @$1.20 per unit: {electricityBill}");
    }
    else if (unitConsumed < 400) // 200 and above but less than 400
    {
        electricityBill = unitConsumed * 1.5;
        Console.WriteLine($"Amount Charges @$1.50 per unit: {electricityBill}");
    }
    else if (unitConsumed < 600) // 400 and above but less than 600
    {
        electricityBill = unitConsumed * 1.8;
        Console.WriteLine($"Amount Charges @$1.80 per unit: {electricityBill}");
    }
    else
    {
        electricityBill = unitConsumed * 2.00;
        Console.WriteLine($"Amount Charges @$2.00 per unit: {electricityBill}");
    }

    double finalBill = 0;
    double surCharge = 0;
    if (electricityBill > 400)
    {
        surCharge = electricityBill * 0.15;
        finalBill = electricityBill + surCharge;
    }
    else
        finalBill = electricityBill;


    Console.WriteLine($"Surcharge Amount : {surCharge}");
    Console.WriteLine($"Net Amount Paid By the Customer : {finalBill}");
}

Assignment4_3_1();
#endregion

#region 4.3.2
// 2.Write a program in C# Sharp to count the frequency of each element of an array.

void assignment4_3_2()
{
    int numberOfElements = 0;

    while (true)
    {
        Console.WriteLine("Please input the number of elements to be stored in the array.");
        if (int.TryParse(Console.ReadLine(), out numberOfElements) && numberOfElements > 0)
            break;
        Console.WriteLine("Please enter a positive whole number.");
    }

    int[] numbers = new int[numberOfElements];

    int index = 0;
    while (index < numbers.Length)
    {
        Console.WriteLine($"Input the element for index {index}");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            numbers[index] = value;
            index++;
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }




    }
    Dictionary<int, int> frequency = new Dictionary<int, int>();
    foreach (int num in numbers)
    {
        if (frequency.ContainsKey(num))
        {
            frequency[num]++;
        }
        else
        {
            frequency[num] = 1;
        }
    }
    Console.WriteLine("Frequency of all elements of array: ");
    foreach (var pair in frequency)
    {
        Console.WriteLine($"{pair.Key} appeared {pair.Value} times.");
    }

}

assignment4_3_2();
#endregion

#region 4.3.3
//3.Write a program in C# Sharp to print all unique elements in an array.

void assignment4_3_3()
{
    int numberOfElements = 0;

    while (true)
    {
        Console.WriteLine("Please input the number of elements to be stored in the array.");
        if (int.TryParse(Console.ReadLine(), out numberOfElements) && numberOfElements > 0)
            break;
        Console.WriteLine("Please enter a positive whole number.");
    }

    int[] numbers = new int[numberOfElements];

    int index = 0;
    while (index < numbers.Length)
    {
        Console.WriteLine($"Input the element for index {index}");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            numbers[index] = value;
            index++;
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }

    }
    Dictionary<int, int> frequency = new Dictionary<int, int>();
    foreach (int num in numbers)
    {
        if (frequency.ContainsKey(num))
        {
            frequency[num]++;
        }
        else
        {
            frequency[num] = 1;
        }
    }

    Console.WriteLine("The unique elements found in the array are : ");
    foreach (var pair in frequency)
    {
        if (pair.Value == 1)
        {
            Console.Write($"{pair.Key} ");
        }
    }

}

assignment4_3_3(); 
#endregion
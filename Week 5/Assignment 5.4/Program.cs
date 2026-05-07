//Write a program in C# Sharp to display the individual digits of
//a given number using recursion.

int number = 1234;
void DisplayDigits(int number)
{
    //Base case - Stop when we're done chopping all digits.
    if (number == 0) return;

    //Explored log10, and convert to string ways, but this way seems best overall.

    //Step 1: Process the number, 1 digit at a time. (ex: 1234 -> 123 -> 12 -> 1)
    //Push each state onto the call stack.
    //Call itself again without the last digit.
    DisplayDigits(number / 10);


    // Step 2: Unwinding the Stack
    // As the functions finish and "pop" off the stack, we print the remainder.
    // The first one to finish is the one that received '1', so it prints first.
    // Writes 
    Console.Write($"{number % 10} ");
}
DisplayDigits(number);
Console.WriteLine();
//Write a C# Sharp program to find the sum of the right diagonals of a matrix.
//Have the user input the size of the square matrix.
int userInput = 0;
while(true)
{
    Console.WriteLine("Please input the size of the square matrix.");
    if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0)
        break;
    Console.WriteLine("Please enter a valid positive whole integer.");
}

//Initialize the matrix with given size
int[,] matrix = new int[userInput, userInput];


//Let them fill up matrices
Console.WriteLine("Input elements in the first matrix:");
for (int i = 0; i< userInput; i++)
{
    for (int j = 0; j< userInput; j++)
    {
        Console.Write($"element - [{i}],[{j}]] : ");
        matrix[i, j] = int.Parse(Console.ReadLine());
    }
}


//Print out the matrix by looping.
Console.WriteLine("\nThe matrix is : \n");
for(int i = 0;  i < userInput; i++)
{
    for(int j = 0; j< userInput; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}


// Sum of right diagonal logic
int sum = 0;
for (int i = 0; i< userInput; i++) // Loop as many as userInput says to;
{
    //Add to sum: 
    sum += matrix[i, i];
}

Console.WriteLine($"Addition of the right Diagonal element is: {sum}");

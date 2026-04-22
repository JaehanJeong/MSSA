// Assignment 3.2
// By Jaehan Jeong
// 21 April 2026

#region Question#1
//1.Create a 2D array to store integers and print them in matrix format with proper formatting.

//e. g:

//| 2 | 3 | 4 |

//| 1 | 4 | 6 |

using Assignment_3._2.Models;

int[,] numbers = { { 2, 3, 4 }, { 1, 4, 6 } };

// First attempt
// Loop's logic is messed up. Here is what it's ACTUALLY doing:
//foreach  (var number in numbers) // 1. For EACH element in entire 2D array numbers: which is 6 times by the way,
//{
//    foreach (var i in numbers) // 2. Go thru every single element in the entire 2D array, one by one, and for each value, print it.
//        Console.Write($"| {i} |");
//    }
//    Console.WriteLine();
//}
// Note to self: Foreach is not ideal when trying to work with 2D arrays to act like matrices.

// Second attempt
for (int i = 0; i < numbers.GetLength(0); i++) // Go through each row 
{
    for (int j = 0; j < numbers.GetLength(1); j++) // Then go thru each column in the current row
    {
        Console.Write($"| {numbers[i, j]} "); // Write, with formating, j'th column of the i'th row.
    }
    Console.Write("|"); // Add a formatting bar at the end of each line
    Console.WriteLine(); // Add a line for formatting as well.
}
// Reflection: I was trying to think of it as array of arrays, but thats jagged array.
// 2D Arrays are just matrices of rows and columns.
// ======================== END OF QUESTION 1 ========================= 
#endregion

#region Question#2
//2.Write a program in C# for addition of two Matrices of same size.

//Step 1: Get the user to input the size of the square matrix.
//Step 2: Get the user to fill the first matrix
//Step 3: Get the user to fill the second matrix
//Step 4: Add values from both matrices and store them in the third matrix
//Step 5: Display the first, second and third matrices with appropriate format and text.

//Step 1: Get the user to input the size of the square matrix.
int matrixSize; // Create a variable to store matrixSize
Console.WriteLine("Enter matrix size. ");
matrixSize = Convert.ToInt32(Console.ReadLine());

// Creating two matrices to fill with given matrixSize
int[,] matrixOne = new int[matrixSize, matrixSize];
int[,] matrixTwo = new int[matrixSize, matrixSize];
int[,] matrixThree = new int[matrixSize, matrixSize]; //Result of adding first two matrices

//Step 2: Get the user to fill the first matrix aka WRITE DATA
Console.WriteLine("Matrix One:");
for (int i = 0; i < matrixOne.GetLength(0); i++) // number of arrays in that 0th dimension, which in this case is matrixSize // rows
{

    for (int j = 0; j < matrixOne.GetLength(1); j++) // 1 means next dimension, which in this case is matrixSize // columns
    {
        Console.Write($"Element - [{i}], [{j}]: ");
        matrixOne[i, j] = int.Parse(Console.ReadLine());// Parse will assume that whatever input is used, it's gona be int.
                                                        //Try Parse is a better practice always checks if the input is covertible to the respective data type.
    }
}

//Step 3: Get the user to fill the first matrix aka WRITE DATA
Console.WriteLine("Matrix Two:");
for (int i = 0; i < matrixTwo.GetLength(0); i++) // number of arrays in that 0th dimension, which in this case is matrixSize // rows
{

    for (int j = 0; j < matrixTwo.GetLength(1); j++) // 1 means next dimension, which in this case is matrixSize // columns
    {
        Console.Write($"Element - [{i}], [{j}]: ");
        matrixTwo[i, j] = int.Parse(Console.ReadLine());// Parse will assume that whatever input is used, it's gona be int.
                                                        //Try Parse is a better practice always checks if the input is covertible to the respective data type.
    }
}

//Step 4: Add values from both matrices and store them in the third matrix
for (int i = 0; i < matrixThree.GetLength(0); i++)
{
    for (int j = 0; j < matrixThree.GetLength(1); j++)
    {
        matrixThree[i, j] = matrixOne[i, j] + +matrixTwo[i, j];
    }
}

//Step 5: Display the first, second and third matrices with appropriate format and text.
//Display the first matrix
Console.Write($"The first matrix is \n");
for (int i = 0; i < matrixOne.GetLength(0); i++) // Go through each row 
{
    for (int j = 0; j < matrixOne.GetLength(1); j++) // Then go thru each column in the current row
    {
        Console.Write($"{matrixOne[i, j]} "); // Write, with formating, j'th column of the i'th row.
    }
    Console.WriteLine(); // Add a line for formatting as well.
}
//Display the second matrix
Console.Write($"The second matrix is \n");
for (int i = 0; i < matrixTwo.GetLength(0); i++) // Go through each row 
{
    for (int j = 0; j < matrixTwo.GetLength(1); j++) // Then go thru each column in the current row
    {
        Console.Write($"{matrixTwo[i, j]} "); // Write, with formating, j'th column of the i'th row.
    }
    Console.WriteLine(); // Add a line for formatting as well.
}
//Display the resulting matrix
Console.Write($"The Addition of two matrix is : \n");
for (int i = 0; i < matrixThree.GetLength(0); i++) // Go through each row 
{
    for (int j = 0; j < matrixThree.GetLength(1); j++) // Then go thru each column in the current row
    {
        Console.Write($"{matrixThree[i, j]} "); // Write, with formating, j'th column of the i'th row.
    }
    Console.WriteLine(); // Add a line for formatting as well.
}
// Maybe I can/should use a loop to do this?
// ======================== END OF QUESTION 2 ========================= 
#endregion


#region Question#3
//3. Create a console application to overload “+” and “-“ operator for adding the areas of 2 circles and getting their area difference respectively.
// A lot of the work is done in Circle.cs
// We have methods to calculate area and the +- operator overloads in there.
// So we just call them here to demonstrate:

Circle c1 = new Circle();
c1.Radius = 5;
Circle c2 = new Circle();
c2.Radius = 10;

double sum = c1 + c2;
double difference = Math.Abs(c1 - c2);

Console.WriteLine($"The sum of the two circles areas is {sum} and the difference is {difference}");


//================================ END OF QUESTION 3 ================================  
#endregion

#region Question#4
//4.Write a function that takes 4 numbers as input to calculate the total and average.
//(Make use of params array to pass arguments and out parameters to return both total and average to main method).

void calculateTotalAndAverage(params double[] numbers)
{
    double sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    Console.WriteLine($"The total of your numbers add up to {sum}.");
    Console.WriteLine($"The average of your numbers: {(string.Join(",", numbers))} is {sum / numbers.Length}");
}
calculateTotalAndAverage(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);


//=================== END OF QUESTION #4 ============================ 
#endregion

#region Question#5
//5.Create a function that finds the index of a given item in the array

int findIndexOfGivenItem(int[] numsToSearch, int numberToFind)
{
    for (int i = 0; i < numsToSearch.Length; i++)
    {
        if (numsToSearch[i] == numberToFind)
        {
            //Console.WriteLine($"The number you were looking for, {numberToFind} was in the index {i}");
            return i;
        }
    }
    //Console.WriteLine($"The number you were looking for, {numberToFind} was not found. Answer is -1");
    return -1;

}

int answer = findIndexOfGivenItem(new int[] { 9, 8, 3 }, 7);
Console.Write(answer);
//Interesting notes: 
//1. I only need to return the first index (dont worry about all occurrences because it was not asked. (Apparently thats how most algorithms work too)
//2. If I needed to find all occurrences, then I'd make an array or something with each index that was found at and return that array instead.
//=================== END OF QUESTION #5 ============================  
#endregion
//Create a 3x3 matrix and assign 1~9

//To be honest I just guess and checked LOL
int[,] matrix = new int[3, 3] { { 1, 2, 3, }, { 4, 5, 6 }, { 7, 8, 9 } };

for(int i = 0;  i < matrix.GetLength(0); i++)
{
    for(int j = matrix.GetLength(1)-1; j >= 0; j--)
    {
        Console.Write(matrix[j, i] + "\t");
    }
    Console.WriteLine();
}

//Now, rotate this matrix 90 degrees clockwise 
/*
 * Trying to see a pattern..
[1] --> [0,0] replaced by [2,0] --> [+2, 0] --> [1] <-> [3]
[2] --> [0,1] replaced by [1,0] --> [+1,-1] --> [2] <-> [6]
[3] --> [0,2] replaced by [0,0] --> [0, -2] --> [3] <-> [9]

[4] --> [1,0] replaced by [2,1] --> [+1,+1] --> [4] <-> [2]
[5] --> [1,1] replaced by [1,1] --> [0 , 0] --> [5] <-> [5]
[6] --> [1,2] replaced by [0,1] --> [-1,-1] --> [6] <-> [8]

[7] --> [2,0] replaced by [2,2] --> [0, +2] --> [7] <-> [9]
[8] --> [2,1] replaced by [1,2] --> [-1,+1] --> [8] <-> [4]
[9] --> [2,2] replaced by [0,2] --> [-2, 0] --> [9] <-> [7]

=================================
[1] --> [0,0] goes to [0,2] --> 0, +2
[2] --> [1,0] goes to [1,2] --> 0, +2
[3] --> [2,0] goes to [2,2] --> 0, +2

[4] --> [1,0] goes to [0,1] --> -1, +1
[5] --> [1,1] goes to [1,1] -->  0, 0
[6] --> [1,2] goes to [2,1] --> +1, -1

[7] --> [2,0] goes to [0,0] --> -2,  0
[8] --> [2,1] goes to [1,0] --> -1, -1
[9] --> [2,2] goes to [2,0] -->  0, -2
========================================
n = width - 1
Right now width = 3 so n = 3 - 1 = 2.
[1] --> [n-n, n-n] --> [n-n, n]
[2] --> [n-n, n-(n-i)] --> [n-(n-i), n]
[3] --> [n-n, n] --> [n,n]

[4] --> [n-(n-i), n-n] --> [n-n, n-(n-i)]
[5] --> [n-(n-i), n-(n-i)] --> [n-(n-i), n-(n-i)]
[6] --> [n-(n-i), n] --> [n, n-(n-i)]

[7] --> [n, n-n] --> [n-n, n-n]
[8] --> [n, n-(n-i)] --> [n-(n-i), n-n]
[9] --> [n,n] --> [n, n-n]

All this to say... I couldn't extract a formula from this

 */

//Gemini answer. 
//int n = matrix.GetLength(0) - 1; // The max index

//// Standard loops: i and j both count UP (0, 1, 2...)
//for (int i = 0; i <= n; i++)
//{
//    for (int j = 0; j <= n; j++)
//    {
//        // Using our derived formulas: 
//        // New Row = n - j
//        // New Col = i
//        Console.Write(matrix[n - j, i] + "\t");
//    }
//    Console.WriteLine();
//}
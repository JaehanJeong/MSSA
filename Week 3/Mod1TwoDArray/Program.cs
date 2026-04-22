namespace Mod1TwoDArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3d would have 2 commas, 4d would have 3 commas etc
            int[,] movieRatings = new int[4, 5]; // [rows, colums] ==> [users , movies]
            // rows , columns
            //4 users rating 5 different movies
            Console.WriteLine("Enter ratings for 4 users and 5 movies (0-10):");
            //writing the data
            for(int i = 0; i < movieRatings.GetLength(0); i++) // number of arrays in that 0th dimension, which in this case is 4 // rows
            {
                for (int j = 0;  j < movieRatings.GetLength(1); j++) // 1 means next dimension, which in this case is 5 // columns
                {
                    Console.Write($"User {i + 1}, Movie {j + 1}: ");
                    movieRatings[i, j] = int.Parse(Console.ReadLine());// Parse will assume that whatever input is used, it's gona be int.
                    //Try Parse is a better practice always checks if the input is covertible to the respective data type.
                }
            }
            //reading data
            Console.WriteLine("\nMovie Ratings:");
            for (int i = 0; i < movieRatings.GetLength(0); i++)
            {
                for (int j = 0; j < movieRatings.GetLength(1); j++)
                {
                    Console.Write($"{movieRatings[i, j]}" + "\t");
                }
                Console.WriteLine();
            }
                
        }
    }
}

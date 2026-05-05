namespace Mod2Recursion2
{
    internal class Program
    {
        static void PrintSquares(int num)
        {
            
            if (num > 1)
            {
                PrintSquares(num - 1);
            }
            Console.WriteLine(num * num);
        }

        static void Main(string[] args)
        {
            PrintSquares(5);
            //int num = 5;
            //for(int i = num; i >= 1; i--)
            //{
            //    Console.WriteLine(i * i);
            //}
            // fibonacci tomorrow (5/6/2026) - Dan's fav mathematician btw
        }
    }
}

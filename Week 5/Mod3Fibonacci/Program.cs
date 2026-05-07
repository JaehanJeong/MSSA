namespace Mod3Fibonacci
{
    internal class Program
    {
        // 0 1 1 2 3 5 8 
        // 0 1 2 3 4 5 6
        static int Fibo_Iteration(int n)
        {
            int first = 0, second = 1, result = 0;
            if (n == 0)
            {
                Console.Write(0);
                return 0;
            }
            if (n == 1)
            {
                Console.Write($"{first}, {second}, ");
                return second;
            }
            Console.Write($"{first}, {second}, ");
            for (int i = 2; i <= n; i++)
            {
                result = first + second;
                Console.Write($"{result}, ");
                first = second;
                second = result;
            }
            Console.WriteLine();
            return result;
        }
        //fib(5) = fib(4) + fib(3)
        //fib(n) = fib(n-1) + fib(n-2)

        static int Fib_Rec(int n)
        {// worst approach
            //reason: we're calling the same function with same input multiple times
            //because we never stored that
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib_Rec(n - 1) + Fib_Rec(n - 2); 
        }


        //nullable helps to add null as a data instead of 0 because 0 is also a value
        static Nullable <int>[] sequence = new Nullable<int>[50];//can also use a list to keep it dynamic.
        static int? FibRecDP(int n)
        {
            if (n == 0)
            {
                sequence [0] = 0;
                return 0;
            }
            if (n == 1)
            {
                sequence[1] = 1;
                return 1;
            }
            return sequence[n] = FibRecDP(n - 1) + FibRecDP(n - 2);

        }


        // Memoization is an optimization technique used in programming to make programs run faster by
        // storing the results of function calls and reusing them when the same input occurs again.
        static int[] FibDP(int n) // n is index of the array
        {
            int[] series = new int[n];
            series[0] = 0;
            series[1] = 1;
            for(int i = 2;i<n;i++)
            {
                series[i] = series[i-1] + series[i-2];
            }
            return series;
        }


        static void Main(string[] args)
        {   
            //Fibo_Iteration(6);
            Console.WriteLine($"nth term returned:" + Fibo_Iteration(6));
            Console.WriteLine("Dynamic Programming method");

            foreach (int i in FibDP(7))
            {
                Console.Write(i + " ");
            }


            foreach (var item in sequence)
            {
                Console.Write(item + " ");
            }
        }
    }
}

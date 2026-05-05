namespace Mod2Recursion3
{
    internal class Program
    {
        // n = 5 : 1+2+3+4+5 = 15
        // n = 4 : 1 +2+3+4=10
        //sum(5) = sum(4) + 5
        //sum(100) = sum(99)+100
        //sum(n) = sum(n-1)+n

        //sum_recursion
        //n = 4
        //sum(3)+4
        //n = 3
        //sum(2)+3
        //n = 2
        //sum(1)+2 ==> 1 + 2 ==> 3


        static int Sum_Recursion(int n)
        {
            if(n==0) return 0;
            if(n==1) return 1;
            return Sum_Recursion(n-1)+n;
        }
        static int Sum_Iteration(int num)
        {
            int sum = 0;
            int i = 1;
            while (i <= num)
            {
                sum += i;
                i++;
            }
            return sum;
        }

        static long Factorial_Iteration(int n)
        {
            long fact = 1;
            for(int i = 2;  i <= n; i++)
            {
                fact *= i;
                
            }
            return fact;
            
        }

        static long Factorial_Recursion(int n )
        {
            long fact = 0; 

        }
        static void Main(string[] args)
        {
            // 1 + 2 + 3 ... + 10
            int num = 4;
            //Console.WriteLine($"Sum by iteration : {Sum_Iteration(num)}");
            //Console.WriteLine($"Sum by iteration : {Sum_Recursion(num)}");

            //factorial:
            //3! = 3*2*1 = 6
            //4! = 4*3*2*1 = 24
            //4! = 4*3!
            //n! = n*(n-1)!
            Console.WriteLine($"factorial by iteration:{Factorial_Iteration(num)}");
        }
    }
}

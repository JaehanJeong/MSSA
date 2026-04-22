namespace Mod2MethodsDemo
{
    
    class A
    {
        public static void Test()
        {
            throw new NotImplementedException();
        }
    }

    class B
    {
        public static void Test()
        {
            throw new NotImplementedException();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Add(67, 78);
            Gretings("Amy");
            // overloading : static polymorphism (within the same class) cuz it's happening at design time.
            //FileStream file = new FileStream();

            int i, j;
            i = 20;
            j = 40;
            Swap (ref i, ref j); // We are passing value type. So now we are passing by address
            // Reference type would actually change it?
            Console.WriteLine($"i : {i} , j : {j} ");
            int[] nums = new int[2] { 10, 20 };
            Swap(nums);
            Console.WriteLine($"Nums[0] : {nums[0]}, nums[1] : {nums[1]}");

            int product, sum;
            Results(out product, out sum, i, j);
            Console.WriteLine($"product : {product} sum: {sum}");

            Results(out product, out sum, i, j, 68, 89, 90); // one way of passing multiple data into a comma separated way
            Console.WriteLine($"product : {product} sum: {sum}");
            Results(out product, out sum, new int[] { 23, 45, 67 }); // Pass as array
            Console.WriteLine($"product : {product} sum: {sum}");
            // Not super readeable xD --> CalculateSalary(4556, "NY", 1, 344, 'M');
            // Therefore, we use named parameter
            CalculateSalary(baseSalaray: 6666, dependants: 0, state: "NY", contributions: 334, filingStatus: 's');

        }

        static void CalculateSalary(double baseSalaray, string state, double contributions, char filingStatus = 'S', int dependants = 0)
        {//if you pass preset parameters, then they should be towards the end.
            // also, these preset values will allow you to not supply them when the method is called.
            // we call it optional parameter

        }
        static void Gretings(string name)
        {
            Console.WriteLine("Hello " + name);
        }
        static void Greetings (string name, string msg)
        {
            Console.WriteLine(msg + " " + name);
        }

        static int Add(int a, int b) 
        {
            return a + b;
            // char c;
        }

        static void Results(out int product, out int sum, int i, int j)
        {
            product = i * j;
            sum = i + j;
            // purpose of out is to return back value without having a return statement.
        }

        // There will be multiple values but we don't know how many - thats the power of params
        static void Results(out int product, out int sum, params int[]values) 
        {
            product = 1;
            sum = 0;
            foreach(var i in values)
            {
                product = product * i;// product of all the values in that array
                sum = sum + i; // sum of all the elements
            }
        }


        // Nature of reference value type lets you do this without having to cast it as ref
        static void Swap(int[] nums) 
        {
            int temp;
            temp = nums[0];
            nums[0] = nums[1];
            nums[1] = temp;
                
        }


        static void Swap(ref int num1, ref int num2) 
            // Swap logic needed during sorting algorithm
        {
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }

    }
}

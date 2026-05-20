using System.Runtime.CompilerServices;
using System.Text;

namespace Mod1StringsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CallConvThiscall
            Employee emp = new Employee(102, "jim"); // instance class
            emp.Id = 101;
            Console.WriteLine(emp.Id); /// get block
            // strings are a sequence of characters and are enclosed in double quotes
            // string are immutable
            // Use string builder class to modify the string

            string name = "deepali";
            name = name + "kamatkar";

            string s = string.Empty;

            string s1 = "     amazing     ";
            s1.Trim();

            Console.WriteLine($"Length of string : {s1.Length}");
            Console.WriteLine($"Length of string after trim : {s1.Trim().Length}");

            string s2 = "* A Short Story, *";
            // this new string will have leading and trailing whitespace, star and comma's trimmed
            var newHeader = s2.Trim(new char[] { ' ', '*', ',' }); // Anonymous types just for this
            // You'd need split if you wana remove whitespace in between

            Console.WriteLine($"Header after trim : {newHeader.ToUpper()}");

            var chars = s2.ToCharArray();

            foreach(var c in chars)
            {
                Console.WriteLine(c);
            }

            string names = "aa,bb,cc,dd";
            var words = names.Split(',');
            foreach(var word in words)
            {
                Console.WriteLine(word);
            }
            string s3 = "Wake up early in the morning";
            Console.WriteLine(s3.Replace("Wake up", "Study")); // Replace Wake up with Study
            Console.WriteLine(s3.Substring(0, 4));


            StringBuilder stringBuilder = new StringBuilder("deepali");
            //THIS IS NOT AN ARRAY.
            //It'll be using the same string and have the last name attended
            //More memory efficient

            stringBuilder.Append(" kamatkar");

        }
    }
}

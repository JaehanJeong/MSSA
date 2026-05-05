using System.Globalization;

#region Question#1
// Question #1
//1.Given a string s consisting of words and spaces,
//    return the length of the last word in the string. 
//    A word is a maximal substring consisting of 
//    non-space characters only.

Console.WriteLine("Please enter the string you want us to find the last word for.");
string s = Console.ReadLine();
string[] words = s.Trim().Split(' ');
Console.WriteLine(words.Last().Length);
#endregion

#region Question#2
//Question#2
//2.Write a program in C# Sharp to print
//the first n natural number using recursion.
//int num = 1;

void assignment5_2_2()
{
    Console.WriteLine();
    int n = 0;
    while (true)
    {
        Console.WriteLine("Please enter the value N for us to iterate for this problemo.");
        if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            break;
        Console.WriteLine("Please enter a positive whole number.");
    }
    void OnetoN(int num)
    {
        if (num > 1)
        {
            OnetoN(num - 1);
        }
        Console.WriteLine(num);
    }
    OnetoN(n);
}
assignment5_2_2();
#endregion

#region Question#3
//Question#3
//3.Write a program in C# Sharp to
//print numbers from n to 1 using recursion.

void assignment5_2_3()
{
    Console.WriteLine();
    int n = 0;
    while (true)
    {
        Console.WriteLine("Please enter the value N for us to iterate for this problemo.");
        if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            break;
        Console.WriteLine("Please enter a positive whole number.");
    }
    void NtoOne(int num)
    {
        if (num < 1) return;
        Console.WriteLine(num);
        NtoOne(num - 1);
    }
    NtoOne(n);
}
assignment5_2_3();
#endregion

#region Question#4
//Question#4
//4.Write a program in C# Sharp to check whether a given string is Palindrome or not using recursion.

void RecursivePalindrome()
{
    Console.WriteLine("Enter a string that you'd like to check for a palindrome.");
    string s = Console.ReadLine();


    bool IsPalindrome(string input)
    {

        if (input.Length <= 1)
        {
            Console.WriteLine("True!");
            return true; // If length is 1 or 0, it must be a palindrome!
        }

        if (input[0] != input[input.Length - 1]) return false;// If they don't match return false
        //Get the substring that takes off those ends and continue comparing.
        return IsPalindrome(input.Substring(1, input.Length - 2));
    }
    IsPalindrome(s);
}

RecursivePalindrome(); 
#endregion
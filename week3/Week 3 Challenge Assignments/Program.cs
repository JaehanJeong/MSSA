using System.Text.RegularExpressions;
#region Question #1
//1.Given a string, write a method that checks if it is a palindrome (is read the same backward as forward). Assume that string may consist only of lower-case letters.

//Expected input and output

//IsPalindrome("eye") → true

//IsPalindrome("home") → false

using System.Runtime.Intrinsics.X86;
using System.ComponentModel.DataAnnotations;

bool isPalindrome(string testString)
{
    for (int i = 0; i < testString.Length / 2; i++)
    {//Test case: String: eye, home
        if (testString[i] == testString[testString.Length - 1]) // Logic: If the first value of the index is equal to the value of the last index,
        {
            //Keep checking
            //Console.WriteLine($"Your letter {testString[i]} passes for now");
        }
        else
        {
            // Fails early so go home.
            //Console.WriteLine($"Your letter {testString[i]} is OBVIOUSLY not the same. FALSE");
            return false;
        }
    }
    //Console.WriteLine("TRUE!");
    return true;
}
string testString = "eye";
isPalindrome(testString);

testString = "home";
isPalindrome(testString);
#endregion

#region Question #2
//2.Sum digits in string

//Given a string, write a method which returns sum of all digits in that string. Assume that string contains only single digits.

//Expected input and output

//SumDigitsInString("1q2w3e") → 6 SumDigitsInString("L0r3m.1p5um") → 9

//SumDigitsInString("") → 0


string userInput = "1q2w3e";
//int sumInString(string userInput)
//{
//    int sum = 0;
//    for(int i = 0; i < userInput.Length; i++)
//    {
//        if (int.TryParse(userInput[i].ToString(), out int value)) // If the given character at the given index of the string userInput IS parseable, then add the value to sum.
//        {
//            sum += value;
//        }// Not really worried about else since 
//    }

//    Console.WriteLine(sum);
//    return sum;
//}
//sumInString(userInput);

//// Using ISDIGIT but I don't fully grasp the ASCII Unicode stuff
//int sumInString(string userInput)
//{
//    int sum = 0;
//    for (int i = 0; i < userInput.Length; i++)
//    {
//        if (char.IsDigit(userInput[i]))
//        {
//            sum += userInput[i] - '0';
//        }
//    }

//    Console.WriteLine(sum);
//    return sum;
//}
//sumInString(userInput);
//Comments: I was trying to do TryParse, but it's not ideal because we're doing character at a time.


//More advanced version is using a LINQ: int sum = userInput.Where(char.IsDigit).Sum(c => c - '0');
//That is pretty cool.
int sumInString(string userInput)
{
    int sum = userInput.Where(char.IsDigit).Sum(c => c - '0');
    Console.WriteLine(sum);
    return sum;
}

sumInString(userInput);
#endregion

#region Question #3

//3. Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//Input: nums = [2,7,11,15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].3. Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//Input: nums = [2,7,11,15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

//Given = array of integers nums, integer target --> int [] nums, int target
//Return = indicies of two numbers such that they add up to target --> index[x] + index[y] = target




// First Attempt
//int[] nums = { 2, 7, 11, 15 };
//int target = 9;
//int[] twoNumsForTarget(int[] nums, int target)
//{
//    for (int i = 0; i < nums.Length-1; i++)
//        if (nums[i] + nums[i+1] == target )
//        {
//            Console.WriteLine($"Answer: {i}, {i + 1}");
//            return new int[] {i, i + 1};
//        }
//    return new int[] { -1, -1 };
//}
//twoNumsForTarget(nums, target);
//Wrong because only checks neighboring values
//Console.ReadLine();

//Second attempt
int[] nums = { 2, 7, 11, 15 };
int targetSum = 9;
int[] twoSums (int[] nums, int targetSum)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = 0; j < nums.Length; j++)
            if (nums[i] + nums[j] == targetSum)
            {
                Console.WriteLine($"{i} , {j}");
                return new int[] { i, j };
            }
        
    }
    return new int[] { -1, 1 };
}
twoSums(nums, targetSum);
#endregion

#region Question #4

//4.You are given a string s consisting only of uppercase English letters.

//You can apply some operations to this string where, in one operation, you can remove any occurrence of one of the substrings "AB" or "CD" from s.

//Return the minimum possible length of the resulting string that you can obtain.

//Note that the string concatenates after removing the substring and could produce new "AB" or "CD" substrings.

//**Hint : Use Replace method of string.

string s = "ACBBD";
int minimumPossibleLength = 0;
//bool freeFromABCD = false;

while (s.Contains("AB") || s.Contains("CD"))
{// Tried using ContainsAny but seems unnecessarily convoluted?
    //s= s.Replace("AB", "").Replace("CD", "");
    //Mistaske= Forgot to assign the new string to a new string without AB or CD
    //We can also use regular expressions
    s = Regex.Replace(s, "AB|CD", "");
}
minimumPossibleLength = s.Length;

Console.WriteLine($"The minimum possible length of the string s is {minimumPossibleLength}");
#endregion


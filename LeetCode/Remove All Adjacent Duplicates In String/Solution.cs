using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_All_Adjacent_Duplicates_In_String
{
    public class Solution
    {
        // Function to process the string
        public string RemoveDuplicates(string s)
        {
            //Going with stack. 
            // Initially I tried with recursion but found out that worst case it can lead to O(n^2) due to how things can pan out
            // I'd need to keep iterating thru the string
            Stack<char> charStack = new();

            // Iterating thru s. 
            // Starting at the back because the return string will be reversed if we go from the front. And its fancy :3
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (charStack.Count > 0 && charStack.Peek() == s[i]) // Make sure stack has content and check if top is the same - in which case we'd popperoni.
                {
                    charStack.Pop();
                }
                else
                    charStack.Push(s[i]);
            }

            return string.Join("", charStack); // Whatever remains at the end, we're good to spit it right back for the answer.
        }
    }
}

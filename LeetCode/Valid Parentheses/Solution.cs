using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Parentheses
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            foreach (char c in s)
            {
                // Push opening brackets onto the stack
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    // If closing bracket but nothing to match, invalid
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    // Check if the closing bracket matches the most recent open
                    if (c == ')' && top != '(') return false;
                    if (c == '}' && top != '{') return false;
                    if (c == ']' && top != '[') return false;
                }
            }

            // Valid only if every opener was matched
            return stack.Count == 0;
        }
    }
}

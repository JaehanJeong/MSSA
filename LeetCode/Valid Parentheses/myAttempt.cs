using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Parentheses
{
    public class MyAttempt
    {
        public bool IsValid(string s)
        {
            //Switches that will turn false when opened.
            //Only when properly closed, will they return back to true.
            bool regularParentheses = true;
            bool curleyBraces = true;
            bool squareBrackets = true;
            bool correctOrder = true;

            if (s == "") return false;

            for (int i = 0; i < s.Length; i++)
            {// idk if switch is better
                if (s[i] == '(' && regularParentheses == true)
                {
                    regularParentheses = false;
                }
                if (s[i] == ')' && regularParentheses == false)
                {
                    regularParentheses = true;
                }

                if (s[i] == '{' && curleyBraces == true)
                {
                    curleyBraces = false;
                }
                if (s[i] == '}' && curleyBraces == false)
                {
                    curleyBraces = true;
                }
                if (s[i] == '[' && squareBrackets == true)
                {
                    squareBrackets = false;
                }
                if (s[i] == ']' && squareBrackets == false)
                {
                    squareBrackets = true;
                }
            }
            if (regularParentheses == true && curleyBraces == true && squareBrackets == true) return true;
            else return false;

            //how to account for ordering (condition #2)
            // even if those are all true... if ordering is off... we return false;

        }
    }
}

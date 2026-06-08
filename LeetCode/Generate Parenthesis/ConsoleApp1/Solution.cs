using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> results = new List<string>();
            Backtrack(results, "", 0, 0, n);
            return results;
        }

        private void Backtrack(List<string> results, string current, int open, int close, int n)
        {
            // recursion goes here
            if (open == n && close == n)
            {
                results.Add(current);
                return;
            }
            if (open < n)
            {
                Backtrack(results, current + "(", open + 1, close, n);
            }
            if (open > close)
            {
                Backtrack(results, current + ")", open, close + 1, n);
            }
        }
    }
}

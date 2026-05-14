using System;
using System.Collections.Generic;
using System.Text;

namespace Roman_to_Integer
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            // Map each symbol to its value — a switch works great here!
            int Value(char c) => c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int curr = Value(s[i]);

                // Peek ahead: if next symbol is larger, subtract current
                if (i + 1 < s.Length && curr < Value(s[i + 1]))
                    sum -= curr;
                else
                    sum += curr;
            }
            return sum;
        }
    }
}

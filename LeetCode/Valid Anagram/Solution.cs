using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Anagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> frequency = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i]; // Get the actual character from the string
                if (!frequency.ContainsKey(c))
                {
                    frequency[c] = 1;
                }
                else
                {
                    frequency[c]++;
                }
            }

            for (int j = 0; j < t.Length; j++)
            {
                char c = t[j];
                if (!frequency.ContainsKey(c))
                {
                    return false; // Character in 't' wasn't in 's'
                }

                frequency[c]--;

                if (frequency[c] < 0)
                {
                    return false; // 't' has more of this character than 's' does
                }
            }
            return true;
        }
    }
}

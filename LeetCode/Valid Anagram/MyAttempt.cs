using System;
using System.Collections.Generic;
using System.Text;

namespace Valid_Anagram
{
    public class MyAttempt
    {
        public bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            if (s.Length != t.Length) return false;

            for (int i = 0; i < s.Length; i++)
            {// 3a, 1n, 1g, 1r, 1m
                if (!frequency.ContainsKey('i'))
                {
                    frequency['i'] = 1;
                }
                else //(frequency.ContainsKey('i'))
                {
                    frequency['i']++;
                }
            }

            for (int j = 0; j < t.Length; j++)
            {
                // if(!frequency.ContainsKey('j'))
                // {
                //     return false;
                // }
                if (frequency.ContainsKey('j'))
                {
                    frequency['j']--;
                }
                if (frequency.['j'] < 0)
                {
                    return false;
                }

            }
            return true;
        }
    }
}

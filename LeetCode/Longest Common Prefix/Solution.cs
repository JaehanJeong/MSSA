using System;
using System.Collections.Generic;
using System.Text;

namespace Longest_Common_Prefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];

                foreach (string word in strs)
                {
                    if (i >= word.Length || word[i] != c)
                    {
                        return sb.ToString();
                    }
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}

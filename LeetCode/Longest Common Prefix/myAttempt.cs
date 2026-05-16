using System;
using System.Collections.Generic;
using System.Text;

namespace Longest_Common_Prefix
{
    public class myAttempt
    {
        public string LongestCommonPrefix(string[] strs)
        {
            //What we'll return
            string output = "";

            foreach (string word in strs)
            {//For each string in the string array strs
             //for each of those words - go through each character
             //Compare each character & exit early once all string words don't share the character.
                for (int i = 0; i < word.Length; i++)
                {
                    word[i];
                }

                //idk how to write compare word[i] of all the words.

                //if the word[i] of all the strings are the same,
                //Add to the output string, using the string builder.
                var builder = new StringBuilder();
                builder.append(word[i]);
            }

            // I feel like Hashset will be the optimal but idk how to logic it. 
            HashSet<char> prefix = new HashSet<char>();


            // convert string builder to output.





            return output;
        }
    }
}

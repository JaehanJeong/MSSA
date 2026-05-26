using System;
using System.Collections.Generic;
using System.Text;

namespace Length_of_Last_Word
{
    public class MySolution
    {
        public int LengthOfLastWord(string s)
        {
            string trimmedString = s.Trim();
            if (s == "") { return 0; }

            int lengthOfLastWord = 0;
            for (int i = trimmedString.Length - 1; i >= 0; i--)
            {
                if (trimmedString[i] == ' ')
                {
                    return lengthOfLastWord;
                }
                else lengthOfLastWord++;
            }
            return lengthOfLastWord;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Roman_to_Integer
{
    public class Solution2
    {
        public int RomanToInt(string s)
        {

            //sum that will absorb all parts of string s
            int sum = 0;
            //Loop thru the string s
            for (int i = 0; i < s.Length; i++)
            {
                //Maybe it starts with while(s[i] != 'I') --> != 'V' and so on??? no idea.
                while (s[i] == 'M') //Decide how to chop up the strings?
                {
                    if () // to deal with irregularities in the multiples of 5.
                    {
                    }
                += sum;
                    //Compute and add to sum
                }
                while (s[i] == 'D')
                {
                += sum;
                }
                while (s[i] == 'C')
                {
                += sum;
                }
                //some ways to multiple by digits, and convert them to int value to compute
                //No way this problem uses switches.. right?? 
            }
            return sum;
        }
    }


    //Some kind of loop to break down the string to 'digestable chunks'
    /*
    if number is 0<=3 we can use I's
    if numb is 4 we can use IV
    if num is 5 we can use V
    if num is 6<=8 we can use V& I's.
    if num is 9 we can use IX
    Maybe every 5, we do some tricks IDK
    */
}

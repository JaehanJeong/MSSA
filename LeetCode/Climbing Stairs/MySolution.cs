using System;
using System.Collections.Generic;
using System.Text;

namespace Climbing_Stairs
{
    public class MySolution
    {
        public int ClimbStairs(int n)
        {
            //Base & Default to build from?
            if (n == 0) { return 0; }
            if (n == 1) { return 1; }
            if (n == 2) { return 2; }

            //Place for memoization
            var dp = new Dictionary<int, int>();
            //Unsure if above if's are it or this is how we set the base case.
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;

            //Real meat --> Fill up the table
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}

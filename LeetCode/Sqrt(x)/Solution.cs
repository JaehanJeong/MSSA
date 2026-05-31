using System;
using System.Collections.Generic;
using System.Text;

namespace Sqrt_x_
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x == 0) return 0;

            long lo = 1, hi = x;

            while (lo <= hi)
            {
                long mid = lo + (hi - lo) / 2; // avoids overflow
                long sq = mid * mid;

                if (sq == x) return (int)mid;
                else if (sq < x) lo = mid + 1;  // too small, search right
                else hi = mid - 1;  // too big, search left
            }

            // hi is now the floor of sqrt(x)
            return (int)hi;
        }
    }
}

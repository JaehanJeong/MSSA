using System;
using System.Collections.Generic;
using System.Text;

namespace Best_Time_to_Buy_and_Sell_Stock
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int bestProfit = 0;
            int lowestPrice = prices[0];

            for (int day = 1; day < prices.Length; day++)
            {
                if (prices[day] < lowestPrice)
                {
                    lowestPrice = prices[day];
                }

                int profit = prices[day] - lowestPrice;

                if (profit > bestProfit)
                {
                    bestProfit = profit;
                }
            }

            return bestProfit;
        }
    }
}

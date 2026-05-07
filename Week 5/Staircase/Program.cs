//2.You are climbing a staircase. It takes n steps to reach the top.

//Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?


//Fibonacci?
//Dynamic Programming?
//Recursion?

//dp[i] = dp[i-1] + dp[i-2]
//number of ways to reach stair i = number of ways to reach i-1 and i-2 stair combined.
//Base cases
//dp[1] = 1
//dp[2] = 2

// =========== When I extend the base cases ===================//
//dp[3] = 3
//dp[4] = 5
//dp[5] = 8

//We'll use hard code entry for now
int n = 10;

//Memoization - Array where we'll store past answers.
int[] dp = new int[n+1];//+1 Because 

//Base cases
dp[1] = 1; // Only one way to go up 1 step of stair.
dp[2] = 2; // You can go 2 one steps or 1 two steps. [2 total ways]

//Memoization - actually adding past answers.
for(int i = 3; i <= n; i++) // Start at 3 cuz 1&2 are base cases. 
    //Go up to n which is where we are looking for answers.
{
    //Fibonacci concept
    dp[i] = dp[i - 1] + dp[i - 2];
}

Console.WriteLine($"{dp[10]}");

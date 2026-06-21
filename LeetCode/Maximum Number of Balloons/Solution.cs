public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        //Start with dictionary to keep count of each character
        Dictionary<char, int> charCount = new();

        // Either add to the dictionary or increment
        foreach (char c in text)
        {
            if (!charCount.ContainsKey(c))
            {
                charCount[c] = 1;
            }
            else
            {
                charCount[c]++;
            }
        }
        //Get counts (if possible) of each character
        charCount.TryGetValue('b', out int bCount);
        charCount.TryGetValue('a', out int aCount);
        charCount.TryGetValue('l', out int lCount);
        charCount.TryGetValue('o', out int oCount);
        charCount.TryGetValue('n', out int nCount);

        //Organizing our data. Dividing 2 since each balloon takes 2 of L and O's.
        int[] balloonCounts = { bCount, aCount, lCount / 2, oCount / 2, nCount };
        //We can only make as many as the lowest count, so spit that out.
        int result = balloonCounts.Min();

        return result;
    }
}
public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        // Taking care of edge case up front for speed!
        // Program will have to return false if magazine is shorter.
        if (ransomNote.Length > magazine.Length) return false;

        // Make dictionary to store magazine
        Dictionary<char, int> checkRansom = new();

        // Add characters from magazine string to the dictionary
        foreach (char c in magazine)
        {
            if (!checkRansom.ContainsKey(c))
            {
                checkRansom[c] = 1;
            }
            else
            {
                checkRansom[c]++;
            }
        }

        foreach (char c in ransomNote)
        {
            if (checkRansom.TryGetValue(c, out int count))
            {
                // Key was found
                if (count == 0) return false;
                else
                {
                    checkRansom[c]--;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
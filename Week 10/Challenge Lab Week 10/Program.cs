string s = "abcd"; string t = "abcde";

Dictionary<char, int> originalWord = new();

//Make the dictionary filled with original word's letters
for(int i = 0; i < s.Length; i++)
{
    if(!originalWord.ContainsKey(s[i]))
    {
        originalWord.Add(s[i], 1);
    }
    if(originalWord.ContainsKey((char)i))
    {
        originalWord[s[i]]++;
    }
}
for(int j = 0; j< t.Length; j++)
{
    char currentCharacter = t[j];

    if(originalWord.ContainsKey((currentCharacter)) && originalWord[currentCharacter] >0)
    {
        originalWord[currentCharacter]--;
    }

    else
    {
        Console.WriteLine($"The character that was added is {currentCharacter}");
    }
}


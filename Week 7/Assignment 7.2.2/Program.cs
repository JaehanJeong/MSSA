//2. Given a string s, reverse only all the vowels
//in the string and return it.

using System.Text;

string s = "aerodynamics";
StringBuilder sb = new StringBuilder();

//the order aspect of this problem reminded me of the valid parentheses problem i did yesterday.
// so I guess I'll try using stacks.
var stack = new Stack<char>();

//Probably need to loop thru the string right?
foreach(char c in s)
{
    //Probably need conditionals to only work with conditions?
    //Only push the vowels into the stack to remember.
    if(c == 'a' || c == 'e' || c == 'i' || c == 'o' ||  c == 'u')
    {
        stack.Push(c);
    }
}
// Now we create the new? string using string builder
for(int i = 0; i < s.Length; i++)
{
    if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
    {
        sb.Append(stack.Pop());
    }
    else
    {
        sb.Append(s[i]);
    }
}

Console.WriteLine(sb.ToString());
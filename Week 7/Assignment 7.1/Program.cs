using System.Globalization;
using System.Text;

static void SortGrades(int[] scores)
{
    int lowestGrade, temp = 0;
    for(int i = 0; i < scores.Length; i++)
    {
        lowestGrade = i;
        for(int j = i+1; j<scores.Length; j++)
        {
            if (scores[j] < scores[lowestGrade])
            {
                lowestGrade = j;
            }
        }

        if(lowestGrade != i)
        {
            temp = scores[i];
            scores[i] = scores[lowestGrade];
            scores[lowestGrade] = temp;
        }
    }
}

int[] scores = new int[] { 99, 91, 70, 25, 50, 80, 85, 90, 95, 100 };
SortGrades(scores);

Console.WriteLine(string.Join(",", scores));

static void MergeStrings()
{
    while (true)
    {
        Console.WriteLine("Enter the first string. (or type 'exit' to quit) ");
        string a = Console.ReadLine();
        if (a.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("You chose to exit the program.");
            break;
        }

        Console.WriteLine("Enter the second string. ");
        string b = Console.ReadLine();

        Console.WriteLine($"You entered\n string a: {a} \n string b: {b}");

        if(a.Equals("") || b.Equals(""))
        {
            Console.WriteLine("You've entered an empty string, so why do you need my help?");
            break;
        }

        Console.WriteLine("Now we'll combine those strings as much as we can in alternating fashion.");

        Console.WriteLine("Processing...");
        for(int i = 0; i< 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        Console.WriteLine("\n");
        //int totalLength = a.Length + b.Length;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
        {
            if (i < a.Length)
            {
                sb.Append(a[i]);
            }
            if(i < b.Length)
            {
                sb.Append(b[i]);
            }
        }
        Console.WriteLine(new string('=', 30));// separating for next round
        Console.WriteLine($"\n The merged string is: {sb.ToString()}");
    }
}
MergeStrings();
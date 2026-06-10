namespace LINQDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 92, 97, 81, 60, 95, 34 };

            var scoreresults = from score in scores
                               where score > 60
                               orderby score descending
                               select score;
            Console.WriteLine($"Scores greater than 60 and their count is {scoreresults.Count()}");
            foreach(var s in scoreresults)
            {
                Console.WriteLine(s);
            }
            //Deferred query execution
            //When we add ().ToList() --> 2. Forced query execution --> won't show Mark
            List<string> names = new List<string>()
            {
                "Zoe", "Alex", "John", "Emily", "Sarah", "Nathan", "May"
            };
            var results_M = (from name in names
                            where name.StartsWith("M")
                            select name).ToList();
            Console.WriteLine("Names starting with M are ..");
            names.Add("Mark");
            foreach(var name in results_M)
            {
                Console.WriteLine(name);
            }
        }
    }
}

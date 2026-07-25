namespace ConsoleApp1
{
    internal class Program
    {

        static string[] UsAliases =
        {
            "United States",
            "United States of America",
            "USA",
            "U.S.A",
            "US",
            "U.S",
            "America",
            "The United States",
            "The United States of America",
            "States",
            "US of A",
            "U S A",
            "U S",
            "UnitedStates",
            "UnitedStatesOfAmerica"
        };

        static string GreetUser(string firstName, string lastName, string country)
        {
            // If American
            if (UsAliases.Contains(country))
            {
                return $"Hello fellow American {firstName} {lastName}";
            }
            // Else
            else
            {
                return $"Hello, {firstName} {lastName} from {country}";
            }
        }




        static void Main(string[] args)
        {
            Console.WriteLine(GreetUser("Jaehan", "Jeong", "USA"));
        }
    }
}

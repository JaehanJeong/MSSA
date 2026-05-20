namespace Mod2OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            c1.Radius = 23.2;
            Circle c2 = new Circle();
            c2.Radius = 12;
            Circle c3 = c1 + c2;


            Console.WriteLine($"The third circle's area is {c3.Area}");
            Circle c4 = c1 + c2 + c3;
        }
    }
}

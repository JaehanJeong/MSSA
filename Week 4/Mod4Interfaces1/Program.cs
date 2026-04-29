namespace Mod4Interfaces1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Need the object equate to the class that has implemented it.
            DisplayClass displayClass = new DisplayClass();
            //IDisplay obj = new DisplayClass();
            //displayClass.Dispose();

            //Explicit implementation
            IMath math = new Maths();
            IMath2 math2 = new Maths();
        }
    }
}

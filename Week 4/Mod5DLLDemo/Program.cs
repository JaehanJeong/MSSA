using DLL;
namespace Mod5DLLDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            Conversions.DegreesToFahrenheit(45.6d);
            Test obj1 = new Test();
            Coffee c = new Coffee();
            //c.IsFairTrade = true; // If implicitly implemented, you can see the property
            
            //Explicit
            IBeverage beverage = new Coffee();
            //beverage.IsFairTrade = true;

            IInventoryItem inventory = new Coffee();
            //You can't use class object to call if you use explicit.
            //That means you gota use the interface name to call it.

        }
    }
}




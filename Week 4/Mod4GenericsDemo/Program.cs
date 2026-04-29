using System.Collections;

namespace Mod4GenericsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 3; // value type : stack
            object o; // highest level base class //reference type, class : heap
            //boxing - box can hold anything!
            o = i; // value type into ref type is boxing. Easy, but not recommended.

            // unboxing
            int j = (int) o; // ref type back to value || need type casting (int) to tell the compiler what we're expecting from left side.
            // we should avoid boxing-unboxing
            ArrayList list = new ArrayList(); // Dynamic array of objects
            list.Add(5);
            list.Add('c');
            list.Add("hehe");

            foreach(var obj in list)
            {
                Console.WriteLine(obj.ToString() + " " + obj.GetType());
            }
        }
    }
}

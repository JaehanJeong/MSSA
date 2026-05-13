namespace Mod5StackArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack<string> operations = new();
            //operations.Push("color change");
            //operations.Push("font change");
            //operations.Push("text bold");
            //foreach(var op in operations)
            //{
            //    Console.WriteLine(op);
            //}

            //Console.WriteLine($"Operation popped: {operations.Pop()}");
            //Console.WriteLine("after pop..");
            //foreach(var op in operations)
            //{
            //    Console.WriteLine(op);
            //}

            //operations.Peek();

            StackArray mystack = new(25);
            mystack.Push(10);
            mystack.Push(20);
            mystack.Push(30);
            mystack.Push(40);
            mystack.Display();
            Console.WriteLine($"Peek value:{mystack.Peek()}");
            mystack.Pop();
            Console.WriteLine("after pop");
            mystack.Display();
            mystack.Pop();
            mystack.Pop();
            mystack.Pop();
            mystack.Pop();
            mystack.Pop();

        }
    }
}

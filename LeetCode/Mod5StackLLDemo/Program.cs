namespace Mod5StackLLDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackLL stack = new();
            stack.Push(34);
            stack.Push(12);
            stack.Push(56);
            stack.Push(89);
            stack.Display();
            stack.Pop();
            Console.WriteLine("after pop");
            stack.Display();
            //LL is better than array because you don't have to allocate extra memory for uncertain size.
        }
    }
}

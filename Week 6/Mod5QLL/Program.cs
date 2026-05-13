namespace Mod5QLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Q myq = new Q();
            myq.Enqueue(23);
            myq.Enqueue(2);
            myq.Enqueue(12);
            myq.Enqueue(78);
            myq.Display();
            Console.WriteLine($"After dq: {myq.Dequeue()}");
            myq.Display();
            myq.Dequeue();
            myq.Dequeue();
            myq.Dequeue();
            myq.Dequeue();
        }
    }
}

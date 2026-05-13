namespace Mod5QArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> custq = new Queue<string>();
            custq.Enqueue("Neil");
            custq.Enqueue("Zoe");
            foreach(var cust in custq)
            {
                Console.WriteLine(cust);
            }
            Console.WriteLine($"after dq {custq.Dequeue()}");
            foreach(var cust in custq)
            {
                Console.WriteLine(cust);
            }

            Q myq = new Q(25);
            myq.Enqueue(12);
            myq.Enqueue(45);
            myq.Enqueue(56);
            myq.Display();
            Console.WriteLine($"deq: {myq.Dequeue()}");
            myq.Display();
            Console.WriteLine($"deq: {myq.Dequeue()}");
            Console.WriteLine($"deq: {myq.Dequeue()}");
            myq.Display();
        }
    }
}

namespace Mod4LinkedListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LinkedList<int> nums = new LinkedList<int>();
            //nums.AddLast(34);
            //nums.AddFirst(12);
            //Console.WriteLine(nums.Find(12).Value);

            //Creating linkedlist object
            LinkedList myll = new LinkedList();
            myll.AddFirst(12);
            myll.AddFirst(45);
            myll.Display();
            Console.WriteLine(myll.Search(45));

            Console.WriteLine("Now doing add last.");
            myll.AddLast(89);
            myll.Display();

            Console.WriteLine("Now we remove first.");
            Console.WriteLine($"{myll.RemoveFirst()} is removed");
            myll.Display();

            Console.WriteLine(myll.RemoveLast());
            myll.Display();


            myll.AddFirst(23);
            myll.AddLast(67);
            myll.AddAnywhere(34, 2);

            myll.Display();

            Console.WriteLine();
            Console.WriteLine($"{myll.RemoveAnywhere(2)} is removed. ");// remove something at position no#2

            myll.Display();

        }
    }
}

namespace Mod4LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums.Add(1);
            nums.Add(2);
            
            LinkedList<int> numslist = new LinkedList<int>();
            numslist.AddFirst(23);
            numslist.AddFirst(89);
            numslist.AddLast(78); 
            foreach(int n in numslist)
            {
                Console.Write(n + " ");
            }
            var node23 = numslist.Find(23);
            numslist.AddAfter(node23, 12);

            // 89 23 12 78
            var node12 = numslist.Find(12);
            numslist.AddBefore(node12, 45);

            //or you can do
            //numslist.AddAfter(node12, 45);


            Console.WriteLine();
            Console.WriteLine("After adding");
            foreach (int n in numslist)
            {
                Console.Write(n + " ");
            }

        }
    }
}

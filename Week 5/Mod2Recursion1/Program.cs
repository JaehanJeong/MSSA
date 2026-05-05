using System.IO;
namespace Mod2Recursion1
{
    internal class Program
    {
        static void PrintDirectories(string path, int depth)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
                if (depth > 0) // base condition (exit condition)
                {
                    PrintDirectories(dir, depth - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            const string path = @"C:\MSSA";
            string[] directories = Directory.GetDirectories(path);

            //Repetitive loops
            //foreach (var dir in directories)
            //{
            //    Console.WriteLine(dir);
            //    string[] subdirs = Directory.GetDirectories(dir);
            //    foreach(var subdir in  subdirs)
            //    {
            //        Console.WriteLine(subdir);
            //        string[]subsubdirs = Directory.GetDirectories(subdir);
            //        foreach(var item in  subsubdirs)
            //        {
            //            Console.WriteLine(item);
            //        }
            //    }
            //}
            PrintDirectories(path, 2);
        }
    }
}

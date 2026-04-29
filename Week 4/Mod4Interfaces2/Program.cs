namespace Mod4Interfaces2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int>nums=new List<int>();
            nums.AddRange(new int[] { 45, 67, 12, 89, 90 }); // Add all these to the list
            nums.Sort(); // Default: ascending order
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }

            //Creating list for demonstration
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Joe", GPA = 3f, Age = 18 });
            students.Add(new Student() { Id = 2, Name = "Aoe", GPA = 4f, Age = 16 });
            students.Add(new Student() { Id = 3, Name = "Boe", GPA = 3f, Age = 14 });
            students.Add(new Student() { Id = 4, Name = "Coe", GPA = 2f, Age = 16 });
            students.Sort();
            Console.WriteLine("Alphabetical sorting");
                foreach(var stud in students)
            {
                Console.WriteLine($"{stud.Name} {stud.Age}");
            }
            Console.WriteLine("GPA sorting");
            foreach (var stud in students)
            {
                Console.WriteLine($"{stud.Name} {stud.GPA}");
            }
            students.Sort(new Student()); // Logic for comparer. Needs the IComparer
        }
    }
}

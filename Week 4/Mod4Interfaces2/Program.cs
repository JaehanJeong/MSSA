namespace Mod4Interfaces2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums.AddRange(new int[] { 45, 67, 12, 89, 90 });
            nums.Sort();
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }

            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Amy", GPA = 4.3f, Age = 18 });
            students.Add(new Student() { Id = 2, Name = "Zoe", GPA = 3.3f, Age = 17 });
            students.Add(new Student() { Id = 3, Name = "Nathan", GPA = 4.1f, Age = 16 });
            students.Sort();
            Console.WriteLine("Alphabetical sorting");
            foreach (var stud in students)
            {
                Console.WriteLine($"{stud.Name} {stud.Age}");
            }
            students.Sort(new Student());
            Console.WriteLine("GPA sorting");
            foreach (var stud in students)
            {
                Console.WriteLine($"{stud.Name} {stud.GPA}");
            }
            students.Sort(new StudentAgeComparer());
            Console.WriteLine("age sorting");
            foreach (var stud in students)
            {
                Console.WriteLine($"{stud.Name} {stud.Age}");
            }
            students.Sort((x, y) => x.Age.CompareTo(y.Age));

        }
    }
}

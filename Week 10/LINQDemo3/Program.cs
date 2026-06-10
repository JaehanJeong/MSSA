using System.Security.Cryptography.X509Certificates;

namespace LINQDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ Id = 1, Age = 20, Name = "Alice", GPA = 4.3f},
                new Student(){ Id = 2, Age = 21, Name = "Amy", GPA = 3.3f},
                new Student(){ Id = 3, Age = 19, Name = "Dave", GPA = 3.9f},
                new Student(){ Id = 4, Age = 21, Name = "Emily", GPA = 2.9f},
                new Student(){ Id = 5, Age = 20, Name = "Charlie", GPA = 4.6f},
            };

            var results_age = from s in students
                              where s.Age >= 20 && s.Age <= 21
                              orderby s.Name
                              select new { s.Name, s.Id }; // Anonymous type

            Console.WriteLine("Students in range of 20-21");
            foreach (var s in results_age)
            {
                Console.WriteLine($"{s.Id} {s.Name}");
            }

            Console.WriteLine("Students as per ascending grades");
            var results_grade = from s in students
                                orderby s.GPA
                                select s;
            foreach(var s in results_grade)
            {
                Console.WriteLine(s.Name + " " + s.GPA);
            }

            var averageage = students.Average(a => a.Age);
            Console.WriteLine($"Average age: {averageage} years");

            var maxgpa = students.Select(s => s.GPA).Max();
            Console.WriteLine($"Max gpa: {maxgpa} ");

            var maxgradestud = from s in students
                               where s.GPA == students.Max(s => s.GPA)
                               select new {s.Name};
            Console.WriteLine("Highest GPA scorer");
            foreach(var s in maxgradestud)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}

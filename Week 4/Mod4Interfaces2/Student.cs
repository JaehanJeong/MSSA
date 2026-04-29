using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod4Interfaces2
{
    class StudentAgeComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    internal class Student:IComparable<Student>,IComparer<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }
        public int Age { get; set; }

        public int Compare(Student? x, Student? y)
        {
            return y.GPA.CompareTo(x.GPA);
        }

        public int CompareTo(Student? other)
        {
            int val = String.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
            return val;
        }
    }
}

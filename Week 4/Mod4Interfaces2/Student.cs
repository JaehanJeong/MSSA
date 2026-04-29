using System;
using System.Collections.Generic;
using System.Text;

namespace Mod4Interfaces2
{

    class StudentAgeComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    //NEEDED FOR GPA ASSIGNMENT
    internal class Student : IComparable<Student>, IComparer<Student>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float GPA { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student? other)
        {
            int val = String.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
            return val;
        }

        int IComparer<Student>.Compare(Student? x, Student? y)
        {
            return y.GPA.CompareTo(x.GPA);
        }
    }
}

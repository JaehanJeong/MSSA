using System;
using System.Collections.Generic;
using System.Text;
// Referred to 28APR (MSSA DAY 17) Material - Interfaces demo 2
namespace Assignment_4._2_Teacher_Student_Forms
{
    internal class Student : IComparable<Student>, IComparer<Student>
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public float GPA { get; set; }
        
        public int Compare(Student? x, Student? y)
        {
            return y.GPA.CompareTo(x.GPA);
        }

        public int CompareTo(Student? other)
        {
            int val = String.Compare(this.StudentName, other.StudentName, StringComparison.OrdinalIgnoreCase);
            return val;
        }
    }
}

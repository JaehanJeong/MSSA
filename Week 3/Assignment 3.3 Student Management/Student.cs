using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3._3_Student_Management
{
    enum Month
    {
        January = 1,
        February = 2, // Don't have to type it all (as long as i have the first) but looks nicer :)
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    internal class Student
    {
        public int studid { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? address { get; set; }
        public Month monthOfAdmission { get; set; }

        public char? grade { get; set; }
    }
}

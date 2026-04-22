using System;
using System.Collections.Generic;
using System.Text;
//Write a class: “Student” with private data members:
//StudentId (int), StudentFname (string), StudentLname (string), StudentGrade (char) and public properties for each data member.
//Instantiate the class and assign data to properties. Display the data back on console.
namespace Assignment1._1._4.Model
{
    public class Student
    {
        private int studentId;
        public int StudentId { get; set; }

        private string studentFirstName;
        public string StudentFirstName { get; set; }

        private string studentLastName;
        public string StudentLastName { get; set; }

        private char studentGrade;
        public char StudentGrade { get; set; }

    }
}

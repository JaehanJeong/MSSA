using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3._3_Student_Management
{//wrapper class - accessible from all forms?
    internal class Data
    {
        //static class so that theres only one list (tough to move data between forms)
        public static List<Student> Students = new List<Student>();
    }
}

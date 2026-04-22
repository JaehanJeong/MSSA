using System;
using System.Collections.Generic;
using System.Text;

namespace Mod3EmpSystem
{//wrapper class - accessible from all forms?
    internal class Data
    {
        // Static class so that theres only one list (tough to move data between forms)
        public static List<Employee> Employees = new List<Employee>();

    }
}

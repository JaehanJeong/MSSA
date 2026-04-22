using System;
using System.Collections.Generic;
using System.Text;

namespace Mod3EmpSystem
{
    enum Department
    {
        IT = 1,
        Finance,
        HR,
        Marketing
    }
    internal class Employee
    {
        public int EmployeeID { get; set; } // There should be unique ID with object or data to prevent dupes
        public string? Name { get; set; }
        public double salaray { get; set; }
        public Department Department { get; set; }  // First department is Enum department and second is the variable name. | Type, Variable Name
        

    }
}

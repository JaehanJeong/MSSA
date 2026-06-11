using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mod7EmpMgmtSystem.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
    }
}

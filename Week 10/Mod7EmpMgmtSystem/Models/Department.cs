using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mod7EmpMgmtSystem.Models
{
    public class Department
    {
        [Key]
        public int DeptId {  get; set; }
        public string DeptName {  get; set; }
        public string Location { get; set; }
        //1 to many relation 
        public virtual ObservableCollectionListSource<Employee>Employees { get; set; }

    }
}

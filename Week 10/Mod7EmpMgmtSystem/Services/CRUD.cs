using Mod7EmpMgmtSystem.Data;
using Mod7EmpMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mod7EmpMgmtSystem.Services
{
    public static class Records
    {
        public static EmployeeContext context;
    }
    public class CRUD
    {
        public void AddEmployee(Employee emp)
        {
            Records.context.Employees.Add(emp);
            Records.context.SaveChanges(); // updating the db
        }
        public List<Employee> GetAllEmployees ()
        {
            return Records.context.Employees.ToList();
        }
        public List<Department>GetAllDepartments()
        {
            return Records.context.Departments.ToList();
        }

        public void DeleteEmployee(int id)
        {
            var emp = Records.context.Employees.Find(id);
            if (emp != null)
            {
                Records.context.Employees.Remove(emp);
                Records.context.SaveChanges();
            }
        }

        public void UpdateEmployee(int id, Employee emp)
        {
            var existingEmp = Records.context.Employees.Find(id);
            if(existingEmp!=null)
            {
                existingEmp.EmpName = emp.EmpName;
                existingEmp.Salary = emp.Salary;
                existingEmp.DeptId = emp.DeptId;
                Records.context.SaveChanges();
            }
        }

    }
}

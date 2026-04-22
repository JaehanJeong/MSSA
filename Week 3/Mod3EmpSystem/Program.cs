namespace Mod3EmpSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Dummy data to test
            Data.Employees.Add(new Employee() { EmployeeID = 1, Name = "Joe Shumo", salaray = 67, Department = Department.Marketing});
            Data.Employees.Add(new Employee() { EmployeeID = 2, Name = "Joe Mama", salaray = 69, Department = Department.HR});
            Application.Run(new MainForm());
        }
    }
}
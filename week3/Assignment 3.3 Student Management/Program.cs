namespace Assignment_3._3_Student_Management
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
            Data.Students.Add(new Student() { studid = 1, firstName = "Jaehan", lastName = "Jeong", address = "123 Joe st",grade = 'A' ,monthOfAdmission = Month.April });
            Application.Run(new MainForm());
        }
    }
}
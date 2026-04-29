namespace Assignment_4._2_Teacher_Student_Forms
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
            var student = new Student()
            {
                StudentId = 1,
                StudentName = "King Nerd",
                GPA = 4.0f
            };
            Data.Students.Add(student);
            Application.Run(new TeacherLogin());
        }
    }
}
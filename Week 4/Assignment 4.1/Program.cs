namespace Assignment_4._1
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


            //How I was doing it with list. Need a new way to do this since Dictionary work differently.
            //Data.Persons.Add(new Person()
            //{
            //    FirstName = "Jaehan",
            //    LastName = "Jeong",
            //    Address = "1234",
            //    MobilePhone = "1512",
            //    WorkPhone = "5678"
            //});

            var person = new Person()
            {
                FirstName = "Jaehan",
                LastName = "Jeong",
                Address = "1234",
                MobilePhone = "2345",
                WorkPhone = "4567",
            };
            string key = $"{person.FirstName} {person.LastName}"; // Key to search the person. Firstname space Lastname

            Data.PersonDict.Add(key, person); // Add the person to the dictionary - great for search! O(1)
            Data.Persons.Add(person); // And to the list. (I want to keep it for UI - BindingList is very neat.
                                      // WinForms binds to enumerable collections (like List/BindingList), not key-value stores.


            Application.Run(new MainForm());
        }
    }
}
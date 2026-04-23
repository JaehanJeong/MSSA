namespace Assignment_3._4
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

            // Hardcoding a coffee object
            Data.Coffees.Add(new Coffee()
            {
                CoffeeName = CoffeeName.Mocha,
                Milk = MilkType.Whole,
                Bean = BeanType.DarkRoast,
                Shots = 1,
                BeverageSize = beverageSize.Medium
            });

            //Start at MainForm
            Application.Run(new MainForm());
        }
    }
}
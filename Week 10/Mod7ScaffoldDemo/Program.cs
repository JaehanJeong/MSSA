namespace Mod7ScaffoldDemo
{
    internal class Program
    {
        //Code First: model classes, context, create db from classes

        //DB first now --> create classes, context classes

        /*
         * Need: Entity Framework.Core.Tools + Entity Framework Core SQL server
         * Command to pull from DB to create context.cs
         Scaffold-DbContext 'Server=DESKTOP-EA8DDSO;Database=BlogDB;Trusted_Connection=True;Integrated Security=True;trustservercertificate=True' Microsoft.EntityFrameworkCore.SqlServer
         */
        static void Main(string[] args)
        {
            //Iprint obj = new WordGenerator();
            //Iprint obj2 = new PDFGenerator();
        }
    }
}

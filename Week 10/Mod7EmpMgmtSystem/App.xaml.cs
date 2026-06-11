using System;
using System.Data;
using System.Printing;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Identity.Client;
using Mod7EmpMgmtSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace Mod7EmpMgmtSystem
{

    /// <summary>
    ///  Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            Records.context = new Data.EmployeeContext();
            Records.context.Database.EnsureDeleted();
            Records.context.Database.EnsureCreated(); // creates a db with tables with data seeding
            Records.context.Departments.Load();
            Records.context.Employees.Load();
            var mainwindow = new MainWindow();
            mainwindow.Show();
        }

    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Assignment_10._3.Models
{

//    Create a table “Cars”. Add columns like VIN, Make, Model, Year, Price etc.

//Create a Windows forms app to display records in grid.Perform basic CRUD.

//Use the code first approach.
    public class Car
    {
        [Key]
        public int VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

    }
}

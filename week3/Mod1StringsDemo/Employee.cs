using System;
using System.Collections.Generic;
using System.Text;

namespace Mod1StringsDemo
{
    // system.Object is the base class 


    // FOUR PRINCIPLES OF OOP INTERVIEW QUESTION
    // 1. Abstraction
    // 2. Encapsulation - putting together data, and different functionalities. 
    // Characteristics (properties), behaviors (functions)
    // 3. Inheritance - create hierarchy, for reusability, maintainability
    // Base class has some functionality so you don't
    // 4. Polymorphism - change the things as needed. Virtual & override
    public class Employee
    {
        public Employee (int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        private int id; // member variables /field are camel case
        public int Id // Properties are capitalized (pascal case)
        {
            get { return this.id; } 
            set { id = value; } // If set block is omitted, it's READ ONLY
            // You can also add validation steps in this like the following
            //set
            //{
            //    if (value>0)
            //    {
            //        this.id = value;
            //    }
            //    if (value<0)
            //    {
            //        Console.WriteLine("Invalid ID");
            //    }
            //}

        }
        public string Name { get; set; } // auto implemtned property
        // There will be private backing field created for this, 
        // But we don't see it as the developer.

    }
}

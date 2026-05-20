using System;
using System.Collections.Generic;
using System.Text;

namespace Mod2Inheritancedemo
{
    internal class Student : Person
    {
        public float GPA {  get; set; }
        
        
        // By default it invokes the corresponding constructor in the base class.
        // If we don't provide these 2, how will the compiler call? It needs those 2 parameters.
        // Parameterized constructor therefore is needed here.
        // constructor with parameters passing the values to base class constructor
        public Student(string firstname, string lastname) : base(firstname, lastname)
        {
        }

        //public override void FollowSchedule() // This is a must otherwise compiler has nothing to work with abstract method follow schedule
        //{
        //    throw new NotImplementedException();
        //}

        // Dynamic polymorphism
        // At run time it'll call respective student / teacher class
        public override void FollowSchedule() // This is a must otherwise compiler has nothing to work with abstract method follow schedule
        {
            Console.WriteLine("I attend virtual sessions for c#");
        }
        
        
        public override void DoWork()
        {
            //base.DoWork(); // You are allowed to call any base class functionality
            Console.WriteLine("I study "); // Functionality can be managed and changed in derived class
        }

    }
}

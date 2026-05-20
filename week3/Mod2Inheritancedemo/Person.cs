using System;
using System.Collections.Generic;
using System.Text;

namespace Mod2Inheritancedemo
{
    internal abstract class Person
    {
        public string FirstName { get; set; }
        // if we don't have get set, it's just a field (public variable). 
        // If you intend to have them as property, never leave them as is (make sure to include get set)
        public string LastName { get; set; }
        public DateOnly DOB { get; set; } // Don't need time here
        public string Address { get; set; }
        public Person(string firstname, string lastname)
            // Constructor- if we have some values already, that means you want users to have those properties.
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            //good place to use this. just to ensure that spellings are correct
        }
        public void Introduce()
        {
            Console.WriteLine($"Hello, myname is {FirstName} {LastName}, my address is {Address}");
        }
        // Polymorphism
        // Virtual methods allow the derived classes to change the functionality if needed.
        public virtual void DoWork()
        {
            Console.WriteLine($"I work..");
        }

        // Abstract methods must be implmented by the derived class because there is no body here.
        public abstract void FollowSchedule();
        // Abstract methods have to be inside a abstract class
        // You're forcing your derived classes to have SOMETHING to make code work.

        




    }
}

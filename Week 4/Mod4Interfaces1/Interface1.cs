using System;
using System.Collections.Generic;
using System.Text;

namespace Mod4Interfaces1
{
    class A
    {

    }
    class B
    {

    }
    //No multiple inheritance with classes.
    //class C : A, B
    //{

    //}

    // Because of lack of data in interfaces,
    // you can have multiple interfaces to give behaviors.
    // Written so we can change behaviors in classes.

    internal interface IDisplay // keyword interface + 'I' + interface name
    {
        void Display(string name);//no public keyword cuz by default its public
        // To be implemented by others, it has to be accessible

        // private int i; also not allowed. Interfaces can't have data of its own.
        // Interfaces are meant to contain behavior and functions.
        // They have to be implemented by classes.

        //Teacher's comments
        //It has no state - therefore no data fields.
        //Can have properties, methods, indexers 
    }

    class DisplayClass : IDisplay, IDisposable // You wana use the lightbulb to interface cuz it'll generate 
        //all the methods ( you might not know all) or how they're written
        // single class can implement multiple interfaces.
        // But single class can't have multiple inheritances
    {
        public void Display(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

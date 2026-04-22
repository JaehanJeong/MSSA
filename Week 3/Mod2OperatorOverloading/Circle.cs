using System;
using System.Collections.Generic;
using System.Text;

namespace Mod2OperatorOverloading
{
    internal class Circle
    {
        public double Radius { get; set; }
        // class can be combination of both
        // auto implemented like above
        // elaborated like below
        private double area;

        public double Area
        {
            get
            {
                this.area = Math.PI * Radius * Radius;
                return this.area; // make sure area is not capitalized. If you do, it's gona call this method again which causes infinite loop and crash
                //return member field, not the property
            }
            // No need for a set block since we are calculating using the radius
        }

        // Operator overload needs to be static
        public static Circle operator +(Circle c1, Circle c2) // Client won't know what's going on inside.
        {
            Circle newCircle = new Circle();
            newCircle.Radius = c1.Radius + c2.Radius;
            return newCircle;
        }

    }
}

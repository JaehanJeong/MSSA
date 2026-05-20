using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3._2.Models
{
    internal class Circle
    {
        //Circle's radius
        public double Radius { get; set; }

        //Function to calculate the area
        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        // Operator overload needs to be static
        public static double operator +(Circle c1, Circle c2) // Client won't know what's going on inside.
        {
            return c1.Area + c2.Area;
        }

        public static double operator -(Circle c1, Circle c2)
        {
            return c1.Area - c2.Area;
        }
    }
}

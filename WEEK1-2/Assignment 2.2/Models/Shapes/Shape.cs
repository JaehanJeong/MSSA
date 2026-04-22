using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

//3.Write a abstract base class: ‘Shape’ and add properties like id, name and color and method ‘calculate area’ .

//Inherit circle shape from base class and add properties like radius. override calculate area logic for circle.

//Inherit square class from shape and change the calculate area logic. Add property like side of square.

//Take the input from user to select circle or square and display the calculated area . no hard coded values!





namespace Assignment_2._2.Models.Shapes
{
    public abstract class Shape
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public abstract double calculateArea();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Assignment1._1._4.Models
{
    public class Point
    {
        public double xCoordinate { get; set; }

        public double yCoordinate { get; set; }

        public void compareXCoordinates(Point firstPoint, Point secondPoint)
        {
            if (secondPoint.xCoordinate > firstPoint.xCoordinate)
            {
                Console.WriteLine("Point 2 is located on the right side of point 1.");
            }
            else if (secondPoint.xCoordinate < firstPoint.xCoordinate)
            {
                Console.WriteLine("Point 1 is located on the right side of point 1.");
            }
            else if (secondPoint.xCoordinate == firstPoint.xCoordinate)
            {
                Console.WriteLine("They are on the same x coordinate :)");
            }
        }
        public void compareYCoordinates(Point firstPoint, Point secondPoint)
        {
            if (secondPoint.yCoordinate > firstPoint.yCoordinate)
            {
                Console.WriteLine("Point 2 is located higher than point 1.");
            }
            else if (secondPoint.yCoordinate < firstPoint.yCoordinate)
            {
                Console.WriteLine("Point 2 is lower than point 1.");
            }
            else if (secondPoint.yCoordinate == firstPoint.yCoordinate)
            {
                Console.WriteLine("They are on the same y coordinate :)");
            }
        }

        public void calculateDistance(Point firstPoint, Point secondPoint)
        {
            double width = secondPoint.xCoordinate -= firstPoint.xCoordinate;
            double length = secondPoint.yCoordinate -= firstPoint.yCoordinate;
            double distance = Math.Sqrt((width * width) + (length * length));
            Console.WriteLine($"The distance between the two given points is {distance}");
        }



    };
}

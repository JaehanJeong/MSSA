using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4._2
{
    internal class Maths : ICalculator
    {
        public double Add(double x, double y) => x + y;
        public double Subtract(double x, double y) => x - y;
        public double Multiply(double x, double y) => x * y;
        public double Divide(double x, double y) => (x / y);
        public double ChangeSign(double x) => (x * -1);
    }
}

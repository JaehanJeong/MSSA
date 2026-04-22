using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//2.Overloading: Write a simple Maths class (don’t use the keyword Math, it will be a conflict with standard class from system).
//Write overloaded methods with logic and give choice to user to call different methods :
//a.Add(int num1, int num2)
//b.Add(decimal num1, decimal num2, decimal num3)
//c.Multiply(float num1, float num2)
//d.Multiply(float num1, float num2, float num3)
//Declare these methods as public and static.

namespace Assignment_2._2.Models
{
    public class Maths
    {

        // A
        public static int addNums (int number1, int number2)
        {
            return (number1 + number2);
        }
        // B
        public static decimal addNums (decimal number1, decimal number2, decimal number3)
        {
            return (number1 + number2 + number3);
        }
        // C
        public static float multiplyNums(float number1, float number2)
        {
            return (number1 * number2);
        }
        // D
        public static float multiplyNums(float number1, float number2, float number3)
        {
            return (number1 * number2 * number3);
        }
    }
}

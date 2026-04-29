using System;
using System.Collections.Generic;
using System.Text;

namespace Mod4Interfaces1
{
    internal interface IMath
    {
        int Add(int num1, int num2);
        int Subtract(int num1, int num2);
        int Multiply(int num1, int num2);

    }

    class Maths : IMath
    {
        public int Add(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        public int Multiply(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int num1, int num2)
        {
            throw new NotImplementedException();
        }
    }
    class IMaths2 : IMath
    {
        public int Add(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        public int Multiply(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int num1, int num2)
        {
            throw new NotImplementedException();
        }
    }
}

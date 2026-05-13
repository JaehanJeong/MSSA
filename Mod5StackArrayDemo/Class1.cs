using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5StackArrayDemo
{
    internal class StackArray
    {
        private int[] data;
        private int top;
        public StackArray()
        {
            data = new int[50];
            top = -1;
        }
        public StackArray(int size)
        {
            data = new int[size];
            top = -1; //initially empty stack
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
        public bool IsFull()
        {
            return top == data.Length - 1;
        }

        public void Push (int val) // Int because we're pushing integer value. Would be T if it was generic
        {
            if(IsFull())
            {
                Console.WriteLine("The stack is full!");
                return;
            }
            //top++;//top = -1, --> top = 0
            //data[top] = val; // Assigning the value to the top's data. 
            //data[0] = 10, data[1] = 20
            //Can also write as
            data[++top] = val;

        }

        public int Pop()
        {
            if(IsEmpty())
            {
                //better to throw exception than use -1 or something cuz that might mess up the stack
                throw new InvalidOperationException("Stack is empty!");
            }
            int value = data[top];
            top--;
            return value;
        }

        public int Peek()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return data[top];
        }

        public void Display()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            for (int i = top; i>=0; i--)
            {
                Console.WriteLine(data[i]);
            }
        }

    }
}

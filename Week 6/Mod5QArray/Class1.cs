using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5QArray
{
    internal class Q
    {
        int[] data;
        int front, rear, size;

        //Size: size of active elements in q
        //Capacity: Max capacity of array
        public Q(int capacity)
        {
            data = new int[capacity];
            front = -1;
            rear = -1;
            size = 0;
        }

        public bool IsEmpty()
        {
            return this.size == 0; // If it is 0, return true.
        }
        public bool IsFull()
        {
            return rear == data.Length - 1;
        }

        //o(1)
        public void Enqueue(int val)
        {
            if (IsFull())
            {
                Console.WriteLine("Q is full");
            }
            rear++;
            data[rear] = val;
            size++;
        }

        //o(1)
        public int Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Q is empty!");
            }
            //f=-1
            front++;
            int val = data[front];
            size--;
            if (size == 0)
            {
                // reset
                front = -1;
                rear = -1;
            }
            return val;

        }

        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Q is empty!");
            }
            Console.WriteLine("Q elements:");
            //since front is initialized to -1, active elements in the q are from front+1 till rear (inclusive <=)
            //if front = 0, active elements in the q will be from front to rear
            for(int i = front+1; i<=rear; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

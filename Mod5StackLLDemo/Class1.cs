using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5StackLLDemo
{
    internal class Node
    {
        public int Data { get; set; }
        public Node next;
        public Node(int val)//constructor for creating a node with whatever value we're passing
        {
            this.Data = val;
            this.next = null;
        }
    }

    class StackLL
    {
        private Node top;
        private int size;
        public StackLL()
        {
            this.top = null;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0; //Return whether the size is equal to zero
        }
        //addfirst o(1)
        public void Push(int val)
        {
            Node newNode = new(val);
            if (IsEmpty())
            {
                this.top = newNode;
            }
            else
            {
                newNode.next = this.top;
                this.top = newNode;
            }
            size++; // Size is not keeping track of top value. It's just to track how many elements are present.
            //top here is equivalent to 'head' in linked list.


        }
        //remove first
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            int val = top.Data;
            top = top.next;
            size--;
            return val;
        }
        public int Peek ()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return top.Data;
        }

        //O(n)
        public void Display()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            Node temp = top;
            while(temp!=null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.next;
            }
        }
    }
}

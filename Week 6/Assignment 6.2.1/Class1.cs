using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6._2._1
{
    /// <summary>
    /// Represents a single unit (node) in the linked list.
    /// Each node holds a value and a reference to the next unit in line.
    /// </summary>
    internal class Node
    {
        public int Data { get; set; }
        public Node next;

        public Node(int val)
        {
            this.Data = val;
            this.next = null; // New nodes start "unconnected"
        }
    }

    /// <summary>
    /// A Last-In-First-Out (LIFO) Stack implemented using a Linked List.
    /// </summary>
    class StackLL
    {
        private Node top; // The "head" of our list; the last item added
        private int size;

        public StackLL()
        {
            this.top = null;
            this.size = 0;
        }

        /// <summary>
        /// Checks if the stack has any elements.
        /// </summary>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Adds a new value to the top of the stack.
        /// </summary>
        public void Push(int val)
        {
            Node newNode = new(val);
            if (IsEmpty())
            {
                // If the list is empty, the new node is the top
                this.top = newNode;
            }
            else
            {
                // Point the new node to the current top, then make the new node the new top
                newNode.next = this.top;
                this.top = newNode;
            }
            size++;
        }

        /// <summary>
        /// Removes and returns the value at the top of the stack.
        /// </summary>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            int val = top.Data; // Grab the value
            top = top.next;     // Move the "top" pointer to the next node in line
            size--;
            return val;
        }

        /// <summary>
        /// Returns the value at the top without removing it.
        /// </summary>
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return top.Data;
        }

        /// <summary>
        /// Iterates through the list and prints all values to the console.
        /// </summary>
        public void Display()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            Node temp = top; // Start at the top
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.next; // Move to the next link in the chain
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5QLL
{
    internal class Node
    {
        public int Data {  get; set; }
        public Node next;
        public Node (int val)
        {
            this.Data = val;
            this.next = null;
        }
    }

    class Q
    {
        Node front;//Head
        Node rear;//Tail
        int size;
        public Q()
        {
            front = null;
            rear = null;
            size = 0;
        }
        public bool IsEmpty()
        {
            return size == 0; // return size if it is equal to 0. Other wise return false.
        }
        //We don't check isFull because LL isn't full (unless user setting or you want it to be maxed)

        //Add last O(1)
        public void Enqueue(int val)
        {
            Node newNode = new Node(val);
            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode; // Connection established
                rear = newNode; // Newest item on the line IS the REAR.
            }
            size++;
        }

        //remove first O(1)
        public int Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Q IS EMPTY!");
            }
            int val = front.Data;
            front = front.next; // skipping the first
            size--;
            // If the queue is empty, size became 0 (due to size--)
            if(IsEmpty()) // required cuz otherwise rear would be still pointing to the last node.
            {
                rear = null;
            }
            return val;
        }

        //o(n) display is always gona be O(n) because its got a whlie loop
        public void Display()
        {
            Node temp = front;
            if (IsEmpty())
            {
                Console.WriteLine("Q IS EMPTY!");
                return;
            }
            while(temp!=null)
            {//standard way of traversing thru LL
                Console.WriteLine(temp.Data);
                temp = temp.next;
            }
        }

    }
}

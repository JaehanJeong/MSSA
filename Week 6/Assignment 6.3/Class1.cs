using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6._3
{
    internal class Node
    {
        public Customer Data { get; set; }
        public Node next;

        public Node(Customer val)
        {
            this.Data = val;
            this.next = null;
        }
    }
    class Q
    {
        Node front;
        Node rear;
        int size;

        public Q()
        {
            front = null;
            rear = null;
            size = 0;

        }
        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(Customer customer)
        {
            Node newNode = new(customer);
            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            size++;
        }

        public Customer Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Q IS EMPTY!");
            }
            Customer val = front.Data;
            front = front.next;
            size--;

            if(IsEmpty())
            {
                rear = null;
            }
            return val;
        }

        public void Display()
        {
            Node temp = front;
            if(IsEmpty())
            {
                Console.WriteLine("Q EMPTY!");
                return;
            }
            while(temp!=null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.next;
            }

        }


    }
    
}

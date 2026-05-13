using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6._3
{
    internal class Customer
    {
        public string Name { get; set; }
        public int PositionInQueue { get; set; }
        public string ReasonForVisit { get; set; }

        public Customer (string name, int  positionInQueue, string reasonForVisit)
        {
            Name = name;
            PositionInQueue = positionInQueue;
            ReasonForVisit = reasonForVisit;
        }

        public override string ToString()
        {//When I tried printing it was showing like directory ? sort of like trying to print string arrays.
            //So I had to ask why o-o..
            return $"Name: {Name} | Position in Queue: {PositionInQueue} | Reason for Visit: {ReasonForVisit}";
        }
    }
}

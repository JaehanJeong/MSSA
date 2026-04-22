using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2._2.Models.Hospital
{
    public class Nurses : Providers
    {
        public void checkVitals(string patientName, DateTime vitalTime)
        {
            Console.WriteLine($"{Name} checked {patientName}'s vitals at {vitalTime}");
        }
    }
}

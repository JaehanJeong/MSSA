using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2._2.Models.Hospital
{
    public class Doctors : Providers
    {
        public void PrescribeMeds(string patientName, string medication)
        {
            Console.WriteLine($"{Name} prescribed {medication} to {patientName}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Challenge2.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
        Unknown
    }

    public class Patient
    {
        public int PatientId { get; set; } // Patient's unique ID
        
        public string PatientName { get; set; } // Patient's name to put for appointments.

        public Gender PatientGender { get; set; } // Patient's gender

        //For minimum viable product... commenting complicators

        public int DateOfBirth { get; set; } // Patient's DOB maybe to help distinguish patients with same name?

        //public string MedicalHistory { get; set; }

        //public enum PatientGender { Male, Female, Other, Unknown} //took out for simplicity for now.


    }
}

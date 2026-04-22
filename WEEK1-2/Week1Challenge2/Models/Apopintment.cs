using System;
using System.Collections.Generic;
using System.Text;
//Make an appointment class 
//Properties: Time, Availability, Provider, Patient
namespace Week1Challenge2.Models
{
    public class Apopintment
    {
        public DateTime Time {  get; set; } // When is the appointment?
        public string AssignedProvider { get; set; } // Who is the provider for this appointment?
        public string AssignedPatient { get; set; } // Who is the patient for this appointment?

        //For minimum viable product
        //public int DurationMinutes { get; set; } // How long is the appointment expected to last?
        //public string Specialty { get; set; } // What is being addressed at the appointment?
        //public string Status { get; set; } // is it Scheduled | Completed | Cancelled | Empty?
        //public string PatientConcern { get; set; } // To match with appropriate provider 

    }
}

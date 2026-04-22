using System;
using System.Collections.Generic;
using System.Text;

namespace Mod3Enumdemo
{
    //Again, enums go in namespace
    enum Status
    {
        NotStarted = 1,
        OnHold,
        InProgress,
        Completed,
        Dismissed
    }

    internal class ToDo
    {
        public int TaskId { get; set; } // Auto property short cut writing form
        public string? Description { get; set; } // Questionmark says that this property is nullable (contain a null value) - mainly for string data type
        public float EstimatedHours { get; set; }
        public Status TaskStatus { get; set; }
    }
}

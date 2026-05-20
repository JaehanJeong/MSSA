using System;
using System.Collections.Generic;
using System.Text;


// Class vs Struct
// Interview Question when to use: Standalone, small in size, no inheritance
namespace Mod3Enumdemo
{
    //1. Value type - kept in stack
    //2. No inheritance
    //3. Usage - Standalone (dont want inheritance) small custom type
    internal struct Book
    {
        // properties
        // methods
        public int BookId { get; set; }
        public string? Author { get; set; }

    }

    //1. Reference type - kept in the heap
    //2. Support inheritance
    //3. Usage - Class hierarchy, big in size
    
    class BookCls
    {
        public int BookId { get; set; }
    }
}

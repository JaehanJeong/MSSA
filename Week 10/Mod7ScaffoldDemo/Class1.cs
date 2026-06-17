using System;
using System.Collections.Generic;
using System.Text;

namespace Mod7ScaffoldDemo
{
    public interface Iprint
    {
        void Print(string content);
    }

    public class WordGenerator : Iprint
    {
        public void Print(string content)
        {
            //logic to write content in a word document
        }
    }

    public class PDFGenerator : Iprint
    {
        public void Print(string content)
        {
            //pdf generator
        }
    }

}

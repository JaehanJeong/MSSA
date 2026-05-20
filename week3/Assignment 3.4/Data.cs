using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Assignment_3._4
{
    internal class Data
    {
        //static class so that theres only one list (tough to move data between forms)
        //Simple list. Only difference is BindingList so users don't have to manually refresh.
        //Needed to add Component Model to do that.
        public static BindingList<Coffee> Coffees = new BindingList<Coffee>();
    }
}

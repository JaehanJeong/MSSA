using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignment_4._1
{
    internal class Data
    {
        // Why we use both a dictionary and a list

        // We use both a Dictionary and a BindingList to separate responsibilities:
        //
        // Dictionary<string, Person> is used for search/lookup operations,
        // providing fast O(1) access by key (name), which improves efficiency
        // compared to searching through a list.
        //
        // BindingList<Person> is used as the data source for the DataGridView
        // because WinForms supports data binding with list-based collections
        // that implement change notification (IBindingList), allowing the UI
        // to automatically update when items are added or removed.
        //
        // This separation ensures efficient searching while maintaining a
        // dynamically updating user interface. o7

        public static Dictionary<string, Person> PersonDict = new Dictionary<string, Person>(StringComparer.OrdinalIgnoreCase);
        public static BindingList<Person> Persons = new BindingList<Person>();
    }
}

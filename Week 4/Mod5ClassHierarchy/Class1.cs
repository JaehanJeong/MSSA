using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod5ClassHierarchy
{
    internal abstract class Beverage // Start of hierarchy
    {   // Protected Demo (how it's diff from private)
        protected int id;
        private string name; // Only accessible within this curly braces
        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public float BaseTemp { get; set; }
        // flexibility to change the virtual method implementation
        public virtual void SetBaseTemp() // Virtual because if any derived class wants to change it, they can.
        {
            this.BaseTemp = 40;
        }
        //No logic for calculate price in base class- but you should have this function in your base classes.
        public abstract double CalculatePrice();
        public Beverage(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    class Coffee:Beverage
    {

        public Coffee(int id, string name):base(id, name)
        {
            //logic to set id
        }
        public override double CalculatePrice()
        {
            throw new NotImplementedException();
        }
        public override void SetBaseTemp()
        {
            base.SetBaseTemp(); // plus add logic
        }
        public int Id
        {
            get { return this.id; }
        }

    }
    sealed class Espresso: Coffee // End of hierarchy
    {
        public Espresso(int id, string name):base(id, name)
        {
        }
)


        // Add properties. Errors not given because coffee has already implemented for beverages
        public new void SetBaseTemp()
        {

        }
    }


}

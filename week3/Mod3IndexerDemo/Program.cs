namespace Mod3IndexerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //If i don't write accessor, how do we access all that
            BeveragesMenu mymenu = new BeveragesMenu(5);
            //mymenu.beverages[0] = "soda"; //public string[] beverages had to be made public --> NO GOOD YOU DONT WANT DATA FIELD EXPOSED!!!
            //Hence we need indexers to access private properties.
            Console.WriteLine("Create your beverages menu");
            for (int i = 0; i < mymenu.Count; i++)
            {
                // Set block gets called to assign user data at i index to array 
                mymenu[i] = Console.ReadLine(); 
                    //class variable use as a square bracket
                    // Whole point: make object of the class behave like an array
            }
            for (int i = 0; i < mymenu.Count; ++i)
            {
                //Get property is called to get this property from my menu.
                Console.WriteLine($"{mymenu[i]}");
            }


            //mymenu[0]=
            //my menu of 0. 
            // We can hard code or loop
        }
    }
}

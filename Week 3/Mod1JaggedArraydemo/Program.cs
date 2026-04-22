namespace Mod1JaggedArraydemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region TryParse
            Console.WriteLine("Enter your age");
            //var age = Convert.ToInt32(Console.ReadLine());
            // 40 or 4o
            int i = 80;
            int j = 0;
            int age;
            try // Exception Handling
            {
                //var age = int.Parse(Console.ReadLine());
                //i = 80 / j;

            input:
                // If the value (you entered number (without character)) is convertible, it'll returns true
                // And age will have the converted value.
                bool isconvertible = int.TryParse(Console.ReadLine(), out age);
                // out is like a return value
                // Can't use return statement because tryparse already returns a boolean value

                if (!isconvertible)
                {
                    Console.WriteLine("Enter numbers only");
                    goto input;
                }
                else
                {
                    Console.WriteLine($"Your entered age is {age}");
                }




            }
            catch (FormatException ex) // More specific ones are written first and generalized last.
            {
                Console.WriteLine(ex.Message);
                // logging errors
                // Catch statements are useful to understand what happened 
            }
            catch (Exception ex) // Will be able to catch all since it's the base class
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Closing code (mandatory) which has to execute regardless of exception's existence.
            }

            #endregion


            // Jagged array

            // to keep the size of horizontal row flexible, we can use jagged array.
            // array of arrays

            Console.WriteLine("Jagged array demo");
            float[][] temp_cities = new float[3][];

            // How we would do it without nested loops
            //temp_cities[0] = new float[4]; 
            //for (int i = 0; i < temp_cities[0].Length;i++)
            //{
            //    temp_cities[0][i] = float.Parse(Console.ReadLine());
            //}

            for (int i = 0; i < temp_cities.Length; i++)
            {
                Console.WriteLine($"Enter the number of readings for city {i}");
                int readings = int.Parse(Console.ReadLine());

                temp_cities[i] = new float[readings]; // allocating memory for horizontal row - how many readings for the 0 city etc.
                for(int j = 0; j < temp_cities[i].Length; j++) // Putting the values in the horizontal row.
                {
                    Console.Write($"Cities[{i}][{j}]");
                    temp_cities[i][j] = float.Parse(Console.ReadLine());
                }
            }
            //Display the data
            Console.WriteLine("Temp readings");
            for(int i = 0; i < temp_cities.Length; i++)
            {
                Console.Write($"City{i} : ");
                for (int j = 0; j < temp_cities[i].Length; j++)
                {
                    Console.Write(temp_cities[i][j] + "F\t"); // [i] city number [j] temp in the city.
                    // \t is having a tab in between.
                }
                Console.WriteLine();
            }
        }
    }
}

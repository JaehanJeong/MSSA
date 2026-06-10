using Microsoft.Data.SqlClient;

namespace LINQDemo1
{
    internal class Program
    {

        // Traditional : "Select * from Employees"
        // //SQL Connection, SQL Command
        // 1. Developers have to learn SQL or any other server language
        // 2. Applications are tightly coupled to backend and so if any change is need in the server,
        // lots of changes are required in code.
        // 3. Querries in form of string are subject to sql injection attacks
        // ORM object relational mapper : entity framework :
        // 1. Maps the tables from db into classes.
        // 2. Changes in server will need minimum changes in code
        // 3. LINQ to SQL, LINQ to collections, LINQ to arrays
        // 4. Adds a layer of security between the app and backend db server
        
        con
        public delegate bool MyDel(int n);
        public delegate int Del(int a, int b);
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Employees";
            cmd.ExecuteReader();

            //Method call
            IsEven(34);

            MyDel del = new MyDel(IsEven);
            del(46); // delegate call
            //anonymous methods
            MyDel del2 = delegate (int n)
            {
                return (n % 2 == 0);
            };
            del2(68);

            // Lambda expressions
            //taking in variable x (dont need to declare cuz it's inferred
            //from delegate needing an integer
            // => means goes to
            MyDel del3 = (x) =>
            {
                if (x % 2 == 0)
                    return true;
                else
                    return false;
            };

            Del sumdel = (n1, n2) =>
            {
                return n1 + n2;
            };

            var result = sumdel(34, 56);
            Del proddel = (a1, a2) =>
            {
                return a1 * a2;
            };
        }
    }
}

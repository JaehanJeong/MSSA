namespace Mod2Inheritancedemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Person obj=new Person("amy", "k"); Doesn't work because it's an abstract class
            // In other words, you have to INHERIT them

            Student obj = new Student("aa", "sd");
            Person obj1 = new Student("ss", "sds"); //right side = concrete class
            // left side = abstract

            // You can't do:
            //Student o = new Person();
            // Why? Person has not implemented everything. Person is abstract. Student has more properties that Person doesn't have.
        }
    }
}

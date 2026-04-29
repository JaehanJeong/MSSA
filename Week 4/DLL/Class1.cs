namespace DLL
{
    //Accessible outside of the assembly in the client code.
    public class Class1
    {
        public void test()
        {
            Democlass obj = new Democlass();
            //obj.
        }
    }
    // Not accessible outside of assembly
    class Democlass
    {

    }
}

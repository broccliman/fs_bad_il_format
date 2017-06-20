using Library1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Bar();
            x.Print(); // Runtime "Bad IL Format" exception
        }
    }
}

using System;

namespace Cargolator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkModel wm = new WorkModel();
            wm.StartWork();
            System.Console.WriteLine("Hello World!");
        }
    }
}

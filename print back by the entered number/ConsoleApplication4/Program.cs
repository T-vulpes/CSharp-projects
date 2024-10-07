using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that prints numbers from zero to the number entered from the keyboard one below the other!");
            Console.WriteLine("----------------------------------------------------------------------");
            int sayı;
            Console.Write("ENTER A NUMBER:");
            sayı = Convert.ToInt32(Console.ReadLine());
            for (int a = sayı; a>=0; a--)
                Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that finds the factorial of a number entered from the keyboard!");
            Console.WriteLine("-----------------------------------------------------------");
            int i, sayi, fakt = 1;
            Console.Write("Enter a number: ");
            sayi = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= sayi; i++)
            {
                fakt = fakt * i;
            }
            Console.Write("Result:" + fakt);
            Console.ReadKey();
        }
    }
}

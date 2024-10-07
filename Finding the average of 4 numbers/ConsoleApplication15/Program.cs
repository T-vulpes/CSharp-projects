using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that finds the average of 4 numbers entered from the keyboard!");
            Console.WriteLine("---------------------------------------------------");
            double ort = 0;
            for (double a = 1; a < 5; a++)
            {
                Console.Write((a) + ".Enter the number:");
                double sayi = Convert.ToDouble(Console.ReadLine());
                ort += sayi;
            }
            ort = ort / 4;
            Console.Write("Average of the 4 numbers you entered:" + ort);
            Console.ReadKey();
        }
    }
}

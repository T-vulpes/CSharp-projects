using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that prints numbers between two numbers entered from the keyboard one under the other!");
            Console.WriteLine("------------------------------------------------------------------------------------");
            int sayı1, sayı2;
            Console.Write("Enter the first number:");
            sayı1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number:");
            sayı2 = Convert.ToInt32(Console.ReadLine());
            if (sayı1 > sayı2)
                for (int a = sayı1; a >= sayı2; a--)
                {
                    Console.WriteLine(a);
                }
            else
                for (int b = sayı2; b >= sayı1; b--)
                {
                    Console.WriteLine(b);
                }
            Console.ReadKey();
        }
    }
}

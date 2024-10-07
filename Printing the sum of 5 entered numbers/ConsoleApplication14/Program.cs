using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program that finds the sum of 5 numbers entered from the keyboard!");
            Console.WriteLine("--------------------------------------------------------");
            int toplam=0;
            for (int a = 1; a < 6; a++)
            { 
            Console.Write((a)+".enter the number:");
            int sayi = Convert.ToInt32(Console.ReadLine());
            toplam += sayi;
            }
            Console.WriteLine("The sum of the 5 numbers you entered:" + toplam);
            Console.ReadKey();
        }
    }
}

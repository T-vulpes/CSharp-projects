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
            Console.WriteLine("Program that prints the sum of two numbers entered from the keyboard!");
            Console.WriteLine("-----------------------------------------------------------------------------");
            int sayi1, sayi2, toplam = 0;
            Console.Write("Enter the first number:");
            sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number:");
            sayi2 = Convert.ToInt32(Console.ReadLine());

            if (sayi2 > sayi1)
            {
                for (int a = sayi1; a < sayi2; a++)
                {
                    toplam = toplam + a;
                }
            }
            else
            {
                for (int a = sayi2; a < sayi1; ++a)
                {
                    toplam = toplam + a;
                }
            }
            Console.Write("The sum of the numbers remaining between the numbers you entered:" + toplam);
            Console.ReadKey();
        }
    }
}

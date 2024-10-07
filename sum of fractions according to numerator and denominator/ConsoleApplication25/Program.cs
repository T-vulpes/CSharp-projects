using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1, a2, b1, b2, a3,b3,a4,b4,c1;
            Console.Write("Enter the numerator of the first number:");
            a1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the denominator of the first number:");
            a2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the numerator of the second number:");
            b1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the denominator of the second number:");
            b2 = Convert.ToInt32(Console.ReadLine());
            if (a2 == b2)
            {
                a3 = (a1 + b1);
                Console.ForegroundColor = ConsoleColor.White;      
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                 Console.Write("The result of adding the two entered fractions=" + a3 + "/" + b2);         
            }
            else  {
              a3=a2*b2; 
              a4=a1*b2;
              b3=a2*b2;
              b4=b1*a2; 
              c1=a4+b4;
              Console.ForegroundColor = ConsoleColor.White;
              Console.BackgroundColor = ConsoleColor.Blue;
              Console.Write("The result of adding the two entered fractions=" + c1 + "/" + b3);
            }
            Console.ReadKey();
        }
    }
}

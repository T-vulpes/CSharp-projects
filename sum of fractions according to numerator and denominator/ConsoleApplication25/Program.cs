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
            Console.Write("Birinci sayının payını giriniz:");
            a1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Birinci sayının paydasını giriniz:");
            a2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("İkinci sayının payını giriniz:");
            b1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("İkinci sayının paydasını giriniz:");
            b2 = Convert.ToInt32(Console.ReadLine());
            if (a2 == b2)
            {
                a3 = (a1 + b1);
                Console.ForegroundColor = ConsoleColor.White;      
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                 Console.Write("Girilen iki kesir toplanınca sonuç=" + a3 + "/" + b2);
           
            
            }
            else
                  {
            a3=a2*b2; //paydası
           a4=a1*b2;//pay
            b3=a2*b2;
             b4=b1*a2; //pay
  c1=a4+b4;
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Girilen iki kesir toplanınca sonuç=" + c1 + "/" + b3);
             
            
            }
            Console.ReadKey();
        }
    }
}

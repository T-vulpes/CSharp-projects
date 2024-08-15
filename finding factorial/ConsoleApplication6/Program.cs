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
            Console.WriteLine("klavyeden girilen sayının faktöriyel cinsinden bulan program!");
            Console.WriteLine("-----------------------------------------------------------");
            int i, sayi, fakt = 1;
            Console.Write("Sayı giriniz: ");
            sayi = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= sayi; i++)
            {
                fakt = fakt * i;
            }
            Console.Write("Sonuç:" + fakt);
            Console.ReadKey();
        }
    }
}

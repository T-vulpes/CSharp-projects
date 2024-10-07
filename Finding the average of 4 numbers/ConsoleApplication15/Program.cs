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
            Console.WriteLine("Klavyeden girilen 4 sayının ortalamasını bulan program!");
            Console.WriteLine("---------------------------------------------------");
            double ort = 0;
            for (double a = 1; a < 5; a++)
            {
                Console.Write((a) + ".Sayıyı giriniz:");
                double sayi = Convert.ToDouble(Console.ReadLine());
                ort += sayi;
            }
            ort = ort / 4;
            Console.Write("Girdiğiniz 4 sayının ortalaması:" + ort);
            Console.ReadKey();
        }
    }
}

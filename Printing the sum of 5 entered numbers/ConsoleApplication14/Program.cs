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
            Console.WriteLine("klavyeden girilen 5 sayının toplamını bulan program!");
            Console.WriteLine("--------------------------------------------------------");
            int toplam=0;
            for (int a = 1; a < 6; a++)
            { 
            Console.Write((a)+".sayıyı giriniz:");
            int sayi = Convert.ToInt32(Console.ReadLine());
            toplam += sayi;
             
            }
            Console.WriteLine("Girdiğiniz 5 sayının toplamı:" + toplam);
            Console.ReadKey();
            
        }
    }
}

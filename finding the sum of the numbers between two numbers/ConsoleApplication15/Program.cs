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
            //klavyeden girilen 2 sayının arasından kalan sayıların toplamını yazdır
            Console.WriteLine("klavyeden girilen 2 sayının arasında ki sayıların toplamını yazdıran program!");
            Console.WriteLine("-----------------------------------------------------------------------------");
            int sayi1, sayi2, toplam = 0;
            Console.Write("Birinci sayıyı giriniz:");
            sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Birinci sayıyı giriniz:");
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


            Console.Write("Girdiğiniz sayılar arasında kalan sayıların toplamı:" + toplam);
            Console.ReadKey();




        }
    }
}

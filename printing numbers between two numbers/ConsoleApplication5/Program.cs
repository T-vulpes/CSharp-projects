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
            /*klavyeden girilen 2 sayının arasında kalan sayıları
             alt alta yazdıran program */
            Console.WriteLine("klavyeden girilen 2 sayının arasında ki sayıları alt alta yazdıran program!");
            Console.WriteLine("------------------------------------------------------------------------------------");
            int sayı1, sayı2;
            Console.Write("birinci sayıyı giriniz:");
            sayı1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("ikinci sayıyı giriniz:");
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

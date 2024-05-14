using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Klavyeden girilen sayıdan sıfıra kadar olan sayıları 
             * alt alta yazdıran program.*/
            Console.WriteLine("Klavyeden girilen sayıdan sıfıra kadar olan sayıları  alt alta yazdıran program!");
            Console.WriteLine("----------------------------------------------------------------------");
            int sayı;
            Console.Write("SAYI GİRİNİZ:");
            sayı = Convert.ToInt32(Console.ReadLine());
            for (int a = sayı; a>=0; a--)
                Console.WriteLine(a);
            Console.ReadKey();

        }
        
    }
}

using System;

namespace FascinatingYears
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter M and N years:");
            string[] input = Console.ReadLine().Split();
            int M = int.Parse(input[0]);
            int N = int.Parse(input[1]);

            int total = 0;

            for (int year = M; year <= N; year++)
            {
                if (IsFascinatingYear(year))
                {
                    int firstTwoDigits = year / 100;
                    total += firstTwoDigits;
                }
            }

            Console.WriteLine("Total: " + total);
        }

        static bool IsFascinatingYear(int year)
        {
            int ones = year % 10;
            int tens = (year / 10) % 10;
            int hundreds = (year / 100) % 10;
            int thousands = year / 1000;

            // Checking if the first two digits are equal and the third digit is different.
            return (ones == tens && hundreds == thousands && ones != hundreds);
        }
    }
}

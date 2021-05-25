using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RationalNumber> rats = new List<RationalNumber>();
            RationalNumber r;
            Console.WriteLine("Please enter rational number in one of represented formats:");
            Console.WriteLine("A/B\n" +
                              "(A/B)\n" +
                              "A div by B\n");
            Console.WriteLine("Press Enter - to stop.");
            string str = Console.ReadLine();
            while (str != "-")
            {
                if (!RationalNumber.TryParse(str, out r))
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                else
                {
                    rats.Add(r);
                }
                str = Console.ReadLine();
            }
            Console.WriteLine("Your rationals:");
            foreach (RationalNumber rr in rats)
            {
                Console.WriteLine(rr.ToString("F"));
            }
            Console.WriteLine("Sorted rationals:");
            rats.Sort();
            foreach (RationalNumber rr in rats)
            {
                Console.WriteLine(rr.ToString("D"));
            }
            RationalNumber sum = new RationalNumber(0, 1);
            foreach (RationalNumber rr in rats)
            {
                Console.WriteLine(rr.ToString("B"));
                sum += rr;
            }
            double newSum = sum;
            Console.WriteLine("The sum of you rationals is: " + sum + " in double format: " + newSum);
        }
    }
}

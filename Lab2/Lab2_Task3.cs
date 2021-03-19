using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Task3
{
    class Program
    {
        static void InputDataOne(ref int x, ref int y)
        {
            bool checkInputX = Int32.TryParse(Console.ReadLine(), out x);
            bool checkInputY = Int32.TryParse(Console.ReadLine(), out y);
            while(!checkInputX || !checkInputY)
            {
                Console.WriteLine("Invalid input, try again please.");
                checkInputX = Int32.TryParse(Console.ReadLine(), out x);
                checkInputY = Int32.TryParse(Console.ReadLine(), out y);
            }
        }

        static void InputDataTwo(ref double rad, ref int firstDeg, ref int secondDeg)
        {
            bool checkInputRad = double.TryParse(Console.ReadLine(), out rad);
            bool checkInputDeg1 = Int32.TryParse(Console.ReadLine(), out firstDeg);
            bool checkInputDeg2 = Int32.TryParse(Console.ReadLine(), out secondDeg);
            while (!checkInputRad || !checkInputDeg1 || !checkInputDeg2)
            {
                while (firstDeg + secondDeg > 180)
                {
                    Console.WriteLine("Incorrect input, please try again.");
                    checkInputDeg1 = Int32.TryParse(Console.ReadLine(), out firstDeg);
                    checkInputDeg2 = Int32.TryParse(Console.ReadLine(), out secondDeg);
                }
            }
        }

        static void CountingSides(int[] x, int[] y, double[] side)
        {
            int counter;
            counter = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    side[counter] = Math.Sqrt(Math.Pow((x[i] - x[j]), 2) + Math.Pow((y[i] - y[j]), 2));
                    counter++;
                }
            }
        }

        static bool ExistingTriangleBySides(double[] side)
        {
            if (side[0] + side[1] > side[2])
            {
                if (side[0] + side[2] > side[1])
                {
                    if (side[1] + side[2] > side[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static double CountAngel(double opposite, double b, double c)
        {
            double rad = (Math.Pow((int)b, 2) + Math.Pow((int)b, 2) - Math.Pow((int)opposite, 2)) / (2 * (int)b * (int)c);
            rad = Math.Acos(rad);
            return rad;
        }

        static int Angel(int deg1, int deg2)
        {
            return 180 - deg1 - deg2;
        }

        static int RadToDeg(double rad)
        { 
            return (int)(rad * (180 / Math.PI));  
        }

        static double DegToRad(int reg)
        {
            return reg * Math.PI / 180;
        }

        static double Sides(double radius, double rad)
        {
            return Math.Sin(rad) / 2 * radius;
        }

        static double Perimeter(double[] side)
        {
            double Per = 0.0;
            for (int i = 0; i < 3; i++)
            {
                Per += side[i];
            }
            return Per;
        }

        static double Square(double[] side)
        {
            double per = Perimeter(side) / 2;
            double squar = Math.Sqrt(per * (per - side[0]) * (per - side[1]) * (per - side[2]));
            return squar;
        }

        static double Radius(double[] side)
        {
            double angel = CountAngel(side[0], side[1], side[2]);
            double rad = side[0] / (2 * Math.Sin(angel));
            return rad;
        }

        static void FillingSide(double[] side, int firstDeg, int secondDeg, double rad)
        {
            side[0] = Sides(rad, DegToRad(firstDeg));
            side[1] = Sides(rad, DegToRad(secondDeg));
            side[2] = Sides(rad, DegToRad(Angel(firstDeg, secondDeg)));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please, choose the variant of entering information about Triangle.");
            Console.WriteLine("1 - 3 dots of Triangle.");
            Console.WriteLine("2 - 2 angels and radius of the circumscribed circle of Triangle.");
            int a;
            bool help = Int32.TryParse(Console.ReadLine(), out a);
            if (!help)
            {
                Console.WriteLine("Incorrect input, please try again");
                help = Int32.TryParse(Console.ReadLine(), out a);
            }
            switch (a)
            {
                case 1:
                {
                    int[] x = new int[3];
                    int[] y = new int[3];
                    double[] side = new double[3];
                    Console.WriteLine("Enter 3 x and y coordinates of dotes.");
                    for (int i = 0; i < 3; i++)
                    {
                        InputDataOne(ref x[i], ref y[i]);
                    }
                    CountingSides(x, y, side);
                    if (ExistingTriangleBySides(side))
                    {
                        
                        Console.WriteLine("The first angel is " + RadToDeg(CountAngel(side[0], side[1], side[2])));
                        Console.WriteLine("The second angel is " + RadToDeg(CountAngel(side[1], side[0], side[2])));
                        Console.WriteLine("The third angel is " + RadToDeg(CountAngel(side[2], side[1], side[0])));
                        Console.WriteLine("The first side is " + side[0]);
                        Console.WriteLine("The second side is " + side[1]);
                        Console.WriteLine("The third side is " + side[2]);
                        Console.WriteLine("Perimeter of triangle is " + Perimeter(side));
                        Console.WriteLine("Square of triangle is " + Square(side));
                        Console.WriteLine("Radius of the circumscribed circle of Triangle " + Radius(side));
                    }
                    break;
                }
                case 2:
                {
                    double radius = 0.0;
                    int firstDeg = 0;
                    int secondDeg = 0;
                    double[] side = new double[3];
                    InputDataTwo(ref radius, ref firstDeg, ref secondDeg);
                    FillingSide(side, firstDeg, secondDeg, radius);
                    Console.WriteLine("The first angel is " + firstDeg);
                    Console.WriteLine("The second angel is " + secondDeg);
                    Console.WriteLine("The third angel is " + Angel(firstDeg, secondDeg));
                    Console.WriteLine("The first side is " + side[0]);
                    Console.WriteLine("The second side is " + side[1]);
                    Console.WriteLine("The third side is " + side[2]);
                    Console.WriteLine("Perimeter of triangle is " + Perimeter(side));
                    Console.WriteLine("Square of triangle is " + Square(side));
                    Console.WriteLine("Radius of the circumscribed circle of Triangle " + radius);
                    break;
                }
                default: Console.WriteLine("You entered invalid number, please try again."); break;
            }
            Console.ReadKey();
        }
    }
}

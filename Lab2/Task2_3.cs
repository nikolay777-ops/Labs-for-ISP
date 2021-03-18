//Реализовать вычисление параметров треугольника (стороны, углы, периметр, пло-щадь, радиусы вписанной и описанной окружностей, …) по трем заданным пара-метрам.
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
            bool CheckInputX = Int32.TryParse(Console.ReadLine(), out x);
            bool CheckInputY = Int32.TryParse(Console.ReadLine(), out y);
            while(!CheckInputX || !CheckInputY)
            {
                Console.WriteLine("Invalid input, try again please.");
                CheckInputX = Int32.TryParse(Console.ReadLine(), out x);
                CheckInputY = Int32.TryParse(Console.ReadLine(), out y);
            }
        }
        static void InputDataTwo(ref double Rad, ref int FirstDeg, ref int SecondDeg)
        {
            bool CheckInputRad = double.TryParse(Console.ReadLine(), out Rad);
            bool CheckInputDeg1 = Int32.TryParse(Console.ReadLine(), out FirstDeg);
            bool CheckInputDeg2 = Int32.TryParse(Console.ReadLine(), out SecondDeg);
            while (!CheckInputRad || !CheckInputDeg1 || !CheckInputDeg2)
            {
                while (FirstDeg + SecondDeg > 180)
                {
                    Console.WriteLine("Incorrect input, please try again.");
                    CheckInputDeg1 = Int32.TryParse(Console.ReadLine(), out FirstDeg);
                    CheckInputDeg2 = Int32.TryParse(Console.ReadLine(), out SecondDeg);
                }
            }
        }
        static void CountingSides(int[] x, int[] y, double[] side)
        {
            int Counter;
            Counter = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    side[Counter] = Math.Sqrt(Math.Pow((x[i] - x[j]), 2) + Math.Pow((y[i] - y[j]), 2));
                    Counter++;
                }
            }
        }
        static bool ExistingTriangleBySides(double[] Side)
        {
            if (Side[0] + Side[1] > Side[2])
            {
                if (Side[0] + Side[2] > Side[1])
                {
                    if (Side[1] + Side[2] > Side[0])
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
        static double CountAngel(double Opposite, double B, double C)
        {
            double Rad = (Math.Pow((int)B, 2) + Math.Pow((int)C, 2) - Math.Pow((int)Opposite, 2)) / (2 * (int)B * (int)C);
            Rad = Math.Acos(Rad);
            return Rad;
        }
        static int Angel(int Deg1, int Deg2)
        {
            return 180 - Deg1 - Deg2;
        }
        static int RadToDeg(double Rad)
        { 
            return (int)(Rad * (180 / Math.PI));  
        }
        static double DegToRad(int Deg)
        {
            return Deg * Math.PI / 180;
        }
        static double Sides(double Radius, double Rad)
        {
            return Math.Sin(Rad) / 2 * Radius;
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
            double Per = Perimeter(side) / 2;
            double Squar = Math.Sqrt(Per * (Per - side[0]) * (Per - side[1]) * (Per - side[2]));
            return Squar;
        }
        static double Radius(double[] Side)
        {
            double Angel = CountAngel(Side[0], Side[1], Side[2]);
            double Rad = Side[0] / (2 * Math.Sin(Angel));
            return Rad;
        }
        static void FillingSide(double[] Side, int FirstDeg, int SecondDeg, double Rad)
        {
            Side[0] = Sides(Rad, DegToRad(FirstDeg));
            Side[1] = Sides(Rad, DegToRad(SecondDeg));
            Side[2] = Sides(Rad, DegToRad(Angel(FirstDeg, SecondDeg)));
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
                    double Radius = 0.0;
                    int FirstDeg = 0;
                    int SecondDeg = 0;
                    double[] Side = new double[3];
                    InputDataTwo(ref Radius, ref FirstDeg, ref SecondDeg);
                    FillingSide(Side, FirstDeg, SecondDeg, Radius);
                    Console.WriteLine("The first angel is " + FirstDeg);
                    Console.WriteLine("The second angel is " + SecondDeg);
                    Console.WriteLine("The third angel is " + Angel(FirstDeg, SecondDeg));
                    Console.WriteLine("The first side is " + Side[0]);
                    Console.WriteLine("The second side is " + Side[1]);
                    Console.WriteLine("The third side is " + Side[2]);
                    Console.WriteLine("Perimeter of triangle is " + Perimeter(Side));
                    Console.WriteLine("Square of triangle is " + Square(Side));
                    Console.WriteLine("Radius of the circumscribed circle of Triangle " + Radius);
                    break;
                }
                default: Console.WriteLine("You entered invalid number, please try again."); break;
            }
            Console.Read();
        }
    }
}

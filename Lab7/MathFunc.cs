using System;

namespace Lab7
{
    static class MathFunc
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int GCD(int a, int b)
        {
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            if (absA < absB)
            {
                Swap(ref absA, ref absB);
            }
            if (absB == 0)
            {
                return absA;
            }
            return GCD(absB, absA % absB);
        }

        public static int LCM(int a, int b)
        {
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            if (absA == absB)
            {
                return absB;
            }
            return absA * absB / GCD(absA, absB);
        } 
    }
}

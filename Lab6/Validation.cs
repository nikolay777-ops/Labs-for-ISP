using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public class Validation
    {
        public static bool CheckName(string str)
        {
            if (str == "")
            {
                Console.WriteLine("You may have a better name!");
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("You may have a better name!");
                    str.Remove(0, str.Length);
                    return false;
                }
            }
            return true;
        }

        static public byte CheckInput()
        {
            bool checkMenu = Byte.TryParse(Console.ReadLine(), out byte i);
            while (!checkMenu && (i >= 0 && i <= 4))
            {
                Console.WriteLine("Input correct number please!");
                checkMenu = Byte.TryParse(Console.ReadLine(), out i);
            }
            return i;
        }

        public static byte DefaultValidation()
        {
            bool check = Byte.TryParse(Console.ReadLine(), out byte i);
            while (!check)
            {
                Console.WriteLine("Input correct number please!");
                check = Byte.TryParse(Console.ReadLine(), out i);
            }
            return i;
        }
    }
}

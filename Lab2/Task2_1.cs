// Получить текущее время и дату в двух разных форматах и вывести на экран коли-чество нулей, единиц, …, девяток в их записи
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Task1
{
    class Program
    {
        static void Counting(string Str, int[] Arr)
        {
            for (int i = 0; i < 10; i++)
            {
                Arr[i] = 0;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < Str.Length; j++)
                {
                    if (Str[j] == i + '0')
                    {
                        Arr[i]++;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Count of digit " + i + " in type of DateTime = " + Arr[i]);
            }
        }
        static void Main(string[] args)
        {
            string Date1 = DateTime.UtcNow.ToString("hh:mm:ss");
            string Date2 = DateTime.Now.ToString("MM.dd.yyyy");
            int[] DArr = new int[10];
            Console.WriteLine("Utc time now is" + Date1);
            Counting(Date1, DArr);
            Console.WriteLine("The local date now is:" + Date2);
            Counting(Date2, DArr);
            Console.ReadKey();
        }
    }
}

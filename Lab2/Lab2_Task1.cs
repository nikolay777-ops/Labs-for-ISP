using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Task1
{
    class Program
    {
        static void Counting(string str, int[] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                arr[i] = 0;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == i + '0')
                    {
                        arr[i]++;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Count of digit " + i + " in type of DateTime = " + arr[i]);
            }
        }

        static void Main(string[] args)
        {
            string date1 = DateTime.UtcNow.ToString("hh:mm:ss");
            string date2 = DateTime.Now.ToString("dd.MM.yyyy");
            int[] dArr = new int[10];
            Console.WriteLine("Utc time now is: " + date1);
            Counting(date1, dArr);
            Console.WriteLine("The local date now is: " + date2);
            Counting(date2, dArr);
            Console.ReadKey();
        }
    }
}

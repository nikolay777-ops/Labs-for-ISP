// В заданной строке поменять порядок слов на обратный (слова разделены пробелами).
using System;
using System.Text;

namespace Lab2_Task2
{
    class Program
    {
        static void Checker(StringBuilder Str)
        {
            for (int i = 0; i < Str.Length; i++)
            {
                if ((Str[i] >= 'A' && Str[i] <= 'Z') || (Str[i] >= 'a' && Str[i] <= 'z') || Str[i] == ' ')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("You entered any symbol with the word, please try again without symbols.");
                    Environment.Exit(1);
                }
            }
        }
        static void Main(string[] args)
        {
            const int BufSize = 1000;
            StringBuilder Str = new StringBuilder(Console.ReadLine());
            if (Str.Length == 0)
            {
                Console.WriteLine("You nothing wrote in a string, please try again.");
            }
            Checker(Str);
            Str.Insert(Str.Length, ' ');
            StringBuilder Word = new StringBuilder("");
            StringBuilder[] Buffer = new StringBuilder[BufSize];
            int BufCounter = 0;
            int CounterInsert = 0;
            for (int i = 0; i < BufSize; i++)
            {
                Buffer[i] = new StringBuilder();
            }
            for (int i = 0; i < Str.Length + 1; i++)
            {
                if ((Str[i] >= 'A' && Str[i] <= 'Z') || (Str[i] >= 'a' && Str[i] <= 'z'))
                {
                    Word.Insert(CounterInsert, Str[i]);
                    CounterInsert++;
                }
                if (Str[i] == ' ')
                {
                    Buffer[BufCounter].Insert(0, Word);
                    BufCounter++;
                    Word.Remove(0, Word.Length);
                    CounterInsert = 0;
                    if (i == Str.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        if (Str[i + 1] == ' ')
                        {
                            while (Str[i + 1] == ' ')
                            {
                                i++;
                            }
                        }
                    }
                }
            }
            Str.Remove(0, Str.Length);
            CounterInsert = 0;
            for (int i = BufCounter - 1; i >= 0; i--)
            {
                Str.Insert(CounterInsert, Buffer[i]);
                Str.Insert(Str.Length, ' ');
                CounterInsert = Str.Length;
            }
            Console.WriteLine(Str);
            Console.ReadLine();
        }
    }
}

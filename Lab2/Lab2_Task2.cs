// В заданной строке поменять порядок слов на обратный (слова разделены пробелами).
using System;
using System.Text;

namespace Lab2_Task2
{
    class Program
    {
        static void Checker(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z') || str[i] == ' ')
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
            const int bufSize = 1000;
            StringBuilder str = new StringBuilder(Console.ReadLine());
            if (str.Length == 0)
            {
                Console.WriteLine("You nothing wrote in a string, please try again.");
            }
            Checker(str);
            str.Insert(str.Length, ' ');
            StringBuilder word = new StringBuilder("");
            StringBuilder[] buffer = new StringBuilder[bufSize];
            int bufCounter = 0;
            int counterInsert = 0;
            for (int i = 0; i < bufSize; i++)
            {
                buffer[i] = new StringBuilder();
            }
            for (int i = 0; i < str.Length + 1; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    word.Insert(counterInsert, str[i]);
                    counterInsert++;
                }
                if (str[i] == ' ')
                {
                    buffer[bufCounter].Insert(0, word);
                    bufCounter++;
                    word.Remove(0, word.Length);
                    counterInsert = 0;
                    if (i == str.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        if (str[i + 1] == ' ')
                        {
                            while (str[i + 1] == ' ')
                            {
                                i++;
                            }
                        }
                    }
                }
            }
            str.Remove(0, str.Length);
            counterInsert = 0;
            for (int i = bufCounter - 1; i >= 0; i--)
            {
                str.Insert(counterInsert, buffer[i]);
                str.Insert(str.Length, ' ');
                counterInsert = str.Length;
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}

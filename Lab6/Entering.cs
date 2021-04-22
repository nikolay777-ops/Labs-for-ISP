using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public static class Entering
    {
        public static List<Student> Enter(out byte temp)
        {
            Console.WriteLine("Hello, unfortunately you ended up in the wrong place and consciousness.");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            List<Student> students = new List<Student>() { new BusinessStudent(name, 10000, 50), new SportStudent(name, "Football"), new ItStudent(name, "C#") };
            Console.WriteLine("What type of student are you? (1.Business 2.Sport 3.IT)");
            temp = Validation.DefaultValidation();
            students[temp - 1].Info(name);
            Console.WriteLine("Do you want to add some money for good start :D? Yes(1)/No(0)");
            if (Validation.CheckInput() == 1)
            {
                bool checkMoney = Int32.TryParse(Console.ReadLine(), out int cheat);
                while (!checkMoney)
                {
                    Console.WriteLine("Wrong input, please try again.");
                    checkMoney = Int32.TryParse(Console.ReadLine(), out cheat);
                }
                students[temp - 1].Money = cheat;
            }
            return students;
        }
        public static void Act(Student stud)
        {
            stud.CheckDays();
            stud.IsAlive();
            stud.Info();
            byte i = stud.HeadMenu();
            stud.Menu(i);
            switch (i)
            {
                case (byte)Actions.HP: stud.FillingHP(Validation.CheckInput()); break;
                case (byte)Actions.Happiness: stud.AddHappiness(Validation.CheckInput()); break;
                case (byte)Actions.Fullness: stud.FillingFulness(Validation.CheckInput()); break;
                case (byte)Actions.Money:
                    {
                        switch (Validation.CheckInput())
                        {
                            case 1: stud.MoneyMake(Validation.CheckInput()); break;
                            case 2: stud.MoneyMake(); break;
                            case 3: stud.BottlesToMoney(); break;
                            default: Console.WriteLine("At that period of time you can't make money by anoter way.."); break;
                        }
                    }
                    break;
                case (byte)Actions.Bottles:
                    {
                        stud.FindingBottles(Validation.CheckInput());
                    }
                    break;
                case (byte)Actions.Casino:
                    {
                        if (stud.CheckClothes())
                        {
                            Console.WriteLine("Please choose the game and input the sum of bet.");
                            stud.Casino(Validation.CheckInput());
                        }
                    }
                    break;
                case (byte)Actions.Clothes:
                    {
                        switch (Validation.CheckInput())
                        {
                            case 1:
                                {
                                    Console.WriteLine("Buying clothes:" +
                                    "\n1.Shirt(100 mon.)" +
                                    "\n2.Fashionable pents(150 mon.)" +
                                    "\n3.New boots(200 mon.)" +
                                    "\n4.Buy it all (500 mon.)" +
                                    "\n0.Exit");
                                }
                                stud.ShoppingClothes(Validation.CheckInput());
                                break;
                            case 2:
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.WriteLine(stud[j] + "\n");
                                    }
                                }
                                break;
                            default: Console.WriteLine("Wrong input."); break;
                        }
                    }
                    break;
                case (byte)Actions.Education: stud.Studying(); break;
                case (byte)Actions.NightClub:
                    {
                        if (stud is BusinessStudent) stud.NightClub();
                        else if (stud is ItStudent) stud.ComputerShopping();
                        else if (stud is SportStudent) stud.Tournament(Validation.CheckInput());
                    }
                    break;
            }
        }
    }
}

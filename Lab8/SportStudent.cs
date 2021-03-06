﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    sealed public class SportStudent : Student, ICompare<SportStudent, Student>
    {
        private string typeOfSection;
        private int popularity;
        private int strength;

        public SportStudent(string nm)
        : base(nm)
        {
            typeOfSection = "Football";
        }

        public SportStudent(string nm, int money, byte edLevel)
        : base(nm)
        {
            typeOfSection = "Basketball";
            popularity = 0;
        }

        public SportStudent(string name, string section)
            : base(name)
        {
            typeOfSection = section;
            popularity = 0;
        }

        public string TypeOfSection
        {
            get
            {
                return typeOfSection;
            }
        }

        public int SmartCompare(SportStudent first, Student second)
        {
            if (first.EducationLevel > second.EducationLevel)
            {
                Console.WriteLine("You have broken stereotype about stupid Sportsman!");
                return 1;
            }
            if (first.EducationLevel < second.EducationLevel)
            {
                Console.WriteLine("Maybe you should take more educational lessons?");
                return -1;
            }
            if (first.EducationLevel == second.EducationLevel)
            {
                Console.WriteLine("You a equal, but libra can change.");
            }
            return 2;
        }

        public int MoneyCompare(SportStudent first, Student second)
        {
            if (first.Money > second.Money)
            {
                Console.WriteLine("Ooo, Forbes interests about you!!!");
                return 1;
            }
            if (first.Money < second.Money)
            {
                Console.WriteLine("The way of success is very hard, try to be better.");
                return -1;
            }
            if (first.Money == second.Money)
            {
                Console.WriteLine("Money money money, you are equal.");
                return 0;
            }
            return 2;
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Popularity: {popularity}");
            Console.WriteLine($"Strength: {strength}");
        }

        public override void HeadMenu()
        {
            base.HeadMenu();
            Console.WriteLine("Competition(9):");
        }

        public override void CompetitionMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad9)
            {
                Console.WriteLine("1.Amateur\n" +
                                  "2.Professional\n" +
                                  "3.Olympiad\n" +
                                  "4.Prepearing");
                ConsoleKeyInfo temp = Console.ReadKey();
                switch (temp.Key)
                {
                    case ConsoleKey.NumPad1: Tournament(1);break;
                    case ConsoleKey.NumPad2: Tournament(2);break;
                    case ConsoleKey.NumPad3: Tournament(3);break;
                    case ConsoleKey.NumPad4: Tournament(4);break;
                    default: Console.WriteLine("You entered wrong key"); break;
                }
            } 
        }

        public void Sport(byte quality)
        {
            strength += quality * 5;
            HP -= (sbyte)(5 * quality);
            fullness -= (sbyte)(10 * quality);
            happiness -= (sbyte)(5 * quality);
            days += (sbyte)(2 * quality);
        }

        public void Tournament(byte i)
        {
            try
            {
                if (i <= 0 || i > 4)
                {
                    throw new IndexOutOfRangeException("You should input number from 1 to 4");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("You have chosen prearing!)");
                i = 4;
            }
           
            Random rnd = new Random();
            switch (i)
            {
                case (byte)Competition.Amateur:
                    {
                        int comp = rnd.Next(0, 50);
                        if (comp >= 25 && strength > 25)
                        {
                            Console.WriteLine("Congratulations! You have won Amateur tournament in " + this.TypeOfSection);
                            strength = 0;
                            popularity += 50;
                        }
                        else Console.WriteLine("Don't worry, you can be better the next time!");
                    }
                    break;
                case (byte)Competition.Professional:
                    {
                        int comp = rnd.Next(0, 50);
                        if (comp >= 42 && strength > 100)
                        {
                            Console.WriteLine("Congratulations! You have won Professional tournament in " + this.TypeOfSection);
                            strength = 0;
                            popularity += 100;
                        }
                        else Console.WriteLine("Maybe you aren't too strong for that competition...");
                    }
                    break;
                case (byte)Competition.Olympiad:
                    {
                        int comp = rnd.Next(0, 50);
                        if (comp >= 49 && strength > 250)
                        {
                            Console.WriteLine("Congratulations! You have won Professional tournament in " + this.TypeOfSection);
                            strength = 0;
                            popularity += 1500;
                        }
                    }
                    break;
                case (byte)Competition.Prepearing: Sport(Validation.DefaultValidation()); break;
            }
        }
    }
}

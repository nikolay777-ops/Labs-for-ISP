﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    sealed class SportStudent : Student
    {
        private string typeOfSection;
        private int popularity;
        private int strength;

        public SportStudent(string nm)
        : base(nm)
        {
            name = nm;
            typeOfSection = "Basketball";
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

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Popularity: {popularity}");
            Console.WriteLine($"Strength: {strength}");
        }

        public override byte HeadMenu()
        {
            base.HeadMenu();
            Console.WriteLine("Competition(9):");
            return Validation.DefaultValidation();
        }

        public override void Menu(byte i)
        {
            base.Menu(i);
            switch (i)
            {
                case 9:
                    Console.WriteLine("1.Amateur\n" +
                                      "2.Professional\n" +
                                      "3.Olympiad\n" +
                                      "4.Prepearing"); break;
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

        public override void Tournament(byte i)
        {
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

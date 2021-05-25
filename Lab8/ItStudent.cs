using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{ 
    sealed class ItStudent : Student, ICompare<ItStudent, Student>
    {
        private string progLanguage;
        private double computerStrength;
        private int microProcessor;
        private int videoCard;
        private int RAM;
        private int HDD;
        private delegate string ShowSt(int mic, int vid, int RAM, int HDD);

        public ItStudent(string name)
        : base(name)
        {
            progLanguage = "Multilanguage";
        }

        public ItStudent(string name, int money, byte edLevel)
            :base(name)
        {
            progLanguage = "Multilanguage";
            Money = money;
            EducationLevel = edLevel;
        }

        public ItStudent(string name, string lang)
            : base(name)
        {
            progLanguage = lang;
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Programming Language: {progLanguage}");
            Console.WriteLine($"Computer Strength: {computerStrength}");
        }

        public override void HeadMenu()
        {
            base.HeadMenu();
            Console.WriteLine("Computer Upgrade(9):");
        }

        public override void HPMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad1)
            {
                Console.WriteLine("HP: " +
                "\n1.Finding pills in trash. (free)" +
                "\n2.Go to the healer (low-quality) (30 mon.)." +
                "\n3.Go to the healer (middle-quality) (60 mon.)." +
                "\n0.Exit");
                FillingHP(Console.ReadKey());
            }
        }

        public override void HappinessMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Happiness: " +
                        "\n1.Go for a walk with girl.(25 mon.))" +
                        "\n2.Go to the cinema (35 mon.)" +
                        "\n3.Feeding pigeons (15 mon.)" +
                        "\n4.Sleeping (free)" +
                        "\n0.Exit");
                AddHappiness(Console.ReadKey());
            }
        }

        public override void FullnessMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad3)
            {
                Console.WriteLine("Fullness:" +
                        "\n1.Finding leftovers in trash (free)." +
                        "\n2.Eat shaurma (35 mon.)" +
                        "\n3.Eat in the cafe (60 mon.)." +
                        "\n0.Exit");
                FillingFulness(Console.ReadKey());
            }
        }

        public override void MoneyMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad4)
            {
                Console.WriteLine("Earning money:" +
                        "\n1.Freelance" +
                        "\n2.Blood donation." +
                        "\n3.Bottels To Money" +
                        "\n0.Exit");
                ConsoleKeyInfo temp = Console.ReadKey();
                switch (temp.Key)
                {
                    case ConsoleKey.NumPad1: MoneyMake(); break;
                    case ConsoleKey.NumPad2: BloodToMoney(); break;
                    case ConsoleKey.NumPad3: BottlesToMoney(); break;
                    case ConsoleKey.NumPad0: break;
                    default: Console.WriteLine("You entered a wrong key."); break;
                }
            }
        }

        public override void BottlesMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad5)
            {
                Console.WriteLine("Finding bottles:" +
                       "\n1.Next to the university." +
                       "\n2.On the Yakub Kolasa." +
                       "\n3.City dump" +
                       "\n0.Exit");
                FindingBottles(Console.ReadKey());
            }
        }

        public int SmartCompare(ItStudent first, Student second)
        {
            if (first.EducationLevel > second.EducationLevel)
            {
                Console.WriteLine("Hmm, programmers are real smart people exactly!");
                return 1;
            }
            if (first.EducationLevel < second.EducationLevel)
            {
                Console.WriteLine("Maybe you are tired after programming?");
                return -1;
            }
            if (first.EducationLevel == second.EducationLevel)
            {
                Console.WriteLine("You a equal, but libra can change.");
            }
            return 2;
        }

        public int MoneyCompare(ItStudent first, Student second)
        {
            if (first.Money > second.Money)
            {
                Console.WriteLine("Ooo, programmer == money!!!");
                return 1;
            }
            if (first.Money < second.Money)
            {
                Console.WriteLine("Money isn't real task for you.");
                return -1;
            }
            if (first.Money == second.Money)
            {
                Console.WriteLine("Money money money, you are equal.");
                return 0;
            }
            return 2;
        }

        public override void CheckDays()
        {
            Random rnd = new Random();
            if (days == 30)
            {
                days = 0;
                month++;
            }
            if (month == 12)
            {
                month = 0;
                days = 0;
                countOfScholarship = 0;
                this.age++;
                int temp;
                Console.WriteLine("Congratulations! At now you became older on 1 year and have a small gift!");
                temp = rnd.Next(150, 180);
                Console.WriteLine("Money + " + temp);
                this.money += temp;
                this.happiness = 100;
                this.HP = 100;
                this.fullness = 100;
                temp = rnd.Next(20, 40);
                this.bottles += temp;
                Console.WriteLine("Bottles + " + temp);
            }
        }
        // Freelance
        public override void MoneyMake()
        {
            
            this.money += (int)(10*computerStrength);
            this.HP -= 15;
            this.fullness -= 15;
            this.happiness -= 20;
            days += 5;
            educationalLevel += 1;
            if (countOfScholarship < month)
            {
                countOfScholarship++;
                money += 120 * (educationalLevel / 20);
                Console.WriteLine("You may have a scholarship for education!");
            }
            Console.WriteLine("Maybe mendicancy isn't bad thing....");
        }

        public override void ComputerShopping(ConsoleKeyInfo key)
        { 
            if (key.Key == ConsoleKey.NumPad9)
            {
                Console.WriteLine("1.MicroProcessor(150 mon.)\n" +
                              "2.VideoCard(200mon.)\n" +
                              "3.RAM(120mon.)\n" +
                              "4.HDD(100mon.)\n"+
                              "5.Show stats.");
                byte i = Validation.DefaultValidation();
                switch (i)
                {
                    case (byte)Accessories.Microprocessor:
                        {
                            Console.WriteLine("How much strength do you want to add?");
                            int temp = Validation.DefaultValidation();
                            microProcessor += temp;
                            money -= temp * 150;
                        }
                        break;
                    case (byte)Accessories.Videocard:
                        {
                            Console.WriteLine("How much strength do you want to add?");
                            int temp = Validation.DefaultValidation();
                            videoCard += temp;
                            money -= temp * 200;
                        }
                        break;
                    case (byte)Accessories.RAM:
                        {
                            Console.WriteLine("How much strength do you want to add?");
                            int temp = Validation.DefaultValidation();
                            RAM += temp;
                            money -= 120 * temp;
                        }
                        break;
                    case (byte)Accessories.HDD:
                        {
                            Console.WriteLine("How much strength do you want to add?");
                            int temp = Validation.DefaultValidation();
                            HDD += temp;
                            money -= 100 * temp;
                        }
                        break;
                    case (byte)Accessories.Show: ShowStats();break;
                    default: Console.WriteLine("You wrote wrong symbol"); break;
                }
            }
            computerStrength += ((microProcessor + videoCard + RAM + HDD) * 0.4); 
        }

        public void ShowStats()
        {
            ShowSt show = (x, y, z, t) => "Microprosecoor: " + x + "Videocard: " + y + "RAM: " + z + "HDD: " + t;
            Console.WriteLine(show(microProcessor, videoCard, RAM, HDD));
        }
    }
}

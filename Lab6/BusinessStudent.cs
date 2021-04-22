using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    sealed class BusinessStudent : Student, ICompare<BusinessStudent, Student>
    {
        private string kindOfBussiness;
        int employeesCount;
        int spaceCount;
        int cashOfBusiness;

        public BusinessStudent(string name)
        :base(name)
        {
            kindOfBussiness = "Night Club";
            employeesCount = 0;
            spaceCount = 0;
            Money = 0;
            EducationLevel = 0;
        }

        public BusinessStudent(string name, int money, byte edLevel)
        : base(name)
        {
            kindOfBussiness = "Night Club";
            employeesCount = 0;
            spaceCount = 0;
            Money = money;
            EducationLevel = edLevel;
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Businesses: {kindOfBussiness}");
        }

        public override byte HeadMenu()
        {
            base.HeadMenu();
            Console.WriteLine("Business(9):");
            return Validation.DefaultValidation();
        }

        public override void Menu(byte i)
        {
            base.Menu(i);
            switch (i)
            {
                case 9: Console.WriteLine("1.Night club"); break;
            }
        }

        public int SmartCompare(BusinessStudent first, Student second)
        {
            if (first.EducationLevel > second.EducationLevel)
            {
                Console.WriteLine("Business is a thing for smart people!");
                return 1;
            }
            if (first.EducationLevel < second.EducationLevel)
            {
                Console.WriteLine("Maybe you should visit some lessons?");
                return -1;
            }
            if (first.EducationLevel == second.EducationLevel)
            {
                Console.WriteLine("You a equal, but libra can change.");
            }
            return 2;
        }

        public int MoneyCompare(BusinessStudent first, Student second)
        {
            if (first.Money > second.Money)
            {
                Console.WriteLine("What you want to expect for businesman!!!");
                return 1;
            }
            if (first.Money < second.Money)
            {
                Console.WriteLine("The way of success is very hard, try to be better.");
                return -1;
            }
            if (first.Money == second.Money)
            {
                Console.WriteLine("You business can works better.");
                return 0;
            }
            return 2;
        }

        public override void NightClub()
        {
            Console.WriteLine("1.Employees (150 mon.)" +
                              "2.Space (250 mon.)" +
                              "3.Withdraw Cash" +
                              "0.Exit");
            switch (Validation.DefaultValidation())
            {
                case 1:
                    {
                        Console.WriteLine("Employees: " + employeesCount);
                        Console.WriteLine("How many employees do you want to buy? ");
                        byte temp = Validation.DefaultValidation();
                        if ((employeesCount + temp) > spaceCount * 2)
                        {
                            Console.WriteLine("You should buy more space for employees!");
                        }
                        else
                        {
                            money -= temp * 150;
                            employeesCount += temp;
                        }
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Space: " + spaceCount);
                        Console.WriteLine("How many space do you want to buy? ");
                        byte temp = Validation.DefaultValidation();
                        if ((money - temp * 250) < -100)
                        {
                            Console.WriteLine("You can't buy such amount of space because you lose this game!");
                        }
                        else
                        {
                            money -= temp * 150;
                            spaceCount += temp;
                        }
                    }
                    break;
                case 3:
                    {
                        money += cashOfBusiness;
                        cashOfBusiness = 0;
                    }
                    break;
                case 0: break;
                default: Console.WriteLine("Enter digit in the border of menu."); break;
            }
        }
        public override void CheckDays()
        {
            base.CheckDays();
            cashOfBusiness += spaceCount * employeesCount / 4;
        }
    }
}

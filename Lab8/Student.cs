using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    public class Student : IEducation, ICasino, IDefaultActions, ICloneable, IComparable<Student>
    {
        protected string name;
        protected sbyte HP;
        protected sbyte happiness;
        protected sbyte fullness;
        protected byte age;
        protected static short days;
        protected int money;
        protected int bottles;
        protected string[] clothes;
        protected short educationalLevel;
        protected byte month;
        protected int countOfScholarship;
        delegate string ShowClt(string firstclo, string secondclo, string thirdclo);

        public sbyte Hp
        { get; set; }

        public sbyte Happy
        { get; set; }

        public sbyte Full
        { get; set; }

        public byte Age
        { get; set; }

        public short Days
        { get; set; }

        public int Bottles
        { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Clothes(int index)
        {
            return clothes[index];
        }

        public byte Month
        { get; set; }

        public int Scholarship
        { get; set; }

        public short EducationLevel
        { get; set; }

        public int Money
        {
            set
            {
                this.money = value;
            }
            get
            {
                return money;
            }
        }

        public object Clone()
        {
            Student temp = new Student(Name);
            temp.Money = money;
            temp.Hp = HP;
            temp.Happy = happiness;
            temp.Full = fullness;
            temp.Age = age;
            temp.Days = days;
            temp.Money = money;
            temp.Bottles = bottles;
            for (int i = 0; i < clothes.Length; i++)
            {
                string help = temp.Clothes(i);
                help = clothes[i];
            }
            temp.EducationLevel = educationalLevel;
            temp.Month = month;
            temp.Scholarship = countOfScholarship;
            return temp;
        }

        public int CompareTo(Student compare)
        {
            if (money > compare.money)
                return 1;
            else if (money < compare.money)
                return -1;
            return 0;
        }

        public Student()
        {
        }

        public Student(string name)
        {
            try
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if ((name[i] < 'a' && name[i] > 'z') || (name[i] < 'A' && name[i] > 'Z'))
                    {
                        throw new IndexOutOfRangeException("You should have name only consists of letters!");
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("You will be named as Student.");
                name = "Student";
            }
            clothes = new string[3];
            this.name = name;
            age = 18;
            HP = 100;
            happiness = 100;
            fullness = 100;
            clothes[0] = "Sports jacket";
            clothes[1] = "Washed jeans";
            clothes[2] = "Old boots";
            educationalLevel = default;
            countOfScholarship = default;
        }

        public virtual void Info()
        {
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Happiness: {happiness}");
            Console.WriteLine($"Fullness: {fullness}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Money: {money}");
            Console.WriteLine($"Bottles: {bottles}");
            Console.WriteLine($"Education: {educationalLevel}");
        }

        public void Info(string main)
        {
            Console.WriteLine("The rules of that world are simple: ");
            Console.WriteLine("1.Try to stay alive (follow HP, happiness, fullness, money), " +
            "\nif your HP/happiness/fullness < - 10, money < -100 --- you lose this game\n");
            Console.WriteLine("2.You can earn money by begging, or finding bottles and change that to money.\n");
            Console.WriteLine("3.Casino - if you are lucky, it can be a good way to make easy money,\n but the main thing: Casino never lose.\n");
        }

        public virtual void HeadMenu()
        {
            Console.WriteLine("HP(1): ");
            Console.WriteLine("Happiness(2): ");
            Console.WriteLine("Fullness(3): ");
            Console.WriteLine("Earning money(4):");
            Console.WriteLine("Finding bottles(5)");
            Console.WriteLine("Casino(6):");
            Console.WriteLine("Clothes(7):");
            Console.WriteLine("Education(8):");
        }

        public virtual void HPMenu(ConsoleKeyInfo key)
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

        public virtual void HappinessMenu(ConsoleKeyInfo key)
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

        public virtual void FullnessMenu(ConsoleKeyInfo key)
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

        public virtual void MoneyMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad4)
            {
                Console.WriteLine("Earning money:" +
                        "\n1.Begging." +
                        "\n2.Blood donation." +
                        "\n3.BottelsToMoney" +
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

        public virtual void BottlesMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad5)
            {
                Console.WriteLine("Finding bottles:" +
                        "\n1.In the nearest trashbox." +
                        "\n2.In the center of the city." +
                        "\n3.City dump" +
                        "\n0.Exit");
                FindingBottles(Console.ReadKey());
            }
        }

        public void CasinoMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad6)
            {
                Console.WriteLine("Casino:" +
                       "\n1.Coinflip" +
                       "\n2.Jackpot" +
                       "\n0.Exit");
                Casino(Console.ReadKey());
            }
        }

        public void ClothesMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad7)
            {
                Console.WriteLine("1.Buying clothes:" +
                         "\n2.Showing your clothes");
                ConsoleKeyInfo temp = Console.ReadKey();
                switch (temp.Key)
                {
                    case ConsoleKey.NumPad1:
                        {
                            ShoppingInfo();
                            ShoppingClothes(Console.ReadKey());
                        }break;
                    case ConsoleKey.NumPad2:
                        {
                            ShowClothes();
                        }break;
                    default:Console.WriteLine("You entered wrong key."); break;
                }
            }
        }

        public virtual void EducationMenu(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.NumPad8)
            {
                Console.WriteLine("You became smarter, but don't relax. Knowledge is limitless.");
                Studying();
            }
        }

        public void IsAlive()
        {
            if (this.HP > -10 && this.HP < 0)
            {
                Console.WriteLine("Warning! Your health is bad do something with it.");
            }
            else if (this.HP < -10)
            {
                Console.WriteLine("Your health has become worst and you dead.");
                Environment.Exit(0);
            }
            if (this.happiness > -10 && this.happiness < 0)
            {
                Console.WriteLine("Warning! Your happiness is too bad and depression will come.");
            }
            else if (this.happiness < -10)
            {
                Console.WriteLine("You has got depression and hung.");
                Environment.Exit(0);
            }
            if (this.fullness > -10 && this.fullness < 0)
            {
                Console.WriteLine("Warning! Your feels to hungry.");
            }
            else if (this.fullness < -10)
            {
                Console.WriteLine("You try to have a diet without food but accidentally dead.");
                Environment.Exit(0);
            }
            if (this.money < 0 && this.money > -100)
            {
                Console.WriteLine("Warning! You may have problems with collectors!");
            }
            else if (this.money < -100)
            {
                Console.WriteLine("Collectors have found you....");
                Console.WriteLine("You feels any hurt in the kidney area and dead from hemorrhage.");
                Environment.Exit(0);
            }
            if (this.HP > 100) this.HP = 100;
            if (this.fullness > 100) this.fullness = 100;
            if (this.happiness > 100) this.happiness = 100;
        }

        public string this[int index]
        {
            get
            {
                if (index < 3)
                {
                    return clothes[index];
                }
                return "Incorrect index";
            }
        }

        public virtual void CheckDays()
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

        public void Sleep()
        {
            Random rnd = new Random();
            if (this.HP == 100 && this.happiness == 100)
            {
                Console.WriteLine("You full of energy and health, go conquer new horizons!");
            }
            else if (this.HP == 100 && this.happiness < 100)
            {
                this.happiness += (sbyte)rnd.Next(1, 3);
                this.fullness -= (sbyte)rnd.Next(1, 3);
                days += 2;
            }
            else if (this.HP < 100 && this.happiness == 100)
            {
                this.HP += (sbyte)rnd.Next(1, 3);
                this.fullness -= (sbyte)rnd.Next(1, 3);
                days += 2;
            }
            else
            {
                this.HP += (sbyte)rnd.Next(1, 3);
                this.happiness += (sbyte)rnd.Next(1, 3);
                this.fullness -= (sbyte)rnd.Next(1, 3);
                days += 2;
            }
            if (this.HP > 100 || this.happiness > 100 || (this.HP > 100 && this.happiness > 100))
            {
                this.HP = 100;
                this.happiness = 100;
                days += 2;
            }
        }

        public virtual void FindingBottles(ConsoleKeyInfo keyInfo)
        {
            Random rnd = new Random();
            switch (keyInfo.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        this.bottles += rnd.Next(5, 8);
                        this.fullness -= (sbyte)rnd.Next(8, 13);
                        this.happiness -= (sbyte)rnd.Next(8, 13);
                        days += 4;
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        this.bottles += rnd.Next(10, 15);
                        this.fullness -= (sbyte)rnd.Next(10, 15);
                        this.happiness -= (sbyte)rnd.Next(10, 15);
                        days += 5;
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                        this.bottles += rnd.Next(20, 25);
                        this.fullness -= (sbyte)rnd.Next(15, 20);
                        this.happiness -= (sbyte)rnd.Next(15, 20);
                        days += 6;
                    }
                    break;
                case ConsoleKey.NumPad0: break;
                default: Console.WriteLine("You input wrong number."); break;
            }
            educationalLevel -= 3;
        }
        // Begging
        public virtual void MoneyMake()
        {
            this.money += 30;
            this.HP -= 10;
            this.fullness -= 10;
            this.happiness -= 10;
            days += 5;
            educationalLevel -= 3;
            if (countOfScholarship < month)
            {
                countOfScholarship++;
                money += 120 * (educationalLevel / 20);
                Console.WriteLine("You may have a scholarship for education!");
            }
            Console.WriteLine("Maybe mendicancy isn't bad thing....");
        }
        // Blood donation
        public void BloodToMoney()
        {
            this.money += 50;
            this.HP -= 40;
            this.fullness -= 30;
            this.happiness += 20;
            days += 2;
            Console.WriteLine("You made a good deal, maybe your blood save somebodies life!");
        }

        public void BottlesToMoney()
        {
            Random rnd = new Random();
            this.money += this.bottles * rnd.Next(1, 6);
            this.bottles = 0;
            Console.WriteLine("Money, money, money. You can spend it on fun!");
        }

        public void AddHappiness(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                // drinking vodka
                case ConsoleKey.NumPad1:
                    {
                        this.money -= 25;
                        this.happiness += 30;
                        this.HP -= 20;
                        days += 3;
                    }
                    break;
                // go to the cinema
                case ConsoleKey.NumPad2:
                    {
                        this.money -= 35;
                        this.happiness += 40;
                        this.fullness += 15;
                        this.HP += 5;
                        days += 3;

                    }
                    break;
                // feeding pigeons
                case ConsoleKey.NumPad3:
                    {
                        this.money -= 15;
                        this.happiness += 20;
                        this.HP += 5;
                        this.fullness -= 5;
                    }
                    break;
                case ConsoleKey.NumPad0: break;
                default: Console.WriteLine("You entered wrong number."); break;
            }
        }
        // filling health
        public virtual void FillingHP(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                // finding pills in trash
                case ConsoleKey.NumPad1:
                    {
                        this.money += 5;
                        this.happiness -= 12;
                        this.bottles += 3;
                        this.HP += 10;
                        this.fullness -= 10;
                        days += 2;
                    }
                    break;
                // go to the healer (low)
                case ConsoleKey.NumPad2:
                    {
                        this.money -= 30;
                        this.happiness -= 9;
                        this.fullness -= 8;
                        this.HP += 20;
                        days += 2;
                    }
                    break;
                // go to the healer (middle)
                case ConsoleKey.NumPad3:
                    {
                        this.money -= 60;
                        this.happiness += 20;
                        this.HP += 50;
                        this.fullness -= 11;
                    }
                    break;
                case ConsoleKey.NumPad0: break;
                default: Console.WriteLine("You entered wrong number."); break;
            }
        }

        public virtual void FillingFulness(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                // finding leftovers in trash
                case ConsoleKey.NumPad1:
                    {
                        this.money += 5;
                        this.happiness -= 8;
                        this.bottles += 3;
                        this.HP -= 10;
                        this.fullness -= 15;
                        days += 2;
                    }
                    break;
                // Eat shaurma
                case ConsoleKey.NumPad2:
                    {
                        this.money -= 35;
                        this.happiness += 9;
                        this.fullness += 30;
                        days += 2;
                    }
                    break;
                // Eat in the cafe
                case ConsoleKey.NumPad3:
                    {
                        this.money -= 60;
                        this.happiness += 20;
                        this.fullness += 40;
                    }
                    break;
                case ConsoleKey.NumPad0: break;
                default: Console.WriteLine("You entered wrong number."); break;
            }
        }

        public void Studying()
        {
            educationalLevel += 5;
            HP -= 10;
            happiness -= 20;
            fullness -= 15;
        }

        public void ShoppingInfo()
        {
            Console.WriteLine("1.Shirt(100mon.)"+
                              "2.Fasionable pants(150mon.)" +
                              "3.New Boots(200mon.)"+
                              "4.Buy all(500mon.)");
        }

        public void ShowClothes()
        {
            ShowClt show = (x, y, z) =>  x + " " + y + " " + z;
            Console.WriteLine(show(clothes[0], clothes[1], clothes[2]));
        }

        public void ShoppingClothes(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        money -= 100;
                        clothes[0] = "Shirt";
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        money -= 150;
                        clothes[1] = "Fasionable pants";
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                        money -= 200;
                        clothes[2] = "New boots";
                    }
                    break;
                case ConsoleKey.NumPad4:
                    {
                        money -= 500;
                        clothes[0] = "Shirt";
                        clothes[1] = "Fasionable pants";
                        clothes[2] = "New boots";
                    }
                    break;
                default: Console.WriteLine("You input wront number"); break;
            }
        }

        public bool CheckClothes()
        {
            if (clothes[0] == "Shirt" && clothes[1] == "Fasionable pants" && clothes[2] == "New boots")
            {
                Console.WriteLine("You have a good appearance, so you are welcome in Casino!");
                return true;
            }
            else
            {
                Console.WriteLine("Ooh, smell like teen spirit, buy new clothes and come again.");
                return false;
            }
        }

        public void Casino(ConsoleKeyInfo key)
        {
            if (!CheckClothes()) return;
            Random rnd = new Random();
            ConsoleKeyInfo temp;
            int side = -1;
            switch (key.Key)
            {
                // CoinFlip
                case ConsoleKey.NumPad1:
                    {
                        CasinoInfo(true);
                        Console.WriteLine("Please, choose the side of coin: 0 - observe, 1 - reverse");
                        temp = Console.ReadKey();
                        if (temp.Key == ConsoleKey.NumPad0)
                            side = 0;
                        else if (temp.Key == ConsoleKey.NumPad1)
                            side = 1;
                        Console.WriteLine("Please, enter an amount bet.");
                        bool checkBet = Int32.TryParse(Console.ReadLine(), out int bet);
                        while (!checkBet)
                        {
                            Console.WriteLine("Haha, you are really hope that you can beat the casino!");
                            checkBet = Int32.TryParse(Console.ReadLine(), out bet);
                        }
                        if (side == rnd.Next(0, 1))
                        {
                            Console.WriteLine("Congratulations! You won a bet in the coinflip, definetly you should play again!");
                            bet *= 2;
                            this.money += bet;
                        }
                        else
                        {
                            this.money -= bet;
                            Console.WriteLine("Nothing terrible happened, you can try to win again!");
                        }
                    }
                    break;
                // Jackpot
                case ConsoleKey.NumPad2:
                    {
                        byte type = 3;
                        CasinoInfo(false);
                        Console.WriteLine("Please, choose the type of room (Easy/1), (Middle/2), (Hard/3)");
                        temp = Console.ReadKey();
                        switch (temp.Key)
                        {
                            case ConsoleKey.NumPad1: type = 1;break;
                            case ConsoleKey.NumPad2: type = 2;break;
                            case ConsoleKey.NumPad3: type = 3;break;
                        }
                        Console.WriteLine("Please, enter an amount of bet.");
                        bool checkBet = Int32.TryParse(Console.ReadLine(), out int bet);
                        while (!checkBet)
                        {
                            Console.WriteLine("Haha, you are really hope that you can beat the casino!");
                            checkBet = Int32.TryParse(Console.ReadLine(), out bet);
                        }
                        if (!Jackpot(type, bet))
                        {
                            Money -= bet;
                            Console.WriteLine("The main thing is that we are all safe and healthy. Others unnecessary!");
                        }
                    }
                    break;
                case ConsoleKey.NumPad0: break;
                default: Console.WriteLine("You try to find any other game but isn't find anything."); break;
            }
        }
    
        public bool Jackpot(byte type, int cash)
        {
            Random rnd = new Random();
            int all = cash;
            for (int i = 0; i < 10; i++)
            {
                all += rnd.Next(120, 350) * type;
            }
            cash = (int)(((float)cash / (float)all) * 100);
            byte winNumber = (byte)rnd.Next(1, 100);
            for (int i = 1; i <= cash; i++)
            {
                if (winNumber == i)
                {
                    Console.WriteLine("You won jackpot! +" + all);
                    this.money += all;
                    return true;
                }
            }
            return false;
        }

        public void CasinoInfo(bool n)
        {
            if (n)
            {
                Console.WriteLine("Welcome to the CoinFlip! The rules are simple:");
                Console.WriteLine("1.Choose an amount of bet.");
                Console.WriteLine("2.Choose side (observe / reverse)");
                Console.WriteLine("3.Enjoy this game and fill your wallet by prize!");
            }
            else
            {
                Console.WriteLine("Welcome to Jackpot! The rules are simple:");
                Console.WriteLine("1.Choose an amount of bet.");
                Console.WriteLine("2.Choose the type of room (Easy/Middle/Hard).");
                Console.WriteLine("Enjoy this game and waiting results!");
            }
        }

        public virtual void BusinessMenu(ConsoleKeyInfo key)
        { 
        }
        public virtual void ComputerShopping(ConsoleKeyInfo key)
        { 
        }
        public virtual void CompetitionMenu(ConsoleKeyInfo key)
        { 
        }
    }
}


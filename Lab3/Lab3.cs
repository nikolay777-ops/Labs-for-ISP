using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class Human
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

        public bool CheckName(string str)
        {
            if (str == "")
            {
                Console.WriteLine("You may have a better name!");
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("You may have a better name!");
                    str.Remove(0, str.Length);
                    return false;
                }
            }
            return true;
        }

        public Human(string name)
        {
            if (CheckName(name))
            {
                clothes = new string[3];
                this.name = name;
                age = 18;
                HP = 100;
                happiness = 100;
                fullness = 100;
                clothes[0] = "Sports jacket";
                clothes[1] = "Washed jeans";
                clothes[2] = "Old boots";
            }
            else
            {
                this.name = Console.ReadLine();
                while (!CheckName(this.name))
                {
                    this.name = Console.ReadLine();
                }
            }
        }
        
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

        public void Info()
        {
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Happiness: {happiness}");
            Console.WriteLine($"Fullness: {fullness}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Money: {money}");
            Console.WriteLine($"Bottles: {bottles}");
        }

        static public void Info(string main)
        {
            Console.WriteLine("The rules of that world are simple: ");
            Console.WriteLine("1.Try to stay alive (follow HP, happiness, fullness, money), " +
            "\nif your HP/happiness/fullness < - 10, money < -100 --- you lose this game\n");
            Console.WriteLine("2.You can earn money by begging, or finding bottles and change that to money.\n");
            Console.WriteLine("3.Casino - if you are lucky, it can be a good way to make easy money,\n but the main thing: Casino never lose.\n");
        }

        static public byte Menu()
        {
            Console.WriteLine("HP(1): ");
            Console.WriteLine("Happiness(2): ");
            Console.WriteLine("Fullness(3): ");
            Console.WriteLine("Earning money(4):");
            Console.WriteLine("Finding bottles(5)");
            Console.WriteLine("Casino(6):");
            Console.WriteLine("Clothes(7):");
            bool checkMenu = Byte.TryParse(Console.ReadLine(), out byte i);
            while (!checkMenu)
            {
                Console.WriteLine("Input correct number please!");
                checkMenu = Byte.TryParse(Console.ReadLine(), out i);
            }
            switch (i)
            {
                case 1:
                {
                    Console.WriteLine("HP: " +
                    "\n1.Finding pills in trash. (free)" +
                    "\n2.Go to the healer (low-quality) (30 mon.)." +
                    "\n3.Go to the healer (middle-quality) (60 mon.)." +
                    "\n0.Exit");
                }
                break;
                case 2:
                {
                    Console.WriteLine("Happiness: "+
                    "\n1.Drinking vodka.(25 mon.))" +
                    "\n2.Go to the cinema (35 mon.)" +
                    "\n3.Feeding pigeons (15 mon.)" +
                    "\n4.Sleeping (free)" +
                    "\n0.Exit");
                }
                break;
                case 3:
                {
                    Console.WriteLine("Fullness:" +
                    "\n1.Finding leftovers in trash (free)." +
                    "\n2.Eat shaurma (35 mon.)" +
                    "\n3.Eat in the cafe (60 mon.)." +
                    "\n0.Exit");
                }
                break;
                case 4:
                {
                    Console.WriteLine("Earning money:" +
                    "\n1.Begging." +
                    "\n2.Blood donation." +
                    "\n3.BottelsToMoney" +
                    "\n0.Exit");
                }
                break;
                case 5:
                {
                    Console.WriteLine("Finding bottles:" +
                    "\n1.In the nearest trashbox." +
                    "\n2.In the center of the city." +
                    "\n3.City dump" +
                    "\n0.Exit");
                }
                break;
                case 6:
                {
                    Console.WriteLine("Casino:" +
                    "\n1.Coinflip" +
                    "\n2.Jackpot" +
                    "\n0.Exit");
                }
                break;
                case 7:
                {
                    Console.WriteLine("1.Buying clothes:" +
                    "\n2.Showing your clothes");
                }
                break;
                default: Console.WriteLine("Input digit from 1 to 6."); break;
            }
            return i;
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
            if (this.HP > 100)
            {
                this.HP = 100;
            }
            if (this.fullness > 100)
            {
                this.fullness = 100;
            }
            if (this.happiness > 100)
            {
                this.happiness = 100;
            }
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

        public void CheckDays()
        {
            Random rnd = new Random();
            if (days == 365)
            {
                days = 0;
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
                this.happiness += (sbyte)rnd.Next(1,3);
                this.fullness -= (sbyte)rnd.Next(1,3);
                days += 2; 
            }
            else if (this.HP < 100 && this.happiness == 100)
            {
                this.HP += (sbyte)rnd.Next(1,3);
                this.fullness -= (sbyte)rnd.Next(1, 3);
                days += 2;
            }
            else
            {
                this.HP += (sbyte)rnd.Next(1, 3);
                this.happiness += (sbyte)rnd.Next(1,3);
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

        public void FindingBottles(int n)
        {
            Random rnd = new Random();
            switch (n)
            {
                case 1:
                {
                    this.bottles += rnd.Next(5,8);
                    this.fullness -= (sbyte)rnd.Next(8,13);
                    this.happiness -= (sbyte)rnd.Next(8,13);
                    days += 4;
                } 
                break;
                case 2:
                {
                    this.bottles += rnd.Next(10, 15);
                    this.fullness -= (sbyte)rnd.Next(10, 15);
                    this.happiness -= (sbyte)rnd.Next(10, 15);
                    days += 5;
                }
                break;
                case 3:
                {
                    this.bottles += rnd.Next(20, 25);
                    this.fullness -= (sbyte)rnd.Next(15, 20);
                    this.happiness -= (sbyte)rnd.Next(15, 20);
                    days += 6;
                }
                break;
                case 0: break;
                default: Console.WriteLine("You input wrong number."); break;
            }
        }
        // Begging
        public void MoneyMake(byte n)
        {
            this.money += 30 * n;
            this.HP -= (sbyte)(10 * n);
            this.fullness -= (sbyte)(10 * n);
            this.happiness -= (sbyte)(10 * n);
            days += (short)(5 * n);
            Console.WriteLine("Maybe mendicancy isn't bad thing....");
        }
        // Blood donation
        public void MoneyMake()
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

        public void AddHappiness(byte n)
        {
            switch (n)
            {
                // drinking vodka
                case 1:
                { 
                    this.money -= 25;
                    this.happiness += 30;
                    this.HP -= 20;
                    days += 3;
                }
                break;
                // go to the cinema
                case 2:
                {
                    this.money -= 35;
                    this.happiness += 40;
                    this.fullness += 15;
                    this.HP += 5;
                    days += 3;

                }
                break;
                // feeding pigeons
                case 3:
                {
                    this.money -= 15;
                    this.happiness += 20;
                    this.HP += 5;
                    this.fullness -= 5;
                }
                break;
                case 0: break;
                default: Console.WriteLine("You entered wrong number."); break;   
            }
        }
        // filling health
        public void FillingHP(byte n)
        {
            switch (n)
            {
                // finding pills in trash
                case 1:
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
                case 2:
                {
                    this.money -= 30;
                    this.happiness -= 9;
                    this.fullness -= 8;
                    this.HP += 20;
                    days += 2;
                }
                break;
                // go to the healer (middle)
                case 3:
                {
                    this.money -= 60;
                    this.happiness += 20;
                    this.HP += 50;
                    this.fullness -= 11;
                }
                break;
                case 0: break;
                default: Console.WriteLine("You entered wrong number."); break;
            }
        }

        public void FillingFulness(byte n)
        {
            switch (n)
            {
                // finding leftovers in trash
                case 1:
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
                case 2:
                {
                    this.money -= 35;
                    this.happiness += 9;
                    this.fullness += 30;
                    days += 2;
                }
                break;
                // Eat in the cafe
                case 3:
                {
                    this.money -= 60;
                    this.happiness += 20;
                    this.fullness += 40;
                }
                break;
                case 0: break;
                default: Console.WriteLine("You entered wrong number."); break;
            }
        }

        public void ShoppingClothes(byte n)
        {
            switch (n)
            {
                case 1:
                {
                    money -= 100;
                    clothes[0] = "Shirt";    
                }
                break;
                case 2:
                {
                    money -= 150;
                    clothes[1] = "Fasionable pants";
                }
                break;
                case 3:
                {
                    money -= 200;
                    clothes[2] = "New boots";
                }
                break;
                case 4:
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

        public void Casino(byte n)
        {        
            Random rnd = new Random();
            switch (n)
            {
            // CoinFlip
            case 1:
            {
                CasinoInfo(true);
                Console.WriteLine("Please, enter side of your side of coin: 0 - observe, 1 - reverse");
                bool checkSide = Int32.TryParse(Console.ReadLine(), out int side);
                while (!checkSide && (side != 0 || side != 1))
                {
                    Console.WriteLine("Haha, you are really hope that you can beat the casino!");
                    checkSide = Int32.TryParse(Console.ReadLine(), out side);
                }
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
            case 2:
            {
                CasinoInfo(false);
                Console.WriteLine("Please, choose the type of room (Easy/1), (Middle/2), (Hard/3)");
                byte type = Human.CheckInput();
                Console.WriteLine("Please, enter an amount of bet.");
                bool checkBet = Int32.TryParse(Console.ReadLine(), out int bet);
                while (!checkBet)
                {
                    Console.WriteLine("Haha, you are really hope that you can beat the casino!");
                    checkBet = Int32.TryParse(Console.ReadLine(), out bet);
                }
                if (!Jackpot(type, bet))
                {
                    this.money -= bet;
                    Console.WriteLine("The main thing is that we are all safe and healthy. Others unnecessary!");
                }
            }
            break;
            case 0: break;
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

        static public byte CheckInput()
        {
            bool checkMenu = Byte.TryParse(Console.ReadLine(), out byte i);
            while (!checkMenu && (i >= 0 && i <= 4))
            {
                Console.WriteLine("Input correct number please!");
                checkMenu = Byte.TryParse(Console.ReadLine(), out i);
            }
            return i;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string main = "";
            Console.WriteLine("Hello, unfortunately you ended up in the wrong place and consciousness.");
            Console.WriteLine("What is your name?");
            Human pers = new Human(Console.ReadLine());
            Human.Info(main);
            Console.WriteLine("Do you want to add some money for good start :D? Yes(1)/No(0)");
            if (Human.CheckInput() == 1)
            {
                bool checkMoney = Int32.TryParse(Console.ReadLine(), out int cheat);
                while (!checkMoney)
                {
                    Console.WriteLine("Wrong input, please try again.");
                    checkMoney = Int32.TryParse(Console.ReadLine(), out cheat);
                }
                pers.Money = cheat;
            }
            while (true)
            {
                pers.CheckDays();
                pers.IsAlive();
                pers.Info();
                int i = Human.Menu();
                switch (i)
                {
                    case 1: pers.FillingHP(Human.CheckInput()); break;
                    case 2: pers.AddHappiness(Human.CheckInput()); break;
                    case 3: pers.FillingFulness(Human.CheckInput()); break;
                    case 4:
                    {
                        switch (Human.CheckInput())
                        {
                            case 1:
                            {
                                Console.WriteLine("Enter amount of begging: ");
                                pers.MoneyMake(Human.CheckInput());
                            } 
                            break;
                            case 2: pers.MoneyMake(); break;
                            case 3: pers.BottlesToMoney(); break;
                            default: Console.WriteLine("At that period of time you can't make money by anoter way.."); break;
                        }
                    }
                    break;
                    case 5:
                    {
                        pers.FindingBottles(Human.CheckInput());    
                    }
                    break;
                    case 6: 
                    {
                        if (pers.CheckClothes())
                        {
                            Console.WriteLine("Please choose the game and input the sum of bet.");
                            pers.Casino(Human.CheckInput());
                        }  
                    }  
                    break;
                    case 7:
                    {
                        switch (Human.CheckInput())
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
                            pers.ShoppingClothes(Human.CheckInput()); 
                            break;
                            case 2:
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    Console.WriteLine(pers[j] + "\n");
                                }
                            }
                            break;
                            default: Console.WriteLine("Wrong input."); break;
                        }
                    }
                    break;
                }
            }
        }
    }
}

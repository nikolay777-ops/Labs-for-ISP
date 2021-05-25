using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    public class Entering
    {
        public delegate void ActHandler();
        private Action<ConsoleKeyInfo> _inputHandler;
        public event Action<ConsoleKeyInfo> InputHandler
        {
            add
            {
                _inputHandler += value;
            }
            remove
            {
                _inputHandler -= value;
            }
        }

        public static void RunMenu(Action<ConsoleKeyInfo> inputHandler, ActHandler actHandler)
        {
            while (true)
            {
                actHandler?.Invoke();
                inputHandler?.Invoke(Console.ReadKey());
            }
        }

        public static void Act(Student stud)
        {
            ActHandler actHandler = stud.IsAlive;
            actHandler += stud.CheckDays;
            actHandler += stud.Info;
            actHandler += stud.HeadMenu;
            Action<ConsoleKeyInfo> inputHandler = stud.HPMenu;
            inputHandler += stud.HappinessMenu;
            inputHandler += stud.FullnessMenu;
            inputHandler += stud.MoneyMenu;
            inputHandler += stud.BottlesMenu;
            inputHandler += stud.CasinoMenu;
            inputHandler += stud.ClothesMenu;
            inputHandler += stud.EducationMenu;
            if (stud is BusinessStudent)
                inputHandler += stud.BusinessMenu;
            else if (stud is ItStudent)
                inputHandler += stud.ComputerShopping;
            else if (stud is SportStudent)
                inputHandler += stud.CompetitionMenu;
            RunMenu(inputHandler, actHandler);
        }
    }
}

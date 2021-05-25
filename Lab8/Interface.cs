using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    // My own interfaces 
    public interface IEducation
    {
       void Studying();
    }

    public interface ICasino
    {
        void Casino(ConsoleKeyInfo key);
        bool Jackpot(byte type, int cash);
        void CasinoInfo(bool n);
    }

    public interface IDefaultActions
    {   
        void IsAlive();
        void CheckDays();
        void Sleep();
        void MoneyMake();
        void BottlesToMoney();
    }

    public interface ICompare<T, T1>
    {
        int SmartCompare(T first, T1 second);
        int MoneyCompare(T first, T1 second);
    }
}

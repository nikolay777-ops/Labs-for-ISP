using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    // My own interfaces 
    public interface IEducation
    {
       void Studying();
    }

    public interface ICasino
    {
        void Casino(byte n);
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

    public interface Compare<T, T1>
    {
        int SmartCompare(T first, T1 second);
        int MoneyCompare(T first, T1 second);
    }
}

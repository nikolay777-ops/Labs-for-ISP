using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    public enum Actions : byte
    {
        Exit,
        HP,
        Happiness,
        Fullness,
        Money,
        Bottles,
        Casino,
        Clothes,
        Education,
        NightClub,
    }

    public enum Accessories : byte
    {
        Microprocessor = 1,
        Videocard,
        RAM,
        HDD
    }

    public enum Competition : byte
    {
        Amateur = 1,
        Professional,
        Olympiad,
        Prepearing
    }

    public enum Character : byte
    { 
        Business = 1,
        Sport, 
        IT
    }
}

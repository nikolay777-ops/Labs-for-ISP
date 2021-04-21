using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
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
}

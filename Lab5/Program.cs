using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class Program
    {
        static void Main(string[] args)
        {
            byte temp;
            List<Student> students = Entering.Enter(out temp);
            while (true)
            {
                Entering.Act(students[temp-1]);
            }
        }
    }
}

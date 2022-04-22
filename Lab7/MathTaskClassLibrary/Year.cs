using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Year
    {
        public int DefineDays(int year)
        {
            if (year < 0) throw new ArgumentOutOfRangeException();
            bool visokos = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            if (visokos == true) return 366;
            else return 365;
        }
    }
}

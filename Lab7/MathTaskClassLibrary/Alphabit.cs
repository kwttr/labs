using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Alphabit
    {
        public string AlphabitArea(int N)
        {
            if (N < 1 || N > 26) throw new ArgumentException();
            string sum = null;
            for (int i = 0; i < N; i++)
            {
                sum += (char)('A'+i);
            }
            return sum;
        }
    }
}

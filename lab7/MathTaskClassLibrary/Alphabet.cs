using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Alphabet
    {
        public string PrintAlphabet(int N)
        {
            if (N < 1 || N > 26) throw new ArgumentException();
            StringBuilder sum = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                
                sum.Append((char)('A'+i));
            }
            return sum.ToString();
        }
    }
}

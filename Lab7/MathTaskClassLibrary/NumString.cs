using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MathTaskClassLibrary
{
    public class NumString
    {
        public int SumNumbers(string text)
        {
            int sum = 0;
            Regex regex = new Regex(@"([0-9])+");
            Match m = regex.Match(text);
            while (m.Success)
            {
                sum += Convert.ToInt32(m.Value);
            }
            return sum;
        }
    }
}
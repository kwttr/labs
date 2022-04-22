using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace MathTaskClassLibrary
{
    public class Mail
    {
        public bool CheckMail(string text)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9]{2,})@([a-z]{2,})\.([a-z]{2,})$");
            Match match = regex.Match(text);
            return match.Success;
        }
    }
}

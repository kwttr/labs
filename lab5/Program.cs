using System.Text.RegularExpressions;
using System.Globalization;
class Program
{
    public static void FirstTask(string input)
    {
        Regex regex = new Regex(@"^((?:a)|(?:aaaaaa)|(?:a aa a))$");
        Console.WriteLine(regex.IsMatch(input));
    }
    public static void SecondTask(string input)
    {
        Regex regex = new Regex(@"^(?:[a-zA-Z0-9]{5,})$");
        Console.WriteLine(regex.IsMatch(input));
    }
    public static void ThirdTask(string input)
    {
        Regex regex = new Regex(@"^([a-zA-Z0-9]{2,})@([a-z]{2,})\.([a-z]{2,})$");
        var match = regex.Match(input);
        if (match.Success)
        {
            for (int i = 0; i < match.Groups.Count; ++i)
            {
                System.Console.WriteLine($"{i}:{match.Groups[i]}");
            }
        }
        System.Console.WriteLine(regex.IsMatch(input));
    }
    public static void FourthTask(string input)
    {
        Regex regex = new Regex(@"(?<subname>[А-Я][а-я]{2,})\s(?<name>[А-Я][а-я]{2,})(\s(?<fathname>[А-Я][а-я]{2,}))?,\s(?<years>[1-9][0-9]+)\s(лет|года),(\sг\.)?\s(?<city>[А-Я][а-я]{2,})$");
        Match m = regex.Match(input);
        if (regex.IsMatch(input))
        {
            System.Console.WriteLine(m.Groups["city"]);
            System.Console.WriteLine(m.Groups["subname"]);
            System.Console.WriteLine(m.Groups["years"]);
        }
        else
        {
            System.Console.WriteLine("Не найдено");
        }
    }
    public static void AdditionalTask1(string input)
    {
        Regex regex = new Regex(@"(?<kg>[0-9\.,]+)\s*кг\.\s*(?<productname>[А-Яа-я]+)\s*-\s*(?<price>[0-9\.,]+)");
        Match m = regex.Match(input);
        while (m.Success)
        {
            double kg = Converter(m.Groups["kg"].Value);
            double price = Converter(m.Groups["price"].Value);
            System.Console.WriteLine(m.Groups["productname"] + " - " + price / kg + " руб/кг");
            m = m.NextMatch();
        }
    }
    public static double Converter(string inp1)
    {
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
        inp1 = inp1.Replace('.', ',');
        return double.Parse(inp1, formatter);
    }
    public static void AdditionalTask2(string input)
    {
        Regex regex = new Regex(@"(https://|http://|ftp://)?(www\.)([^\.\-][a-zA-Z0-9.\-_]+){1,5}(\.[a-z]{2,4})");
        Match m = regex.Match(input);
        if (m.Success)
        {
            for (int i = 0; i < m.Groups.Count; ++i)
            {
                System.Console.WriteLine($"{i}:{m.Groups[i]}");
            }
        }
        else Console.WriteLine("Error");
    }
    public static void Main(String[] args)
    {
        string[] input = File.ReadAllLines("text.txt");
        for (int i = 0; i < input.Length; i++)
        {
            AdditionalTask2(input[i]);
        }
    }
}
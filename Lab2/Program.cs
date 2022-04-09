class Program
{
    static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        int year = Convert.ToInt32(Console.ReadLine());
        if ((year % 4 == 0)&(year%100!=0)||(year%400==0)) Console.WriteLine("Введенный год високосный");
        else Console.WriteLine("Введный год не високосный");
    }
}
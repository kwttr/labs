using System;
using System.Diagnostics;
using System.Threading;
namespace Lab2
{
    class Program
    {

        static void Main()
        {
            ResearchTeam komanda = new ResearchTeam();
            Console.WriteLine(komanda);
            Person p = new Person();
            Console.WriteLine(p);

            return;
            //komanda.ThemeName = "Theme";
            //komanda.OrganisationName = "Organisation";
            //komanda.TeamId = 1;
            //komanda.TimeFrame = (TimeFrame)1;
            //Console.WriteLine(komanda.ToString());

            //Person Name = new Person("Name", "SecondName", new DateTime(1995, 5, 2));
            //Paper paper = new Paper();
            //Paper paper2 = new Paper("ThemeName", Name, new DateTime(1999, 5, 5));
            //komanda.AddPapers(paper);
            //komanda.AddPapers(paper2);
            //Console.WriteLine(komanda.GetLastPublish());
            Console.WriteLine("Ввести число строк: ");
            int nrow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввести число столбцов: ");
            int ncolumn = Convert.ToInt32(Console.ReadLine());
            int temp1;
            int temp2;

            Paper[] papers = new Paper[nrow * ncolumn];    //одномерный

            for (int i = 0; i < nrow * ncolumn; i++)
            {
                papers[i] = new Paper();
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < nrow * ncolumn; i++)
            {
                papers[i]._PublishName = "test";
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            papers = null;

            Paper[,] papers1 = new Paper[nrow, ncolumn];    //двумерный прямоугольный

            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    papers1[i,j] = new Paper();
                }
            }

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    papers1[i, j]._PublishName = "test";
                }
            }
            sw1.Stop();
            Console.WriteLine(sw1.Elapsed);

            papers1 = null;

            Paper[][] papers2 = new Paper[ncolumn][];//двумерный ступенчатый

            for (int i = 0; i < ncolumn; i++)
            {
                papers2[i] = new Paper[nrow];
                for (int j = 0;j < nrow; j++)
                {
                    papers2[i][j]=new Paper();
                }
            }

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 0; i < ncolumn; i++)
            {
                for (int j = 0; j < nrow; j++)
                {
                    papers2[i][j]._PublishName = "test";
                }
            }
            sw2.Stop();
            Console.WriteLine(sw2.Elapsed);
        }
    }
}
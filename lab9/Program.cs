using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading;

public class Program
{
    //Это какое-то логирование, которое я не понял как делать
    //public void Configure(IApplicationBuilder app, ILogger<Program> logger)
    //{
    //    app.Run(async (context) =>
    //    {
    //        logger.LogInformation("Processing request{0}", context.Request.Path);
    //        await context.Response.WriteAsync("Hello World!");
    //    });
    //}
    //public static void Comparising(List<FileInfo> list,FileInfo f)
    //{
    //}


    //Удаление пустых папок
    public static void DeleteEmptyFolders(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach(var file in dir.GetDirectories("*.*",SearchOption.AllDirectories).Reverse()) //Нашел реверс, гениально х2
        {
            try
            {
                if (file.GetFiles().Length == 0) file.Delete();
            }
            catch (IOException)
            {
                continue;
            }
        }
    }

    //Вывод в консоль всех файлов
    public static void PrintList(List<FileInfo> list)
    {
        foreach (FileInfo s in list)
        {
            Console.WriteLine(s);
        }
    }

    //Создание листа файлов
    public static List<FileInfo> CreateListFiles(string path)
    {
        if (Directory.Exists(path))
        {
            var directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            List<FileInfo> filesList = new List<FileInfo>();
            foreach (FileInfo file in files)
            {
                filesList.Add(file);
            }
            return filesList;
        }
        return new List<FileInfo>();
    }

    //Поиск дубликатов по содержимому
    public static void SearchingDublicatesByteComparesing(List<FileInfo> list)
    {
        int file1byte;
        int file2byte;
        FileStream fs1;
        FileStream fs2;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Exists)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].Exists)
                    {
                        fs1 = new FileStream(list[i].FullName, FileMode.Open);
                        fs2 = new FileStream(list[j].FullName, FileMode.Open);
                        if (fs1.Length != fs2.Length)
                        {
                            fs1.Close();
                            fs2.Close();
                            continue;
                        }
                        bool eq = true;
                        do
                        {
                            file1byte = fs1.ReadByte();
                            file2byte = fs2.ReadByte();
                        }
                        
                        while ((eq =file1byte == file2byte) && (file1byte != -1));

                        fs1.Close();
                        fs2.Close();
                        if (!eq) continue;
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + " На основе файла: " + list[i].FullName + "\n");
                        list[j].Delete();
                        list.RemoveAt(j);
                        j--;
                    }
                }
        }
    }

    //Поиск дубликатов по имени и размеру
    public static void SearchingDublicatesNameAndSize(List<FileInfo> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Exists)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].Exists && (list[i].Name == list[j].Name) && (list[i].Length == list[j].Length))
                    {
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + " На основе файла: " + list[i].FullName + "\n");
                        list[j].Delete();
                        list.Remove(list[j]);
                        j--;
                    }
                }
        }
    }


    //Поиск дубликатов по имени и дате
    public static void SearchingDublicatesNameAndDate(List<FileInfo> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Exists)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].Exists && (list[i].Name == list[j].Name) && (list[i].LastWriteTime.Day == list[j].LastWriteTime.Day))
                    {
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + " На основе файла: " + list[i].FullName + "\n");
                        list[j].Delete();
                        list.Remove(list[j]);
                        j--;
                    }
                }
        }
    }



    //Сортировка по дням
    public static void SortingByDay(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int day = file.LastWriteTime.Day;
                string subpath = path + "/" + day;
                if (!Directory.Exists(subpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subpath);
                    dirInfo.Create();
                }
                subpath = path + "/" + day + "/";
                File.AppendAllText("log.txt", "Перемещен файл: " + file.FullName + "\n");
                file.MoveTo(subpath + file.Name, true);
            }
        }
        DeleteEmptyFolders(path);
    }

    //Сортировка по неделям
    public static void SortingByWeek(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int week = file.LastWriteTime.DayOfYear / 7 + 1;
                string subpath = path + "/" + week;
                if (!Directory.Exists(subpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subpath);
                    dirInfo.Create();
                }
                subpath = path + "/" + week + "/";
                File.AppendAllText("log.txt", "Перемещен файл: " + file.FullName + "\n");
                file.MoveTo(subpath + file.Name, true);
            }
        }
        DeleteEmptyFolders(path);
    }

    //Сортировка по месяцам
    public static void SortingByMonth(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int month = file.LastWriteTime.Month;
                string subpath = path + "/" + month;
                if (!Directory.Exists(subpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subpath);
                    dirInfo.Create();
                }
                subpath = path + "/" + month + "/";
                File.AppendAllText("log.txt", "Перемещен файл: " + file.FullName + "\n");
                file.MoveTo(subpath + file.Name);
            }
        }
        DeleteEmptyFolders(path);
    }

    public static void SortingByYear(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int Year = file.LastWriteTime.Year;
                string subpath = path + "/" + Year;
                if (!Directory.Exists(subpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subpath);
                    dirInfo.Create();
                }
                subpath = path + "/" + Year + "/";
                File.AppendAllText("log.txt", "Перемещен файл: " + file.FullName + "\n");
                file.MoveTo(subpath + file.Name);
            }
        }
        DeleteEmptyFolders(path);
    }
    /// 
    ///
    /// 
    /// 

    public static void Main(string[] args)
    {
        File.AppendAllText("log.txt", "Начало работы программы \n\n");
         string path = "C:/Users/Nikita/Desktop/test";


        //Добавление файлов в лист
        List<FileInfo> filesList = CreateListFiles(path);
        int choose;
        do
        {
            Console.WriteLine("1.Побитовый поиск\n2.Поиск по имени и размеру\n3.Поиск по имени и дате");
            Console.WriteLine("4.Сортировка по дням\n5.Сортировка по неделям\n6.Сортировка по месяцам\n7.Сортировка по годам");
            choose = Console.ReadKey(true).KeyChar-'0';
            CreateListFiles(path);
            switch (choose)
            {
                case 0: break;
                case 1: SearchingDublicatesByteComparesing(filesList);break;
                case 2: SearchingDublicatesNameAndSize(filesList); break;
                case 3: SearchingDublicatesNameAndDate(filesList); break;
                case 4: SortingByDay(filesList, path); break;
                case 5: SortingByWeek(filesList, path); break;
                case 6: SortingByMonth(filesList, path); break;
                case 7: SortingByYear(filesList, path); break;
                default:break;
            }
            //Console.WriteLine("press a");
            Console.WriteLine("-------------------------------------");
            //Console.Clear();
        } while (choose > 0);
           
    }
}
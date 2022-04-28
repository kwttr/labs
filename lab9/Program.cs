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
        return null;
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
                        do
                        {
                            file1byte = fs1.ReadByte();
                            file2byte = fs2.ReadByte();
                        }
                        while ((file1byte == file2byte) && (file1byte != -1));
                        fs1.Close();
                        fs2.Close();
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + " На основе файла: " + list[i].FullName + "\n");
                        list[j].Delete();
                        list.RemoveAt(j);
                        j--; //гениально же, ну.
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
                    if (list[j].Exists && (list[i].Name == list[j].Name) && (list[i].CreationTime.Day == list[j].CreationTime.Day))
                    {
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + " На основе файла: " + list[i].FullName + "\n");
                        list[j].Delete();
                        list.Remove(list[j]);
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
                int day = file.CreationTime.Day;
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
    }

    //Сортировка по неделям
    public static void SortingByWeek(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int week = file.CreationTime.DayOfYear / 7 + 1;
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
    }

    //Сортировка по месяцам
    public static void SortingByMonth(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int month = file.CreationTime.Month;
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
    }

    public static void SortingByYear(List<FileInfo> list, string path)
    {
        foreach (FileInfo file in list)
        {
            if (file.Exists)
            {
                int Year = file.CreationTime.Year;
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
    }
    /// 
    ///
    /// 
    /// 

    public static void Main(string[] args)
    {
        File.AppendAllText("log.txt", "Начало работы программы \n\n");
         string path = "C:/Users/Kerbix/Desktop/test";


        //Добавление файлов в лист
        List<FileInfo> filesList = CreateListFiles(path);

        //Вызов методов
        PrintList(filesList);
        SearchingDublicatesByteComparesing(filesList);
        Console.WriteLine("После поиска\n");
        PrintList(filesList);
        DeleteEmptyFolders(path);

        File.AppendAllText("log.txt", "Конец работы программы \n\n");
    }
}
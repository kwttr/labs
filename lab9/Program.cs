using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


public class Program
{
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
    public static void DeleteEmptyFolders(DirectoryInfo dir)
    {
        foreach(var file in dir.GetDirectories())
        {
            if (file.GetFiles().Length == 0) file.Delete();
        }
    }
    public static void PrintList(List<FileInfo> list)
    {
        foreach (FileInfo s in list)
        {
            Console.WriteLine(s);
        }
    }

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
                        if(fs1.Length != fs2.Length)
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
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName+"\n");
                        list[j].Delete();
                        list.Remove(list[j]);
                    }
                }
        }
    }

    public static void SearchingDublicatesNameAndSize(List<FileInfo> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i].Exists)
            for(int j = i + 1; j < list.Count; j++)
            {
                if (list[j].Exists&&((list[i].Name==list[j].Name)&&(list[i].Length==list[j].Length)))
                {
                    File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + "\n");
                    list[j].Delete();
                    list.Remove(list[j]);
                }
            }
        }
    }

    public static void SearchingDublicatesNameAndDate(List<FileInfo> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Exists)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].Exists && ((list[i].Name == list[j].Name) && (list[i].CreationTime == list[j].CreationTime)))
                    {
                        File.AppendAllText("log.txt", "Удален файл: " + list[j].FullName + "\n");
                        list[j].Delete();
                        list.Remove(list[j]);
                    }
                }
        }
    }

    public static void SortingByDay(List<FileInfo> list,string path)
    {
        foreach(FileInfo file in list)
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
                subpath = path + "/" + day+"/";
                File.AppendAllText("log.txt", "Перемещен файл: " + file.FullName + "\n");
                file.MoveTo(subpath+file.Name,true);
            }
        }
    }

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
    /// 
    /// 
    /// 
    /// 

    public static void Main(string[] args)
    {
        string path = "C:/Users/Kerbix/Desktop/чзх";
        if (Directory.Exists(path))
        {
            var directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            List<FileInfo> filesList = new List<FileInfo>();
            foreach (FileInfo file in files)
            {
                filesList.Add(file);
            }

            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                var nestedDirectory = new DirectoryInfo(dir);
                FileInfo[] nestedFiles = nestedDirectory.GetFiles();
                foreach (FileInfo f in nestedFiles)
                {
                    filesList.Add(f);
                }
            }
            SortingByWeek(filesList, path);
            DeleteEmptyFolders(directory);
        }
    }
}   
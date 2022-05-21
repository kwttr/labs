using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

public class City
{
    public double latitude;
    public double longitude;
    public string gpsLatitudeRef;
    public string gpsLongitudeRef;
    public string Name;
    public City(string latitudeRef, double latitude,string longitudeReg,double longitude,string CityName)
    {
        this.latitude = latitude;
        this.longitude = longitude;
        this.gpsLatitudeRef = latitudeRef;
        this.gpsLongitudeRef = longitudeReg;
        Name = CityName;
    }
}
public class Program
{


    //Удаление пустых папок
    public static void DeleteEmptyFolders(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (var file in dir.GetDirectories("*.*", SearchOption.AllDirectories).Reverse())
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

                        while ((eq = file1byte == file2byte) && (file1byte != -1));

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
                try
                {
                file.MoveTo(subpath + file.Name);          //Убрал значение true, что перезаписывало файл в .NET 6.0, в NETframework нет необходимости. Не буду даже проверять работает или нет.
                }
                catch (Exception)
                {
                    file.MoveTo(subpath + file.Name + "1");
                }
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
                try
                {
                    file.MoveTo(subpath + file.Name);          //Убрал значение true, что перезаписывало файл в .NET 6.0, в NETframework нет необходимости. Не буду даже проверять работает или нет.
                }
                catch (Exception)
                {
                    file.MoveTo(subpath + file.Name + "1");
                }
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
                try
                {
                    file.MoveTo(subpath + file.Name);          //Убрал значение true, что перезаписывало файл в .NET 6.0, в NETframework нет необходимости. Не буду даже проверять работает или нет.
                }
                catch (Exception)
                {
                    file.MoveTo(subpath + file.Name + "1");
                }
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
                try
                {
                    file.MoveTo(subpath + file.Name);          //Убрал значение true, что перезаписывало файл в .NET 6.0, в NETframework нет необходимости. Не буду даже проверять работает или нет.
                }
                catch (Exception)
                {
                    file.MoveTo(subpath + file.Name + "1");
                }
            }
        }
        DeleteEmptyFolders(path);
    }

    //добавление вотермарки
    public static Graphics GdiBase(FileInfo file, ref Bitmap bitmap, out int imageWidth, out int imageHeight)
    {
        using (Image image = Image.FromFile(file.FullName))
        {
            imageWidth = image.Width;
            imageHeight = image.Height;

            bitmap = new Bitmap(imageWidth, imageHeight,
                PixelFormat.Format24bppRgb);

            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawImage(image, new Rectangle(0, 0, imageWidth, imageHeight), 0, 0, imageWidth, imageHeight, GraphicsUnit.Pixel);
            return graphics;
        }
    }

    public static void SetText(List<FileInfo> files, string text,
    string pathSave, string fontName = "arial")
    {
        string pathdir = pathSave + "/watermark";
        DirectoryInfo dir = new DirectoryInfo(pathdir);
        dir.Create();
        foreach (FileInfo file in files)
        {
            if (file.Name.Contains("watermark")) continue;
            // Поолучаем объект Graphics
            Bitmap bitmap = null;
            int imageWidth = 0, imageHeight = 0;

            using (Graphics graphics = GdiBase(file, ref bitmap, out imageWidth, out imageHeight))
            {
                using (bitmap)
                {
                    // Задаем качество рендеринга для картинки
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Подбираем размер шрифта, чтобы подпись полность помещалась на картинке
                    double razn = 0;
                    int i = 0;
                    Font font = null;
                    SizeF size = new SizeF();
                    int fontSize = 2;
                    //шрифт раздвигается полностью на экран, потом делится на 3, чтобы текст влезал ровно 3 раза.
                    while (size.Width < imageWidth)
                    {
                        font = new Font(fontName, fontSize, FontStyle.Bold);
                        size = graphics.MeasureString(text, font);
                        fontSize += 1;
                        if ((ushort)size.Width > (ushort)imageWidth / 3) break;
                    }
                    font = new Font(fontName, fontSize, FontStyle.Bold);
                    size = graphics.MeasureString(text, font);
                    //text
                    text = "MisterBlok";
                    while (i < 5)
                    {

                        // Добавляем смещение 15% относительно низа экрана, потом добавляется разница.
                        int yPixelsFromBottom = (int)(imageHeight * (0.1 + razn));
                        razn += 0.2;
                        float positionY = ((imageHeight -
                                    yPixelsFromBottom) - (size.Height / 2));
                        float positionX=-size.Width/5;

                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Far;

                        // Полупрозрачная кисть белого цвета для заливки текста
                        SolidBrush brush = new SolidBrush(
                Color.FromArgb(100, 255, 255, 255));

                        // Полупрозрачная кисть черного цвета для обводки текста
                        SolidBrush brush2 = new SolidBrush(Color.FromArgb(100, 0, 0, 0));

                        int j = 0;
                        while (j < 3){
                            positionX += size.Width;

                            graphics.DrawString(text,
                                font,
                                brush2,
                                new PointF(positionX + 1, positionY + 1),
                                stringFormat);

                            graphics.DrawString(text,
                                font,
                                brush,
                                new PointF(positionX, positionY),
                                stringFormat);
                            j++;
                        }
                        i++;
                    }
                    // Сохранить картинку
                    bitmap.Save(pathdir + "/" + "watermark"+file.Name,
                        // Выбор формата для сохранения на основе MIME
                        file.Extension == "png" ? ImageFormat.Png : ImageFormat.Jpeg);
                }
            }
        }
    }

    public static void SortGeoTag(List<FileInfo> files,string path)
    {
        //Инициализация массива городов (да, именно здесь)
        City Novosibirsk = new City("N",55.01464,"E",82.93167,"Novosibirsk");
        City Moscow = new City("N", 55.77657, "E", 37.70508,"Moscow");
        City Vladivostok = new City("N", 43.17376, "E", 131.99841,"Vladivostok");

        City[] Cities = new City[3] {Novosibirsk,Moscow,Vladivostok};

        foreach (FileInfo file in files)
        {
            if (file.Extension == ".jpg" || file.Extension == ".jpeg")
            {
                Image image = new Bitmap(file.FullName);
                try
                {
                    //Берем метаданные для обработки
                    string gpsLatitudeRef = BitConverter.ToChar(image.GetPropertyItem(1).Value, 0).ToString(); //Северная или южная широта
                    double latitude = DecodeRational64u(image.GetPropertyItem(2));                             
                    string gpsLongitudeRef = BitConverter.ToChar(image.GetPropertyItem(3).Value, 0).ToString();//Клятая западная долгота или наша православная восточная долгота
                    double longitude = DecodeRational64u(image.GetPropertyItem(4));
                    //Console.WriteLine("{0}\t{1} {2}, {3} {4}", file, gpsLatitudeRef, latitude, gpsLongitudeRef, longitude);

                    //Ищем среди всего массива городов самый приближенный
                    double difference = Math.Abs(Convert.ToDouble(latitude) - Cities[0].latitude) + Math.Abs(Convert.ToDouble(longitude) - Cities[0].longitude);
                    string CityName = Cities[0].Name;

                    foreach (City city in Cities)
                    {
                        if (Math.Abs(Convert.ToDouble(latitude) - city.latitude) + Math.Abs(Convert.ToDouble(longitude) - city.longitude) < difference)
                        {
                            difference = Math.Abs(Convert.ToDouble(latitude) - city.latitude) + Math.Abs(Convert.ToDouble(longitude) - city.longitude);
                            CityName = city.Name;
                        }
                    }

                    //Перемещаем в папку города
                    image.Dispose();
                    string cityPath = path + "/" + CityName;
                    if(!Directory.Exists(cityPath)) Directory.CreateDirectory(cityPath);
                    file.MoveTo(cityPath + "/" + file.Name);
                }
                //При любой ошибке (отсутствуют метаданные или др.) кидаем в папку unknown
                catch
                {
                    image.Dispose();
                    Console.WriteLine("Фото не обрабатывается");
                    string unkpath = path + "/unknown";
                    if (!Directory.Exists(unkpath)) Directory.CreateDirectory(unkpath);
                    file.MoveTo(unkpath + "/" + file.Name);
                }
            }
            //Если файл не jpg/jpeg картинка (можно добавить и остальные форматы, которые обрабатывают метаданные, но это лишняя морока) кидает в папку unknown
            else
            {
                string unkpath = path + "/unknown";
                if (!Directory.Exists(unkpath)) Directory.CreateDirectory(unkpath);
                    file.MoveTo(unkpath+"/"+file.Name);
            }

        }
    }


    public static double DecodeRational64u(PropertyItem propertyItem)
    {
        uint dN = BitConverter.ToUInt32(propertyItem.Value, 0);      //Числитель градусов
        uint dD = BitConverter.ToUInt32(propertyItem.Value, 4);      //Знаменатель градусов
        uint mN = BitConverter.ToUInt32(propertyItem.Value, 8);      //Числитель минут
        uint mD = BitConverter.ToUInt32(propertyItem.Value, 12);     //Знаменатель минут
        uint sN = BitConverter.ToUInt32(propertyItem.Value, 16);     //Числитель секунд
        uint sD = BitConverter.ToUInt32(propertyItem.Value, 20);     //Знаменатель секунд

        decimal deg;
        decimal min;
        decimal sec;
        // Found some examples where you could get a zero denominator and no one likes to devide by zero || че пендос несет непонятно
        if (dD > 0) { deg = (decimal)dN / dD; } else { deg = dN; }
        if (mD > 0) { min = (decimal)mN / mD; } else { min = mN; }
        if (sD > 0) { sec = (decimal)sN / sD; } else { sec = sN; }
        return (double)(deg + min / 100 + sec / 10000);
    }

    //Кодирование в экзиф, но это не очень надо в принципе, но в теории... ?????? не уверен. В текущий момент не используется.
    private static byte[] FloatToExifGps(int degrees, int minutes, int seconds)
    {
        var secBytes = BitConverter.GetBytes(seconds);
        var secDivisor = BitConverter.GetBytes(100);
        byte[] rv = { (byte)degrees, 0, 0, 0, 1, 0, 0, 0, (byte)minutes, 0, 0, 0, 1, 0, 0, 0, secBytes[0], secBytes[1], 0, 0, secDivisor[0], 0, 0, 0 };
        return rv;
    }

    public static void Main(string[] args)
    {
        File.AppendAllText("log.txt", "Начало работы программы \n\n");

        Console.WriteLine("Введите путь к папке");
        string path = Console.ReadLine();

        //Добавление файлов в лист
        List<FileInfo> filesList = CreateListFiles(path);
        int choose;
        do
        {
            Console.WriteLine("1.Побитовый поиск\n2.Поиск по имени и размеру\n3.Поиск по имени и дате");
            Console.WriteLine("4.Сортировка по дням\n5.Сортировка по неделям\n6.Сортировка по месяцам\n7.Сортировка по годам\n8.Добавить вотермарку\n9.Сортировать по геотэгу");
            choose = Console.ReadKey(true).KeyChar - '0';
            CreateListFiles(path);
            switch (choose)
            {
                case 0: break;
                case 1: SearchingDublicatesByteComparesing(filesList); break;
                case 2: SearchingDublicatesNameAndSize(filesList); break;
                case 3: SearchingDublicatesNameAndDate(filesList); break;
                case 4: SortingByDay(filesList, path); break;
                case 5: SortingByWeek(filesList, path); break;
                case 6: SortingByMonth(filesList, path); break;
                case 7: SortingByYear(filesList, path); break;
                case 8: SetText(filesList, "WATERMARK", path, "arial"); break;
                case 9: SortGeoTag(filesList, path); break;
                default: break;
            }
            Console.WriteLine("-------------------------------------");
            //Console.Clear();
        } while (choose > 0);
    }
}
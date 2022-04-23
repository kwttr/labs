class Program
{
    static void Main()
    {
        int[] array = new int[] { 9,9,10,9,9,9,12 };
        int[] SourceArray = new int[array.Length];
        array.CopyTo(SourceArray, 0);

        int max = array[array.Length - 1];
        array[array.Length - 1] = 0;
        for (int i = array.Length - 2; i >= 0; i--)
        {
            if (array[i] >= max)
            {
                max = array[i];
                array[i] = 0;
            }
            else if (array[i] < SourceArray[i + 1])
            {
                array[i] = SourceArray[i + 1];
            }
            else
            {
                array[i] = max;
            }
        }
        Console.WriteLine("before:");
        foreach (var num in SourceArray)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
        Console.WriteLine("after:");
        foreach (var num in array)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
    }
}
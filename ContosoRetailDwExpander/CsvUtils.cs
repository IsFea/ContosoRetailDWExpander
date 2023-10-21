using System.Reflection;

namespace ContosoRetailDwExpander;

public static class CsvUtils
{
    public static List<string> LoadOneDimensionalCsv(string filePath)
    {
        var subjects = new List<string>();

        try
        {
            using var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null) subjects.Add(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }

        return subjects;
    }

    private static void CreateHeader<T>(List<T> list, TextWriter sw)
    {
        var properties = typeof(T).GetProperties();
        for (var i = 0; i < properties.Length - 1; i++)
        {
            sw.Write(properties[i].Name + "¿");
        }

        var lastProp = properties[^1].Name;
        sw.Write(lastProp + sw.NewLine);
    }

    private static void CreateRows<T>(List<T> list, TextWriter sw)
    {
        var properties = typeof(T).GetProperties();
        foreach (var item in list)
        {
            for (var i = 0; i < properties.Length - 1; i++)
            {
                var prop = properties[i];
                sw.Write(prop.GetValue(item) + "¿");
            }

            var lastProp = properties[^1];
            sw.Write(lastProp.GetValue(item) + sw.NewLine);
        }
    }

    public static void CreateCSV<T>(List<T> list, string filePath)
    {
        using var sw = new StreamWriter(filePath);
        CreateHeader(list, sw);
        CreateRows(list, sw);
    }
}
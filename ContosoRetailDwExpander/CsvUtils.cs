using System.Reflection;
using System.Text;
using ContosoRetailDwExpander.Model;
using Microsoft.Extensions.Primitives;

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
        var hasPreviousProperty = false;

        foreach (var prop in properties)
        {
            if (HasCsvIgnoreAttribute(prop)) continue;
            if (hasPreviousProperty)
            {
                sw.Write("¿");
            }

            sw.Write(prop.Name);
            hasPreviousProperty = true;
        }

        sw.Write(sw.NewLine);
    }

    private static void CreateRows<T>(List<T> list, TextWriter sw)
    {
        var properties = typeof(T).GetProperties();
        var sb = new StringBuilder();

        var batchSize = 1000;
        var iterator = 0;
        var listCount = list.Count();


        foreach (var item in list)
        {
            var hasPreviousProperty = false;
            for (var i = 0; i < properties.Length - 1; i++)
            {
                var prop = properties[i];
                if (HasCsvIgnoreAttribute(prop)) continue;
                if (hasPreviousProperty)
                {
                    sb.Append("¿");
                }
                sb.Append(GetValueByType(prop.GetValue(item)));
                hasPreviousProperty = true;
            }

            var lastProp = properties[^1];
            if (!HasCsvIgnoreAttribute(lastProp))
            {
                GetValueByType(lastProp.PropertyType);
                sb.Append(GetValueByType(lastProp.GetValue(item)));
            }

            sb.Append(sw.NewLine);

            iterator++;
            if ((iterator % batchSize) == 0 || listCount == iterator)
            {
                sw.Write(sb.ToString());
                sb.Clear();
            }
        }
    }

    private static string? GetValueByType(object? value)
    {
        if (value != null)
            return value switch
            {
                DateTime dateTime => dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                float floatValue => floatValue.ToString(System.Globalization.CultureInfo.InvariantCulture),
                double doubleValue => doubleValue.ToString(System.Globalization.CultureInfo.InvariantCulture),
                decimal decimalValue => decimalValue.ToString(System.Globalization.CultureInfo.InvariantCulture),
                _ => value.ToString()
            };
        return "";
    }

    private static bool HasCsvIgnoreAttribute(PropertyInfo property)
    {
        return property.GetCustomAttribute(typeof(CsvIgnoreAttribute)) != null;
    }

    public static void CreateCSV<T>(List<T> list, string filePath)
    {
        using var sw = new StreamWriter(filePath, true);
        CreateHeader(list, sw);
        CreateRows(list, sw);
    }
}
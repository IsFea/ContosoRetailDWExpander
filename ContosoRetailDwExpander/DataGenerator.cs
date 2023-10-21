using System;
using System.Text;

namespace ContosoRetailDwExpander;

public static class DataGenerator
{
    private static readonly Random _random = new Random();

    public static List<string> FindNullProperties<T>(List<T> objects, string modelName)
    {
        return typeof(T)
            .GetProperties()
            .Where(property => objects.All(obj => property.GetValue(obj) == null))
            .Select(property => property.Name).ToList();
    }

    // Метод для генерации случайного float числа в диапазоне от min до max
    public static float GenerateRandomFloat(float min, float max)
    {
        // Генерируем случайное float число в заданном диапазоне
        var randomFloat = (float)(_random.NextDouble() * (max - min) + min);

        return randomFloat;
    }

    // Метод для генерации случайного decimal числа в диапазоне от min до max
    public static decimal GenerateRandomDecimal(decimal min, decimal max)
    {
        // Генерируем случайное decimal число в заданном диапазоне
        var range = max - min;
        var randomDecimal = (decimal)(_random.NextDouble() * (double)range) + min;

        return randomDecimal;
    }

    public static string GenerateInn()
    {
        var result = new StringBuilder(10);
        for (var i = 0; i < 10; i++)
        {
            result.Append(_random.Next(0, 10));
        }

        return result.ToString();
    }

    public static string GeneratePhoneNumber(Random random)
    {
        const string areaCode = "1 (11) 500";
        var middlePart = $"{random.Next(100, 1000):000}";
        var lastPart = $"{random.Next(1000, 10000):0000}";

        return $"{areaCode} {middlePart} {lastPart}";
    }
}
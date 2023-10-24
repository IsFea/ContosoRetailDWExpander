using System.Globalization;
using System.Text.RegularExpressions;
using ContosoRetailDwExpander.Model;

namespace ContosoRetailDwExpander.Extensions;

public static class DimDateExtensions
{
    public static void ConvertLabelsToRussian(this DimDate dimDate)
    {
        var date = dimDate.Datekey;
        
        var dateTranslation = new Dictionary<string, string>
        {
            {"January", "Январь"},
            {"February", "Февраль"},
            {"March", "Март"},
            {"April", "Апрель"},
            {"May", "Май"},
            {"June", "Июнь"},
            {"July", "Июль"},
            {"August", "Август"},
            {"September", "Сентябрь"},
            {"October", "Октябрь"},
            {"November", "Ноябрь"},
            {"December", "Декабрь"},
            
            {"Monday", "Понедельник"},
            {"Tuesday", "Вторник"},
            {"Wednesday", "Среда"},
            {"Thursday", "Четверг"},
            {"Friday", "Пятница"},
            {"Saturday", "Суббота"},
            {"Sunday", "Воскресенье"},
        };
        
        var wordTranslation = new Dictionary<string, string>
        {
            {"FiscalYear", "Финансовый год"},
            {"WeekEnd", "Выходной"},
            {"WorkDay", "Рабочий день"},
            {"Year", "Год"},
            {"Week", "Неделя"},
            {"Month", "Месяц"}
        };

        // Преобразование в русские метки
        dimDate.CalendarYearLabelRu = dimDate.CalendarYearLabel.ReplaceWords(wordTranslation);
        dimDate.CalendarMonthLabelRu = dimDate.CalendarMonthLabel.ReplaceWords(dateTranslation);
        dimDate.CalendarWeekLabelRu = dimDate.CalendarWeekLabel.ReplaceWords(wordTranslation);
        dimDate.CalendarDayOfWeekLabelRu = dimDate.CalendarDayOfWeekLabel.ReplaceWords(dateTranslation);
        dimDate.IsWorkDayRu = dimDate.IsWorkDay.ReplaceWords(wordTranslation);

        dimDate.FiscalYearLabelRu = dimDate.FiscalYearLabel.ReplaceWords(wordTranslation);
        dimDate.FiscalMonthLabelRu = dimDate.FiscalMonthLabel.ReplaceWords(wordTranslation);
    }
    
    public static void CalculateDimDateValues(this DimDate dimDate)
    {
        var date = dimDate.Datekey;

        // Получаем год, месяц, неделю и день недели из DateKey
        var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
            date,
            CalendarWeekRule.FirstDay,
            DayOfWeek.Sunday);

        dimDate.CalendarMonthNumber = date.Month;
        dimDate.CalendarWeekNumberOfMonth = GetWeekNumber(date);
        dimDate.CalendarWeekNumberOfYear = week;
        dimDate.CalendarDayNumber = date.Day;
        dimDate.CalendarQuarterNumber = TryExtractQuarterNumber(dimDate.CalendarQuarterLabel);
    }

    private static int? TryExtractQuarterNumber(string inputString)
    {
        var pattern = @"Q(\d+)";
        var regex = new Regex(pattern);
        
        var match = regex.Match(inputString);

        if (!match.Success) return null;
        var number = Int32.Parse(match.Groups[1].Value);
        return number;
    }

    private static int GetWeekNumber(DateTime date)
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var dayOfWeek = (int)firstDayOfMonth.DayOfWeek;
        var daysDifference = date.Day - 1 + dayOfWeek;
        return daysDifference / 7 + 1;
    }
    
    private static string ReplaceWords(this string input, Dictionary<string, string> wordDictionary)
    {
        return wordDictionary.Aggregate(input, (current, pair) => current.Replace(pair.Key, pair.Value));
    }
}
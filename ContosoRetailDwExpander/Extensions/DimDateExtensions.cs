using System.Globalization;
using System.Text.RegularExpressions;
using ContosoRetailDwExpander.Model;

namespace ContosoRetailDwExpander.Extensions;

public static class DimDateExtensions
{
    public static void ConvertLabelsToRussian(this dimdate dimdate)
    {
        var date = dimdate.datekey;
        
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
        dimdate.calendaryearlabelru = dimdate.calendaryearlabel.ReplaceWords(wordTranslation);
        dimdate.calendarmonthlabelru = dimdate.calendarmonthlabel.ReplaceWords(dateTranslation);
        dimdate.calendarweeklabelru = dimdate.calendarweeklabel.ReplaceWords(wordTranslation);
        dimdate.calendardayofweeklabelru = dimdate.calendardayofweeklabel.ReplaceWords(dateTranslation);
        dimdate.isworkdayru = dimdate.isworkday.ReplaceWords(wordTranslation);

        dimdate.fiscalyearlabelru = dimdate.fiscalyearlabel.ReplaceWords(wordTranslation);
        dimdate.fiscalmonthlabelru = dimdate.fiscalmonthlabel.ReplaceWords(wordTranslation);
    }
    
    public static void CalculateDimDateValues(this dimdate dimdate)
    {
        var date = dimdate.datekey;

        // Получаем год, месяц, неделю и день недели из DateKey
        var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
            date,
            CalendarWeekRule.FirstDay,
            DayOfWeek.Sunday);

        dimdate.calendarmonthnumber = date.Month;
        dimdate.calendarweeknumberofmonth = GetWeekNumber(date);
        dimdate.calendarweeknumberofyear = week;
        dimdate.calendardaynumber = date.Day;
        dimdate.calendarquarternumber = TryExtractQuarterNumber(dimdate.calendarquarterlabel);
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
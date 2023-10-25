using System.Globalization;

namespace ContosoRetailDwExpander.Model;

public class dimdate
{
    public DateTime datekey { get; set; }

    public string fulldatelabel { get; set; } = null!;

    public string datedescription { get; set; } = null!;

    public int calendaryear { get; set; }

    public string calendaryearlabel { get; set; } = null!;

    public int calendarhalfyear { get; set; }

    public string calendarhalfyearlabel { get; set; } = null!;

    public int calendarquarter { get; set; }

    public string? calendarquarterlabel { get; set; }

    public int calendarmonth { get; set; }

    public string calendarmonthlabel { get; set; } = null!;

    public int calendarweek { get; set; }

    public string calendarweeklabel { get; set; } = null!;

    public int calendardayofweek { get; set; }

    public string calendardayofweeklabel { get; set; } = null!;

    public int fiscalyear { get; set; }

    public string fiscalyearlabel { get; set; } = null!;

    public int fiscalhalfyear { get; set; }

    public string fiscalhalfyearlabel { get; set; } = null!;

    public int fiscalquarter { get; set; }

    public string fiscalquarterlabel { get; set; } = null!;

    public int fiscalmonth { get; set; }

    public string fiscalmonthlabel { get; set; } = null!;

    public string isworkday { get; set; } = null!;

    public int isholiday { get; set; }

    public string holidayname { get; set; } = null!;

    public string? europeseason { get; set; }

    public string? northamericaseason { get; set; }

    public string? asiaseason { get; set; }

    [CsvIgnore]
    public virtual ICollection<factonlinesale> FactOnlineSales { get; set; } = new List<factonlinesale>();
    
    [CsvIgnore]
    public virtual ICollection<factofflinesale> FactOfflineSales { get; set; } = new List<factofflinesale>();

    //Новые столбцы
    public string? calendaryearlabelru { get; set; }
    public string? calendarmonthlabelru { get; set; }
    public string? calendarweeklabelru { get; set; }
    public string? calendardayofweeklabelru { get; set; }
    public string? fiscalyearlabelru { get; set; }
    public string? fiscalmonthlabelru { get; set; }

    public string? isworkdayru { get; set; } = null!;

    public int? calendarmonthnumber { get; set; }
    public int? calendardaynumber { get; set; }
    public int? calendarquarternumber { get; set; }
    public int? calendarweeknumberofmonth { get; set; }
    public int? calendarweeknumberofyear { get; set; }

    public string? simple_string_nullable { get; set; } = null;
}
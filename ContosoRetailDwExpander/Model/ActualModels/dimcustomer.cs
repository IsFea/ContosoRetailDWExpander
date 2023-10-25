namespace ContosoRetailDwExpander.Model;

public class dimcustomer
{
    public int customerkey { get; set; }

    // public int GeographyKey { get; set; }

    public string customerlabel { get; set; } = null!;

    public string? title { get; set; }

    public string? firstname { get; set; }

    public string? middlename { get; set; }

    public string? lastname { get; set; }

    public bool? namestyle { get; set; }

    public DateTime? birthdate { get; set; }

    public string? maritalstatus { get; set; }

    public string? suffix { get; set; }

    public string? gender { get; set; }

    public string? emailaddress { get; set; }

    public decimal? yearlyincome { get; set; }

    public byte? totalchildren { get; set; }

    public byte? numberchildrenathome { get; set; }

    public string? education { get; set; }

    public string? occupation { get; set; }

    public string? houseownerflag { get; set; }

    public byte? numbercarsowned { get; set; }

    public string? addressline1 { get; set; }

    public string? addressline2 { get; set; }

    public string? phone { get; set; }

    public DateTime? datefirstpurchase { get; set; }

    public string? customertype { get; set; }

    public string? companyname { get; set; }

    [CsvIgnore]
    public virtual ICollection<factonlinesale> FactOnlineSales { get; set; } = new List<factonlinesale>();
    
    [CsvIgnore]
    public virtual ICollection<factofflinesale> FactOfflineSales { get; set; } = new List<factofflinesale>();
    
    // public virtual DimGeography GeographyKeyNavigation { get; set; } = null!;
    
    //Новые колонки

    public string? inn { get; set; }
    public string? fat_string { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
}
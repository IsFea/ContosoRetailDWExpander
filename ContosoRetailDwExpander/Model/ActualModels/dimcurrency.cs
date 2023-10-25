namespace ContosoRetailDwExpander.Model;

public class dimcurrency
{
    public string currencykey { get; set; }

    public string currencylabel { get; set; } = null!;

    public string currencyname { get; set; } = null!;

    public string currencydescription { get; set; } = null!;
    
    public string? simple_string_nullable { get; set; } = null;
    
    [CsvIgnore]
    public virtual ICollection<factonlinesale> FactOnlineSales { get; set; } = new List<factonlinesale>();
    
    [CsvIgnore]
    public virtual ICollection<factofflinesale> FactOfflineSales { get; set; } = new List<factofflinesale>();
}
namespace ContosoRetailDwExpander.Model;

public class DimCurrency
{
    public string CurrencyKey { get; set; }

    public string CurrencyLabel { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string CurrencyDescription { get; set; } = null!;
    
    public string? simple_string_nullable { get; set; } = null;
    
    [CsvIgnore]
    public virtual ICollection<FactOnlineSale> FactOnlineSales { get; set; } = new List<FactOnlineSale>();
    
    [CsvIgnore]
    public virtual ICollection<FactOfflineSale> FactOfflineSales { get; set; } = new List<FactOfflineSale>();
}
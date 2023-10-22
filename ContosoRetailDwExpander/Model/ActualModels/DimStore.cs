namespace ContosoRetailDwExpander.Model;

public class DimStore
{
    public int StoreKey { get; set; }

    public int GeographyKey { get; set; }

    public int? StoreManager { get; set; }

    public string? StoreType { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreDescription { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime OpenDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public int? EntityKey { get; set; }

    public string? ZipCode { get; set; }

    public string? ZipCodeExtension { get; set; }

    public string? StorePhone { get; set; }

    public string? StoreFax { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? CloseReason { get; set; }

    public int? EmployeeCount { get; set; }

    public double? SellingAreaSize { get; set; }

    public DateTime? LastRemodelDate { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
    
    [CsvIgnore]
    public virtual ICollection<FactOnlineSale> FactOnlineSales { get; set; } = new List<FactOnlineSale>();
    
    [CsvIgnore]
    public virtual ICollection<FactOfflineSale> FactOfflineSales { get; set; } = new List<FactOfflineSale>();
}
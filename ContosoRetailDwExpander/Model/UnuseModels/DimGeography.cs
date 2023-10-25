namespace ContosoRetailDwExpander.Model;

public class DimGeography
{
    public int GeographyKey { get; set; }

    public string GeographyType { get; set; } = null!;

    public string ContinentName { get; set; } = null!;

    public string? CityName { get; set; }

    public string? StateProvinceName { get; set; }

    public string? RegionCountryName { get; set; }

    public int? EtlloadId { get; set; }

    public DateTime? LoadDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<dimcustomer> DimCustomers { get; set; } = new List<dimcustomer>();

    public virtual ICollection<DimSalesTerritory> DimSalesTerritories { get; set; } = new List<DimSalesTerritory>();

    public virtual ICollection<dimstore> DimStores { get; set; } = new List<dimstore>();
}
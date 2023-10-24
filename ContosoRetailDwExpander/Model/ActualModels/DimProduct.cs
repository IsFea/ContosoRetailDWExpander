namespace ContosoRetailDwExpander.Model;

public class DimProduct
{
    public int ProductKey { get; set; }

    public string? ProductLabel { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }
    
    public string? Manufacturer { get; set; }

    public string? BrandName { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? StyleId { get; set; }

    public string? StyleName { get; set; }

    public string? ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public string? Size { get; set; }

    public string? SizeRange { get; set; }

    public string? SizeUnitMeasureId { get; set; }

    public double? Weight { get; set; }

    public string? WeightUnitMeasureId { get; set; }

    public string? UnitOfMeasureId { get; set; }

    public string? UnitOfMeasureName { get; set; }

    public string? StockTypeId { get; set; }

    public string? StockTypeName { get; set; }

    public decimal? UnitCost { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? AvailableForSaleDate { get; set; }

    public DateTime? StopSaleDate { get; set; }

    public string? Status { get; set; }
    
    [CsvIgnore]
    public virtual ICollection<FactOnlineSale> FactOnlineSales { get; set; } = new List<FactOnlineSale>();
    
    [CsvIgnore]
    public virtual ICollection<FactOfflineSale> FactOfflineSales { get; set; } = new List<FactOfflineSale>();

    //Новые колонки

    public int? Brandname_id_nullable { get; set; }
    public int? Brandname_id { get; set; }
    public int? Classname_id_nullable { get; set; }
    public int? Classname_id { get; set; }
    public string? Brandname_string_nullable { get; set; }
    public string? Classname_string_nullable { get; set; }
    public bool? Status_bool { get; set; }
    public bool? Status_bool_nullable { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
}
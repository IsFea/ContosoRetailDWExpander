namespace ContosoRetailDwExpander.Model;

public class DimProductSubcategory
{
    public int ProductSubcategoryKey { get; set; }

    public string? ProductSubcategoryLabel { get; set; }

    public string ProductSubcategoryName { get; set; } = null!;

    public string? ProductSubcategoryDescription { get; set; }

    public int? ProductCategoryKey { get; set; }

    public int? EtlloadId { get; set; }

    public DateTime? LoadDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<dimproduct> DimProducts { get; set; } = new List<dimproduct>();

    public virtual DimProductCategory? ProductCategoryKeyNavigation { get; set; }
}
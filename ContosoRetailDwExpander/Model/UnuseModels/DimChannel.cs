namespace ContosoRetailDwExpander.Model;

public class DimChannel
{
    public int ChannelKey { get; set; }

    public string ChannelLabel { get; set; } = null!;

    public string? ChannelName { get; set; }

    public string? ChannelDescription { get; set; }

    public virtual ICollection<FactSale> FactSales { get; set; } = new List<FactSale>();

    public virtual ICollection<FactSalesQuotum> FactSalesQuota { get; set; } = new List<FactSalesQuotum>();
}
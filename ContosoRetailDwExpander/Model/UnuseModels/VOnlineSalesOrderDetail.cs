namespace ContosoRetailDwExpander.Model;

public class VOnlineSalesOrderDetail
{
    public string OrderNumber { get; set; } = null!;

    public int? LineNumber { get; set; }

    public string? Product { get; set; }
}
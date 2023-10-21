namespace ContosoRetailDwExpander.Model;

public class VProductForecast
{
    public int CalendarMonth { get; set; }

    public DateTime? ReportDate { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public int? SalesQuantity { get; set; }

    public decimal? SalesAmount { get; set; }
}
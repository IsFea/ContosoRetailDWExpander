namespace ContosoRetailDwExpander.Model;

public class FactInventory
{
    public int InventoryKey { get; set; }

    public DateTime DateKey { get; set; }

    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int CurrencyKey { get; set; }

    public int OnHandQuantity { get; set; }

    public int OnOrderQuantity { get; set; }

    public int? SafetyStockQuantity { get; set; }

    public decimal UnitCost { get; set; }

    public int? DaysInStock { get; set; }

    public int? MinDayInStock { get; set; }

    public int? MaxDayInStock { get; set; }

    public int? Aging { get; set; }

    public int? EtlloadId { get; set; }

    public DateTime? LoadDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual dimcurrency CurrencyKeyNavigation { get; set; } = null!;

    public virtual dimdate DateKeyNavigation { get; set; } = null!;

    public virtual dimproduct ProductKeyNavigation { get; set; } = null!;

    public virtual dimstore StoreKeyNavigation { get; set; } = null!;
}
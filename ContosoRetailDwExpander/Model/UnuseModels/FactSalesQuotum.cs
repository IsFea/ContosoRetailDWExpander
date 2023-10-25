namespace ContosoRetailDwExpander.Model;

public class FactSalesQuotum
{
    public int SalesQuotaKey { get; set; }

    public int ChannelKey { get; set; }

    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public DateTime DateKey { get; set; }

    public int CurrencyKey { get; set; }

    public int ScenarioKey { get; set; }

    public decimal SalesQuantityQuota { get; set; }

    public decimal SalesAmountQuota { get; set; }

    public decimal GrossMarginQuota { get; set; }

    public int? EtlloadId { get; set; }

    public DateTime? LoadDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual DimChannel ChannelKeyNavigation { get; set; } = null!;

    public virtual dimcurrency CurrencyKeyNavigation { get; set; } = null!;

    public virtual dimdate DateKeyNavigation { get; set; } = null!;

    public virtual dimproduct ProductKeyNavigation { get; set; } = null!;

    public virtual DimScenario ScenarioKeyNavigation { get; set; } = null!;

    public virtual dimstore StoreKeyNavigation { get; set; } = null!;
}
﻿namespace ContosoRetailDwExpander.Model;

public class FactSale
{
    public int SalesKey { get; set; }

    public DateTime DateKey { get; set; }

    public int ChannelKey { get; set; }

    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int PromotionKey { get; set; }

    public int CurrencyKey { get; set; }

    public decimal UnitCost { get; set; }

    public decimal UnitPrice { get; set; }

    public int SalesQuantity { get; set; }

    public int ReturnQuantity { get; set; }

    public decimal? ReturnAmount { get; set; }

    public int? DiscountQuantity { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal TotalCost { get; set; }

    public decimal SalesAmount { get; set; }

    public virtual DimChannel ChannelKeyNavigation { get; set; } = null!;

    public virtual dimcurrency CurrencyKeyNavigation { get; set; } = null!;

    public virtual dimdate DateKeyNavigation { get; set; } = null!;

    public virtual dimproduct ProductKeyNavigation { get; set; } = null!;

    public virtual dimpromotion PromotionKeyNavigation { get; set; } = null!;

    public virtual dimstore StoreKeyNavigation { get; set; } = null!;
}
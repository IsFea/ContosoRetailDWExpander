﻿namespace ContosoRetailDwExpander.Model;

public class DimPromotion
{
    public int? PromotionKey { get; set; }

    public string? PromotionLabel { get; set; }

    public string? PromotionName { get; set; }

    public string? PromotionDescription { get; set; }

    public double? DiscountPercent { get; set; }

    public string? PromotionType { get; set; }

    public string? PromotionCategory { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? MinQuantity { get; set; }

    public int? MaxQuantity { get; set; }

    public string? simple_string_nullable { get; set; } = null;
    // public virtual ICollection<FactOnlineSale> FactOnlineSales { get; set; } = new List<FactOnlineSale>();
    //
    // public virtual ICollection<FactSale> FactSales { get; set; } = new List<FactSale>();
}
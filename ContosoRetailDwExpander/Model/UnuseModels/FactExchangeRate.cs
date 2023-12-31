﻿namespace ContosoRetailDwExpander.Model;

public class FactExchangeRate
{
    public int ExchangeRateKey { get; set; }

    public int CurrencyKey { get; set; }

    public DateTime DateKey { get; set; }

    public double AverageRate { get; set; }

    public double EndOfDayRate { get; set; }

    public int? EtlloadId { get; set; }

    public DateTime? LoadDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual dimcurrency CurrencyKeyNavigation { get; set; } = null!;

    public virtual dimdate DateKeyNavigation { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoRetailDwExpander.Model;

public class factofflinesale
{
    public int offlinesaleskey { get; set; }

    public DateTime datekey { get; set; }

    public int storekey { get; set; }

    public int productkey { get; set; }

    public int promotionkey { get; set; }
    
    public int? promotionkeynullable { get; set; }

    public string currencykey { get; set; }

    public int customerkey { get; set; }

    public string salesordernumber { get; set; } = null!;

    public int? salesorderlinenumber { get; set; }

    public int salesquantity { get; set; }

    public decimal salesamount { get; set; }

    public int returnquantity { get; set; }

    public decimal? returnamount { get; set; }

    public int? discountquantity { get; set; }

    public decimal? discountamount { get; set; }

    public decimal totalcost { get; set; }

    public decimal? unitcost { get; set; }

    public decimal? unitprice { get; set; }

    public string? simple_string_nullable { get; set; } = null;

    [CsvIgnore]
    public virtual dimcurrency CurrencyKeyNavigation { get; set; } = null!;
    
    [CsvIgnore]
    public virtual dimcustomer CustomerKeyNavigation { get; set; } = null!;
    
    [CsvIgnore]
    public virtual dimdate DateKeyNavigation { get; set; } = null!;
    
    [CsvIgnore]
    public virtual dimproduct ProductKeyNavigation { get; set; } = null!;
    
    [CsvIgnore]
    public virtual dimpromotion PromotionKeyNavigation { get; set; } = null!;
    
    [CsvIgnore]
    public virtual dimstore StoreKeyNavigation { get; set; } = null!;
}
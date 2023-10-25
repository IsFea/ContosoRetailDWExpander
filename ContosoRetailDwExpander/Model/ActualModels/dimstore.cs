namespace ContosoRetailDwExpander.Model;

public class dimstore
{
    public int storekey { get; set; }

    public int geographykey { get; set; }

    public int? storemanager { get; set; }

    public string? storetype { get; set; }

    public string storename { get; set; } = null!;

    public string storedescription { get; set; } = null!;

    public string status { get; set; } = null!;

    public DateTime opendate { get; set; }

    public DateTime? closedate { get; set; }

    public int? entitykey { get; set; }

    public string? zipcode { get; set; }

    public string? zipcodeextension { get; set; }

    public string? storephone { get; set; }

    public string? storefax { get; set; }

    public string? addressline1 { get; set; }

    public string? addressline2 { get; set; }

    public string? closereason { get; set; }

    public int? employeecount { get; set; }

    public double? sellingareasize { get; set; }

    public DateTime? lastremodeldate { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
    
    [CsvIgnore]
    public virtual ICollection<factonlinesale> FactOnlineSales { get; set; } = new List<factonlinesale>();
    
    [CsvIgnore]
    public virtual ICollection<factofflinesale> FactOfflineSales { get; set; } = new List<factofflinesale>();
}
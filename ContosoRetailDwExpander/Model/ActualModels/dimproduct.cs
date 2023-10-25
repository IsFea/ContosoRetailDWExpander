namespace ContosoRetailDwExpander.Model;

public class dimproduct
{
    public int productkey { get; set; }

    public string? productlabel { get; set; }

    public string? productname { get; set; }

    public string? productdescription { get; set; }
    
    public string? manufacturer { get; set; }

    public string? brandname { get; set; }

    public string? classid { get; set; }

    public string? classname { get; set; }

    public string? styleid { get; set; }

    public string? stylename { get; set; }

    public string? colorid { get; set; }

    public string colorname { get; set; } = null!;

    public string? size { get; set; }

    public string? sizerange { get; set; }

    public string? sizeunitmeasureid { get; set; }

    public double? weight { get; set; }

    public string? weightunitmeasureid { get; set; }

    public string? unitofmeasureid { get; set; }

    public string? unitofmeasurename { get; set; }

    public string? stocktypeid { get; set; }

    public string? stocktypename { get; set; }

    public decimal? unitcost { get; set; }

    public decimal? unitprice { get; set; }

    public DateTime? availableforsaledate { get; set; }

    public DateTime? stopsaledate { get; set; }

    public string? status { get; set; }
    
    [CsvIgnore]
    public virtual ICollection<factonlinesale> FactOnlineSales { get; set; } = new List<factonlinesale>();
    
    [CsvIgnore]
    public virtual ICollection<factofflinesale> FactOfflineSales { get; set; } = new List<factofflinesale>();

    //Новые колонки

    public int? brandname_id_nullable { get; set; }
    public int? brandname_id { get; set; }
    public int? classname_id_nullable { get; set; }
    public int? classname_id { get; set; }
    public string? brandname_string_nullable { get; set; }
    public string? classname_string_nullable { get; set; }
    public bool? status_bool { get; set; }
    public bool? status_bool_nullable { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
}
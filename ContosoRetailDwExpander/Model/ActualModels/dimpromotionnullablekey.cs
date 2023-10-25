using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoRetailDwExpander.Model;

public class dimpromotionnullablekey
{
    public int? promotionkeynullable { get; set; }

    public string? promotionlabel { get; set; }

    public string? promotionname { get; set; }

    public string? promotiondescription { get; set; }

    public double? discountpercent { get; set; }

    public string? promotiontype { get; set; }

    public string? promotioncategory { get; set; }

    public DateTime startdate { get; set; }

    public DateTime? enddate { get; set; }

    public int? minquantity { get; set; }

    public int? maxquantity { get; set; }

    public string? simple_string_nullable { get; set; } = null;
}
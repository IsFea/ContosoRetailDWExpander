namespace ContosoRetailDwExpander.Model;

public class DimCustomer
{
    public int CustomerKey { get; set; }

    // public int GeographyKey { get; set; }

    public string CustomerLabel { get; set; } = null!;

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public bool? NameStyle { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Suffix { get; set; }

    public string? Gender { get; set; }

    public string? EmailAddress { get; set; }

    public decimal? YearlyIncome { get; set; }

    public byte? TotalChildren { get; set; }

    public byte? NumberChildrenAtHome { get; set; }

    public string? Education { get; set; }

    public string? Occupation { get; set; }

    public string? HouseOwnerFlag { get; set; }

    public byte? NumberCarsOwned { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Phone { get; set; }

    public DateTime? DateFirstPurchase { get; set; }

    public string? CustomerType { get; set; }

    public string? CompanyName { get; set; }

    // public virtual ICollection<FactOnlineSale> FactOnlineSales { get; set; } = new List<FactOnlineSale>();
    //
    // public virtual DimGeography GeographyKeyNavigation { get; set; } = null!;
    
    //Новые колонки

    public string? Inn { get; set; }
    public string? Fat_string { get; set; }
    
    public string? simple_string_nullable { get; set; } = null;
}
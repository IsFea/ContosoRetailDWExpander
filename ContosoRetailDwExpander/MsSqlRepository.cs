using System.Data;
using System.Data.SqlClient;
using ContosoRetailDwExpander.Model;
using Dapper;

static class MsSqlRepository
{
    static string connectionString = "Server=127.0.0.1,49170;User id=admin;Password=;Database=ContosoRetailDW;TrustServerCertificate=True;";

    public static List<DimProduct> PullDimProduct()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimProduct>("SELECT * FROM DimProduct").ToList();
        }
    }

    public static List<DimCurrency> PullDimCurrency()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimCurrency>("SELECT * FROM DimCurrency").ToList();
        }
    }

    public static List<DimCustomer> PullDimCustomer()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimCustomer>("SELECT * FROM DimCustomer").ToList();
        }
    }

    public static List<FactOnlineSale> PullFactOnlineSales()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<FactOnlineSale>("SELECT * FROM FactOnlineSales").ToList();
        }
    }

    public static List<DimStore> PullDimStore()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimStore>("SELECT * FROM DimStore").ToList();
        }
    }

    public static List<DimPromotion> PullDimPromotion()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimPromotion>("SELECT * FROM DimPromotion").ToList();
        }
    }
    
    public static List<DimPromotionNullableKey> PullDimPromotionNullableKey()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimPromotionNullableKey>(@"select 
            PromotionKey as PromotionKeyNullable
                ,PromotionLabel
                ,PromotionName
                ,PromotionDescription
                ,DiscountPercent
                ,PromotionType
                ,PromotionCategory
                ,StartDate
                ,EndDate
                ,MinQuantity
                ,MaxQuantity
                from dimpromotion").ToList();
        }
    }

    public static List<DimDate> PullDimDate()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<DimDate>("SELECT * FROM DimDate").ToList();
        }
    }
}
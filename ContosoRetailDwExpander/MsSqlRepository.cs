using System.Data;
using System.Data.SqlClient;
using ContosoRetailDwExpander.Model;
using Dapper;

static class MsSqlRepository
{
    private static string _connectionString = "Server=127.0.0.1,49170;User id=admin;Password=;Database=ContosoRetailDW;TrustServerCertificate=True;";

    public static void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }
    public static List<dimproduct> PullDimProduct()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimproduct>("SELECT * FROM DimProduct").ToList();
        }
    }

    public static List<dimcurrency> PullDimCurrency()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimcurrency>("SELECT * FROM DimCurrency").ToList();
        }
    }

    public static List<dimcustomer> PullDimCustomer()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimcustomer>("SELECT * FROM DimCustomer").ToList();
        }
    }

    public static List<factonlinesale> PullFactOnlineSales()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<factonlinesale>("SELECT * FROM FactOnlineSales").ToList();
        }
    }

    public static List<dimstore> PullDimStore()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimstore>("SELECT * FROM DimStore").ToList();
        }
    }

    public static List<dimpromotion> PullDimPromotion()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimpromotion>("SELECT * FROM DimPromotion").ToList();
        }
    }
    
    public static List<dimpromotionnullablekey> PullDimPromotionNullableKey()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimpromotionnullablekey>(@"select 
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

    public static List<dimdate> PullDimDate()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<dimdate>("SELECT * FROM DimDate").ToList();
        }
    }
}
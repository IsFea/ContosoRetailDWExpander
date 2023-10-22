using System.Collections;
using ContosoRetailDwExpander;
using ContosoRetailDwExpander.Extensions;
using ContosoRetailDwExpander.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using static ContosoRetailDwExpander.Filler;

internal static class Program
{
    private const string _basePath = "Q://NewContosoDB/";
    private const string _pathToFatString = "Q://fat_string.csv";
    private const string _postgressConnection = "Host=127.0.0.1;Port=5432;Username=postgres;Password=;Database=MyContoso";

    public static void Main(string[] args)
    {
        GenerateData();
        // LoadToPostgress();
    }

    private static void LoadToPostgress()
    {
        var paths = new Dictionary<string, string>()
        {
            { _basePath + "dimProduct.csv", "DimProduct" },
            { _basePath + "dimCurrency.csv", "DimCurrency" },
            { _basePath + "dimDate.csv", "DimDate" },
            { _basePath + "dimStore.csv", "DimStore" },
            { _basePath + "dimPromotion.csv", "DimPromotion" },
            { _basePath + "dimPromotionNullableKey.csv", "DimPromotionNullableKey" },
            { _basePath + "dimCustomer.csv", "DimCustomer" },
            { _basePath + "factOnlineSales.csv", "FactOnlineSales" },
            { _basePath + "factOfflineSales.csv", "FactOfflineSales" }
        };

        foreach (var kvp in paths)
        {
            LoadData(kvp.Key, kvp.Value);
        }

        static void LoadData(string path, string table)
        {
            using var connection = new NpgsqlConnection(_postgressConnection);
            connection.Open();
            // \COPY "DimProduct" FROM 'Q://NewContosoDB/dimProduct.csv' DELIMITER '¿' CSV HEADER
            using (var cmd = new NpgsqlCommand($"COPY \"{table}\" FROM '{path}' DELIMITER '¿' CSV HEADER", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void GenerateData()
    {
        var dimProduct = MsSqlRepository.PullDimProduct();
        var dimCurrency = MsSqlRepository.PullDimCurrency();
        var dimCustomer = MsSqlRepository.PullDimCustomer();
        var factOnlineSales = new List<FactOnlineSale>();
        var dimStore = MsSqlRepository.PullDimStore();
        var dimPromotion = MsSqlRepository.PullDimPromotion();
        var dimPromotionNullableKey = MsSqlRepository.PullDimPromotionNullableKey();
        var dimDate = MsSqlRepository.PullDimDate();
        var factOfflineSales = new List<FactOfflineSale>();

        var dimCustomerCount = dimCustomer.Count();

        FillDimCustomer(dimCustomer, _pathToFatString);
        FillDimProduct(dimProduct);
        FillDimDate(dimDate);
        FillDimPromotion(dimPromotion);
        FillFactOfflineSales(factOfflineSales, dimDate, dimCustomer, dimStore, dimPromotion, dimProduct);

        CsvUtils.CreateCSV(factOfflineSales, _basePath + "factOfflineSales.csv");
        factOfflineSales.Clear();

        FillAndWriteToCsvFactOnlineSales(factOnlineSales, dimDate, dimCustomer, dimStore, dimPromotion, dimProduct,
            dimCustomerCount, _basePath + "factOnlineSales.csv");

        CsvUtils.CreateCSV(dimProduct, _basePath + "dimProduct.csv");
        dimProduct.Clear();

        CsvUtils.CreateCSV(dimCurrency, _basePath + "dimCurrency.csv");
        dimCurrency.Clear();

        CsvUtils.CreateCSV(dimDate, _basePath + "dimDate.csv");
        dimDate.Clear();

        CsvUtils.CreateCSV(dimStore, _basePath + "dimStore.csv");
        dimStore.Clear();

        CsvUtils.CreateCSV(dimPromotion, _basePath + "dimPromotion.csv");
        dimPromotion.Clear();

        CsvUtils.CreateCSV(dimPromotionNullableKey, _basePath + "dimPromotionNullableKey.csv");
        dimPromotionNullableKey.Clear();

        CsvUtils.CreateCSV(dimCustomer, _basePath + "dimCustomer.csv");
        dimCustomer.Clear();
    }
}
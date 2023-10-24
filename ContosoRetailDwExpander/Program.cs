using System.Collections;
using System.Configuration;
using ContosoRetailDwExpander;
using ContosoRetailDwExpander.Extensions;
using ContosoRetailDwExpander.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using static ContosoRetailDwExpander.Filler;

internal static class Program
{
    private static string _basePath;
    private static string _pathToFatString;
    public static void Main(string[] args)
    {
        _basePath = ConfigurationManager.AppSettings["BasePath"];
        _pathToFatString = ConfigurationManager.AppSettings["PathToFatString"];
        MsSqlRepository.SetConnectionString(ConfigurationManager.AppSettings["ConnectionString"]);
        GenerateData();
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
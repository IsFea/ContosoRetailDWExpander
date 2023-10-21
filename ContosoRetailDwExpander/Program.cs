using ContosoRetailDwExpander;
using ContosoRetailDwExpander.Extensions;
using ContosoRetailDwExpander.Model;
using Microsoft.VisualBasic.CompilerServices;
using static ContosoRetailDwExpander.Filler;

internal static class Program
{
    public static void Main(string[] args)
    {
        var dimProduct = MsSqlRepository.PullDimProduct();
        var dimCurrency = MsSqlRepository.PullDimCurrency();
        var dimCustomer = MsSqlRepository.PullDimCustomer();
        var factOnlineSales = MsSqlRepository.PullFactOnlineSales();
        var dimStore = MsSqlRepository.PullDimStore();
        var dimPromotion = MsSqlRepository.PullDimPromotion();
        var dimPromotionNullableKey = MsSqlRepository.PullDimPromotionNullableKey();
        var dimDate = MsSqlRepository.PullDimDate();
        var factOfflineSales = new List<FactOfflineSale>();

        //Неиспользуемые колонки
        // var dimProductAllNullColumns = Utils.FindNullProperties(dimProduct, "DimProduct");
        // var dimCurrencyAllNullColumns = Utils.FindNullProperties(dimCurrency, "DimCurrency");
        // var dimCustomerAllNullColumns = Utils.FindNullProperties(dimCustomer, "DimCustomer");
        // var dimFactOnlineSalesAllNullColumns = Utils.FindNullProperties(factOnlineSales, "FactOnlineSale");
        // var dimStoreAllNullColumns = Utils.FindNullProperties(dimStore, "DimStore");
        // var dimPromotionAllNullColumns = Utils.FindNullProperties(dimPromotion, "DimPromotion");
        // var dimDateAllNullColumns = Utils.FindNullProperties(dimDate, "DimDate");

        var dimCustomerCount = dimCustomer.Count();
        
        FillDimCustomer(dimCustomer);
        FillDimProduct(dimProduct);
        FillDimDate(dimDate);
        FillDimPromotion(dimPromotion);
        FillFactOnlineSales(factOnlineSales, dimDate, dimCustomer, dimStore, dimPromotion, dimProduct,
            dimCustomerCount);
        FillFactOfflineSales(factOfflineSales, dimDate, dimCustomer, dimStore, dimPromotion, dimProduct);

        CsvUtils.CreateCSV(dimProduct, "Q://NewContosoDB/dimProduct.csv");
        CsvUtils.CreateCSV(dimCurrency, "Q://NewContosoDB/dimCurrency.csv");
        CsvUtils.CreateCSV(dimDate, "Q://NewContosoDB/dimDate.csv");
        CsvUtils.CreateCSV(dimStore, "Q://NewContosoDB/dimStore.csv");
        CsvUtils.CreateCSV(dimPromotion, "Q://NewContosoDB/dimPromotion.csv");
        CsvUtils.CreateCSV(dimPromotionNullableKey, "Q://NewContosoDB/dimPromotionNullableKey.csv");
        
        CsvUtils.CreateCSV(dimCustomer, "Q://NewContosoDB/dimCustomer.csv");
        CsvUtils.CreateCSV(factOfflineSales, "Q://NewContosoDB/factOfflineSales.csv");
        CsvUtils.CreateCSV(factOnlineSales, "Q://NewContosoDB/factOnlineSales.csv");
    }
}
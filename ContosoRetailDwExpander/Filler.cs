using ContosoRetailDwExpander.Extensions;
using ContosoRetailDwExpander.Model;
using static ContosoRetailDwExpander.DataGenerator;


namespace ContosoRetailDwExpander;

public static partial class Filler
{
    public static void FillFactOfflineSales(
        List<FactOfflineSale> factOfflineSales,
        List<DimDate> dimDates,
        List<DimCustomer> dimCustomers,
        List<DimStore> dimStores,
        List<DimPromotion> dimPromotions,
        List<DimProduct> dimProducts)
    {
        var rand = new Random();
        const int neededRowCount = 100000;
        
        var dimDatesCount = dimDates.Count();
        var dimStoresCount = dimStores.Count();
        var dimProductsCount = dimProducts.Count();
        var dimPromotionsCount = dimPromotions.Count();
        var dimCustomersCount = dimCustomers.Count();
        for (var i = 0; i < neededRowCount; i++)
        {
            var onlineSalesKey = i;

            var dateKey = dimDates[rand.Next(0, dimDatesCount - 1)].Datekey;

            var storeKey = dimStores[rand.Next(0, dimStoresCount - 1)].StoreKey;

            var randProduct = dimProducts[rand.Next(0, dimProductsCount - 1)];
            var productKey = randProduct.ProductKey;

            var randPromotion = dimPromotions[rand.Next(0, dimPromotionsCount - 1)];
            var promotionKey = randPromotion.PromotionKey;

            var promotionKeyNullable = randPromotion.PromotionKey == 1 ? null : randPromotion.PromotionKey;

            var currencyKey = "1";
            
            var randDimcustomer = dimCustomers[rand.Next(0, dimCustomersCount - 1)];
            var customerKey = randDimcustomer.CustomerKey;

            var salesOrderNumber = dateKey.ToString().Replace(".", "")[..8] + randDimcustomer.CustomerLabel;

            // var SalesOrderLineNumber;

            decimal? totalCost = randProduct.UnitCost;

            var unitCost = randProduct.UnitCost;

            var unitPrice = randProduct.UnitPrice;


            var salesQuantity = rand.Next(1, 10);

            var salesAmount = salesQuantity * unitPrice;

            var returnQuantity = 0;

            var returnAmount = 0;

            var discountQuantity = rand.Next(0, 2);

            var discountAmount = discountQuantity > 0 ? unitPrice * (decimal)0.10 : 0;
            
            factOfflineSales.Add(new FactOfflineSale()
            {
                OnlineSalesKey = onlineSalesKey,
                CurrencyKey = currencyKey,
                CustomerKey = customerKey,
                SalesOrderNumber = salesOrderNumber,
                SalesOrderLineNumber = null,
                SalesQuantity = salesQuantity,
                SalesAmount = salesAmount.Value,
                ReturnQuantity = returnQuantity,
                DateKey = dateKey,
                StoreKey = storeKey,
                DiscountAmount = discountAmount,
                TotalCost = totalCost.Value,
                UnitCost = unitCost,
                UnitPrice = unitPrice,
                simple_string_nullable = null,
                DiscountQuantity = discountQuantity,
                ProductKey = productKey,
                PromotionKey = promotionKey.Value,
                PromotionKeyNullable = promotionKeyNullable.Value,
                ReturnAmount = returnAmount,
            
            });
        }
    }
    
    public static void FillAndWriteToCsvFactOnlineSales(
        List<FactOnlineSale> factOnlineSales,
        List<DimDate> dimDates,
        List<DimCustomer> dimCustomers,
        List<DimStore> dimStores,
        List<DimPromotion> dimPromotions,
        List<DimProduct> dimProducts,
        int startedCountCustomer,
        string pathToWrite)
    {
        var rand = new Random();
        var onlineSalesKeyMax = 0; //factOnlineSales.Max(x => x.OnlineSalesKey);
        var countRowInCurrent = factOnlineSales.Count();
        const int neededRowCount = 200000000;
        var diff = neededRowCount - countRowInCurrent;

        var dimCustomerCount = dimCustomers.Count();
        var newPositionOfCustomer = 0; //dimCustomerCount - startedCountCustomer;
        var customerIterator = newPositionOfCustomer;

        var dimDatesCount = dimDates.Count();
        var dimStoresCount = dimStores.Count();
        var dimProductsCount = dimProducts.Count();
        var dimPromotionsCount = dimPromotions.Count();

        var generetedFactOnlineSales = new List<FactOnlineSale>();
        for (var i = 0; i < diff; i++)
        {
            var onlineSalesKey = onlineSalesKeyMax + i;

            var dateKey = dimDates[rand.Next(0, dimDatesCount)].Datekey;

            var storeKey = dimStores[rand.Next(0, dimStoresCount)].StoreKey;

            var randProduct = dimProducts[rand.Next(0, dimProductsCount)];
            var productKey = randProduct.ProductKey;

            var randPromotion = dimPromotions[rand.Next(0, dimPromotionsCount)];
            var promotionKey = randPromotion.PromotionKey;

            var promotionKeyNullable = randPromotion.PromotionKey == 1 ? null : promotionKey;

            var currencyKey = "1";

            if (customerIterator >= dimCustomerCount)
                customerIterator = newPositionOfCustomer;

            var randDimcustomer = dimCustomers[customerIterator];
            var customerKey = randDimcustomer.CustomerKey;
            customerIterator++;

            var salesOrderNumber = dateKey.ToString().Replace("-", "")[..8] + randDimcustomer.CustomerLabel;

            // var SalesOrderLineNumber;

            decimal? totalCost = randProduct.UnitCost;

            var unitCost = randProduct.UnitCost;

            var unitPrice = randProduct.UnitPrice;


            var salesQuantity = rand.Next(1, 10);

            var salesAmount = salesQuantity * unitPrice;

            var returnQuantity = 0;

            var returnAmount = 0;

            var discountQuantity = rand.Next(0, 2);

            var discountAmount = discountQuantity > 0 ? unitPrice * (decimal?)0.10 : 0;
            
            generetedFactOnlineSales.Add(new FactOnlineSale
            {
                OnlineSalesKey = onlineSalesKey,
                CurrencyKey = currencyKey,
                CustomerKey = customerKey,
                SalesOrderNumber = salesOrderNumber,
                SalesOrderLineNumber = null,
                SalesQuantity = salesQuantity,
                SalesAmount = salesAmount.Value,
                ReturnQuantity = returnQuantity,
                DateKey = dateKey,
                StoreKey = storeKey,
                DiscountAmount = discountAmount,
                TotalCost = totalCost.Value,
                UnitCost = unitCost,
                UnitPrice = unitPrice,
                simple_string_nullable = null,
                DiscountQuantity = discountQuantity,
                ProductKey = productKey,
                PromotionKey = promotionKey.Value,
                PromotionKeyNullable = promotionKeyNullable,
                ReturnAmount = returnAmount,
            
            });

            if (i % 5000000 == 0 && i != 0)
            {
                CsvUtils.CreateCSV(generetedFactOnlineSales, pathToWrite);
                generetedFactOnlineSales.Clear();
            }
        }
        //Дописываем остатки
        if (generetedFactOnlineSales.Any())
            CsvUtils.CreateCSV(generetedFactOnlineSales, pathToWrite);
    }

    public static void FillDimPromotion(List<DimPromotion> dimPromotions)
    {
        dimPromotions.RemoveAll(x => x.PromotionKey == 1);
    }

    public static void FillDimDate(List<DimDate> dimDates)
    {
        foreach (var dimDate in dimDates)
        {
            dimDate.ConvertLabelsToRussian();
            dimDate.CalculateDimDateValues();
        }
    }

    public static void FillDimCustomer(List<DimCustomer> dimCustomers, string pathToFatString)
    {
        var countRowInCurrent = dimCustomers.Count();
        const int neededRowCount = 5000000;
        var diff = neededRowCount - countRowInCurrent;

        var customerKeyMax = dimCustomers.Select(x => x.CustomerKey).Max();
        
        var random = new Random();
        
        for (var i = 0; i < diff; i++)
        {
            var toSkip = random.Next(0, countRowInCurrent);
            var rndCust = dimCustomers[toSkip];


            var title = rndCust.NameStyle == true ? null : titles[random.Next(titles.Length)];
            var firstName = rndCust.NameStyle == true ? null : firstNames[random.Next(firstNames.Length)];
            var middleName = rndCust.NameStyle == true ? null : middleNames[random.Next(middleNames.Length)];
            var lastName = rndCust.NameStyle == true ? null : lastNames[random.Next(lastNames.Length)];

            var generatedEmail = rndCust.NameStyle == true
                ? null
                : lastName + title + firstName + middleName + random.Next(0, 2014) + "@adventure-works.com";

            var companyPrefix = companyPrefixes[random.Next(companyPrefixes.Length)];
            var companySuffix = companySuffixes[random.Next(companySuffixes.Length)];

            var generatedGender = rndCust.NameStyle == true ? null : new[] { "M", "F" }[random.Next(0, 2)];


            var generatedCompanyName = rndCust.NameStyle == true ? $"{companyPrefix} {companySuffix}" : null;

            var generetaedYearlyIncome =
                rndCust.NameStyle == true ? random.Next(1000000, 50000000) : random.Next(1000, 1000000);

            var generetedTotalChld = rndCust.NameStyle == true ? 0 : random.Next(0, 6);

            var generetedTotalChldInHome = rndCust.NameStyle == true ? 0 : random.Next(0, generetedTotalChld + 1);

            var generetedEducation = rndCust.NameStyle == true ? null : education[random.Next(education.Length)];

            var generetedOccupation = rndCust.NameStyle == true ? null : occupation[random.Next(occupation.Length)];

            var generetedHouseOwner = random.Next(0, 2);

            var generetedCarsOwned = random.Next(0, 6);


            var streetName = streetNames[random.Next(streetNames.Length)];
            var streetNumber = random.Next(1, 1000);
            var city = cities[random.Next(cities.Length)];
            var state = states[random.Next(states.Length)];
            var zipCode = random.Next(10000, 100000);

            var generatedAddress = $"{streetNumber} {streetName}, {city}, {state} {zipCode}";

            var customerType = rndCust.NameStyle == true ? "Company" : "Person";

            var dimCustomerToInsert = new DimCustomer
            {
                CustomerKey = customerKeyMax + i,
                CustomerLabel = rndCust.CustomerLabel + i,
                Title = title,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                NameStyle = rndCust.NameStyle,
                BirthDate = rndCust.BirthDate,
                MaritalStatus = rndCust.MaritalStatus,
                Suffix = rndCust.Suffix,
                Gender = generatedGender,
                EmailAddress = generatedEmail,
                YearlyIncome = generetaedYearlyIncome,
                TotalChildren = (byte)generetedTotalChld,
                NumberChildrenAtHome = (byte)generetedTotalChldInHome,
                Education = generetedEducation,
                Occupation = generetedOccupation,
                HouseOwnerFlag = generetedHouseOwner.ToString(),
                NumberCarsOwned = (byte)generetedCarsOwned,
                AddressLine1 = generatedAddress,
                AddressLine2 = null,
                Phone = rndCust.NameStyle == true ? null : GeneratePhoneNumber(random),
                DateFirstPurchase = null,
                CustomerType = customerType,
                CompanyName = generatedCompanyName
            };

            dimCustomers.Add(dimCustomerToInsert);
        }

        var subjects = CsvUtils.LoadOneDimensionalCsv(pathToFatString);

        for (var i = 0; i < dimCustomers.Count(); i++)
        {
            dimCustomers[i].Inn = GenerateInn();
            dimCustomers[i].Fat_string = subjects[i];
        }
        subjects.Clear();
        GC.Collect();
    }

    public static void FillDimProduct(IEnumerable<DimProduct> dimProducts)
    {
        var random = new Random();

        var numericBrandName = dimProducts
            .Select(x => x.BrandName)
            .Distinct()
            .OrderBy(brandName => brandName)
            .Select((brandName, index) => new
            {
                BrandName = brandName,
                BrandName_Id = index + 1
            });

        var numericClassName = dimProducts
            .Select(x => x.ClassName)
            .Distinct()
            .OrderBy(className => className)
            .Select((className, index) => new
            {
                className = className,
                className_Id = index + 1
            });

        foreach (var dimProduct in dimProducts)
        {
            dimProduct.Brandname_id = numericBrandName.Where(x => x.BrandName == dimProduct.BrandName)
                .Select(x => x.BrandName_Id).First();
            dimProduct.Brandname_id_nullable = dimProduct.BrandName == "Contoso"
                ? null
                : numericBrandName.Where(x => x.BrandName == dimProduct.BrandName)
                    .Select(x => x.BrandName_Id).First();


            dimProduct.Classname_id = numericClassName.Where(x => x.className == dimProduct.ClassName)
                .Select(x => x.className_Id).First();
            dimProduct.Classname_id_nullable = dimProduct.ClassName == "Regular"
                ? null
                : numericClassName.Where(x => x.className == dimProduct.ClassName)
                    .Select(x => x.className_Id).First();

            dimProduct.Brandname_string_nullable = dimProduct.BrandName == "Contoso" ? null : dimProduct.BrandName;

            dimProduct.Classname_string_nullable = dimProduct.ClassName == "Regular" ? null : dimProduct.ClassName;

            dimProduct.Status_bool = dimProduct.Status == "On";

            dimProduct.Status_bool_nullable = dimProduct.Status == "On" ? true : null;

            //Вероятность 10%
            if (random.Next(1, 11) == 1)
            {
                // Список возможных значений
                string[] options = { "", null, " " };

                // Выбираем случайное значение из списка
                var newValue = options[random.Next(options.Length)];

                // Присваиваем новое значение строке
                dimProduct.ProductDescription = newValue;
            }
        }

        //Мин-макс по классу продукта для генерации
        // var productCategoryMinMax = dimProducts.Select(x => new { x.ClassName, x.UnitCost, x.UnitPrice })
        //     .GroupBy(x => x.ClassName).Select(x => new
        //     {
        //         ClassName = x.Key,
        //         MaxUnitCost = x.Max(y => y.UnitCost),
        //         MinUnitCost = x.Min(y => y.UnitCost),
        //         MaxUnitPrice = x.Max(y => y.UnitPrice),
        //         MinUnitPrice = x.Min(y => y.UnitPrice)
        //     });

        // var countRowInCurrentProducts = dimProducts.Count();
        // var neededRowCountInProducts = 5000000;
        // var diff = neededRowCountInProducts - countRowInCurrentProducts;
        //
        // Random rand = new Random();
        //
        // for (int i = 0; i < diff; i++)
        // {
        //     var productToInsert = new DimProduct();
        //
        //     int toSkip = rand.Next(0, countRowInCurrentProducts);
        //     var rndProduct = dimProducts.Skip(toSkip).Take(1).First();
        //
        //     productToInsert.ProductKey = dimProducts.Max(x => x.ProductKey) + 1;
        //
        //     productToInsert.ProductLabel = dimProducts.Select(x =>
        //     {
        //         long.TryParse(x.ProductLabel, out var newEbale);
        //         return newEbale;
        //     }).Max().ToString();
        //
        //     productToInsert.ProductName = rndProduct.ProductName + i;
        //
        //     productToInsert.ProductDescription = rndProduct.ProductDescription;
        //
        //     productToInsert.Manufacturer = rndProduct.Manufacturer;
        //
        //     productToInsert.BrandName = productToInsert.BrandName;
        //
        //     productToInsert.ClassId = rndProduct.ClassId;
        //
        //     productToInsert.ClassName = rndProduct.ClassName;
        //
        //     productToInsert.StyleId = rndProduct.StyleId;
        //
        //     productToInsert.StyleName = rndProduct.StyleName;
        //
        //     productToInsert.ColorId = rndProduct.ColorId;
        //
        //     productToInsert.ColorName = rndProduct.ColorName;
        //
        //     productToInsert.Size = rndProduct.Size;
        //
        //     productToInsert.SizeRange = rndProduct.SizeRange;
        //
        //     productToInsert.SizeUnitMeasureId = null;
        //
        //     productToInsert.Weight = rndProduct.Weight;
        //
        //     productToInsert.WeightUnitMeasureId = rndProduct.WeightUnitMeasureId;
        //
        //     productToInsert.UnitOfMeasureId = rndProduct.WeightUnitMeasureId;
        //
        //     productToInsert.UnitOfMeasureName = rndProduct.UnitOfMeasureName;
        //
        //     productToInsert.StockTypeId = rndProduct.StockTypeId;
        //
        //
        //     var minMaxUnitCost = productCategoryMinMax.Where(x => x.ClassName == rndProduct.ClassName)
        //         .Select(y => new { max = y.MaxUnitCost, min = y.MinUnitCost }).First();
        //     productToInsert.UnitCost = Utils.GenerateRandomDecimal(minMaxUnitCost.min.Value, minMaxUnitCost.max.Value);
        //     
        //     var minMaxUnitPrice = productCategoryMinMax.Where(x => x.ClassName == rndProduct.ClassName)
        //         .Select(y => new { max = y.MaxUnitPrice, min = y.MinUnitPrice }).First();
        //     productToInsert.UnitPrice = Utils.GenerateRandomDecimal(minMaxUnitPrice.min.Value, minMaxUnitPrice.max.Value);
        //
        //     productToInsert.AvailableForSaleDate = rndProduct.AvailableForSaleDate;
        //     
        //     
        // }
    }
}
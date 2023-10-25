using ContosoRetailDwExpander.Extensions;
using ContosoRetailDwExpander.Model;
using static ContosoRetailDwExpander.DataGenerator;


namespace ContosoRetailDwExpander;

public static partial class Filler
{
    public static void FillFactOfflineSales(
        List<factofflinesale> factOfflineSales,
        List<dimdate> dimDates,
        List<dimcustomer> dimCustomers,
        List<dimstore> dimStores,
        List<dimpromotion> dimPromotions,
        List<dimpromotionnullablekey> dimPromotionNullables,
        List<dimproduct> dimProducts)
    {
        var rand = new Random();
        const int neededRowCount = 100000;
        
        var dimDatesCount = dimDates.Count();
        var dimStoresCount = dimStores.Count();
        var dimProductsCount = dimProducts.Count();
        var dimPromotionsCount = dimPromotions.Count();
        var dimPromotionNullablesCount = dimPromotionNullables.Count();
        var dimCustomersCount = dimCustomers.Count();
        for (var i = 0; i < neededRowCount; i++)
        {
            var onlineSalesKey = i;

            var dateKey = dimDates[rand.Next(0, dimDatesCount - 1)].datekey;

            var storeKey = dimStores[rand.Next(0, dimStoresCount - 1)].storekey;

            var randProduct = dimProducts[rand.Next(0, dimProductsCount - 1)];
            var productKey = randProduct.productkey;

            var randPromotion = dimPromotions[rand.Next(0, dimPromotionsCount - 1)];
            var promotionKey = randPromotion.promotionkey;
            
            var randPromotionNullable = dimPromotionNullables[rand.Next(0, dimPromotionNullablesCount - 1)];
            var promotionKeyNullableForInsert = randPromotionNullable.promotionkeynullable;

            var promotionKeyNullable = promotionKeyNullableForInsert == 1 ? null : promotionKeyNullableForInsert;

            var currencyKey = "1";
            
            var randDimcustomer = dimCustomers[rand.Next(0, dimCustomersCount - 1)];
            var customerKey = randDimcustomer.customerkey;

            var salesOrderNumber = dateKey.ToString().Replace(".", "")[..8] + randDimcustomer.customerlabel;

            // var SalesOrderLineNumber;

            decimal? totalCost = randProduct.unitcost;

            var unitCost = randProduct.unitcost;

            var unitPrice = randProduct.unitprice;


            var salesQuantity = rand.Next(1, 10);

            var salesAmount = salesQuantity * unitPrice;

            var returnQuantity = 0;

            var returnAmount = 0;

            var discountQuantity = rand.Next(0, 2);

            var discountAmount = discountQuantity > 0 ? unitPrice * (decimal)0.10 : 0;
            
            factOfflineSales.Add(new factofflinesale()
            {
                offlinesaleskey = onlineSalesKey,
                currencykey = currencyKey,
                customerkey = customerKey,
                salesordernumber = salesOrderNumber,
                salesorderlinenumber = rand.Next(1, 4874),
                salesquantity = salesQuantity,
                salesamount = salesAmount.Value,
                returnquantity = returnQuantity,
                datekey = dateKey,
                storekey = storeKey,
                discountamount = discountAmount,
                totalcost = totalCost.Value,
                unitcost = unitCost,
                unitprice = unitPrice,
                simple_string_nullable = null,
                discountquantity = discountQuantity,
                productkey = productKey,
                promotionkey = promotionKey.Value,
                promotionkeynullable = promotionKeyNullable.Value,
                returnamount = returnAmount,
            
            });
        }
    }
    
    public static void FillAndWriteToCsvFactOnlineSales(
        List<factonlinesale> factOnlineSales,
        List<dimdate> dimDates,
        List<dimcustomer> dimCustomers,
        List<dimstore> dimStores,
        List<dimpromotion> dimPromotions,
        List<dimpromotionnullablekey> dimPromotionNullables,
        List<dimproduct> dimProducts,
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

        var generetedFactOnlineSales = new List<factonlinesale>();
        var firstBatch = true;
        
        for (var i = 0; i < diff; i++)
        {
            var onlineSalesKey = onlineSalesKeyMax + i;

            var dateKey = dimDates[rand.Next(0, dimDatesCount)].datekey;

            var storeKey = dimStores[rand.Next(0, dimStoresCount)].storekey;

            var randProduct = dimProducts[rand.Next(0, dimProductsCount)];
            var productKey = randProduct.productkey;

            var randPromotion = dimPromotions[rand.Next(0, dimPromotionsCount)];
            var promotionKey = randPromotion.promotionkey;

            var promotionKeyNullable = randPromotion.promotionkey == 1 ? null : promotionKey;

            var currencyKey = "1";

            if (customerIterator >= dimCustomerCount)
                customerIterator = newPositionOfCustomer;

            var randDimcustomer = dimCustomers[customerIterator];
            var customerKey = randDimcustomer.customerkey;
            customerIterator++;

            var salesOrderNumber = dateKey.ToString().Replace("-", "")[..8] + randDimcustomer.customerlabel;

            var SalesOrderLineNumber = rand.Next(1, 4874);

            decimal? totalCost = randProduct.unitcost;

            var unitCost = randProduct.unitcost;

            var unitPrice = randProduct.unitprice;


            var salesQuantity = rand.Next(1, 10);

            var salesAmount = salesQuantity * unitPrice;

            var returnQuantity = 0;

            var returnAmount = 0;

            var discountQuantity = rand.Next(0, 2);

            var discountAmount = discountQuantity > 0 ? unitPrice * (decimal?)0.10 : 0;
            
            generetedFactOnlineSales.Add(new factonlinesale
            {
                onlinesaleskey = onlineSalesKey,
                currencykey = currencyKey,
                customerkey = customerKey,
                salesordernumber = salesOrderNumber,
                salesorderlinenumber = SalesOrderLineNumber,
                salesquantity = salesQuantity,
                salesamount = salesAmount.Value,
                returnquantity = returnQuantity,
                datekey = dateKey,
                storekey = storeKey,
                discountamount = discountAmount,
                totalcost = totalCost.Value,
                unitcost = unitCost,
                unitprice = unitPrice,
                simple_string_nullable = null,
                discountquantity = discountQuantity,
                productkey = productKey,
                promotionkey = promotionKey.Value,
                promotionkeynullable = promotionKeyNullable,
                returnamount = returnAmount,
            
            });

            if (i % 5000000 == 0 && i != 0)
            {
                CsvUtils.CreateCSV(generetedFactOnlineSales, pathToWrite, firstBatch);
                generetedFactOnlineSales.Clear();
                firstBatch = false;
            }
        }
        //Дописываем остатки
        if (generetedFactOnlineSales.Any())
            CsvUtils.CreateCSV(generetedFactOnlineSales, pathToWrite, firstBatch);
    }

    public static void FillDimPromotion(List<dimpromotion> dimPromotions)
    {
        dimPromotions.RemoveAll(x => x.promotionkey == 1);
    }

    public static void FillDimDate(List<dimdate> dimDates)
    {
        foreach (var dimDate in dimDates)
        {
            dimDate.ConvertLabelsToRussian();
            dimDate.CalculateDimDateValues();
        }
    }

    public static void FillDimCustomer(List<dimcustomer> dimCustomers, string pathToFatString)
    {
        var countRowInCurrent = dimCustomers.Count();
        const int neededRowCount = 5000000;
        var diff = neededRowCount - countRowInCurrent;

        var customerKeyMax = dimCustomers.Select(x => x.customerkey).Max() + 1;
        
        var random = new Random();
        
        for (var i = 0; i < diff; i++)
        {
            var toSkip = random.Next(0, countRowInCurrent);
            var rndCust = dimCustomers[toSkip];


            var title = rndCust.namestyle == true ? null : titles[random.Next(titles.Length)];
            var firstName = rndCust.namestyle == true ? null : firstNames[random.Next(firstNames.Length)];
            var middleName = rndCust.namestyle == true ? null : middleNames[random.Next(middleNames.Length)];
            var lastName = rndCust.namestyle == true ? null : lastNames[random.Next(lastNames.Length)];

            var generatedEmail = rndCust.namestyle == true
                ? null
                : lastName + title + firstName + middleName + random.Next(0, 2014) + "@adventure-works.com";

            var companyPrefix = companyPrefixes[random.Next(companyPrefixes.Length)];
            var companySuffix = companySuffixes[random.Next(companySuffixes.Length)];

            var generatedGender = rndCust.namestyle == true ? null : new[] { "M", "F" }[random.Next(0, 2)];


            var generatedCompanyName = rndCust.namestyle == true ? $"{companyPrefix} {companySuffix}" : null;

            var generetaedYearlyIncome =
                rndCust.namestyle == true ? random.Next(1000000, 50000000) : random.Next(1000, 1000000);

            var generetedTotalChld = rndCust.namestyle == true ? 0 : random.Next(0, 6);

            var generetedTotalChldInHome = rndCust.namestyle == true ? 0 : random.Next(0, generetedTotalChld + 1);

            var generetedEducation = rndCust.namestyle == true ? null : education[random.Next(education.Length)];

            var generetedOccupation = rndCust.namestyle == true ? null : occupation[random.Next(occupation.Length)];

            var generetedHouseOwner = random.Next(0, 2);

            var generetedCarsOwned = random.Next(0, 6);


            var streetName = streetNames[random.Next(streetNames.Length)];
            var streetNumber = random.Next(1, 1000);
            var city = cities[random.Next(cities.Length)];
            var state = states[random.Next(states.Length)];
            var zipCode = random.Next(10000, 100000);

            var generatedAddress = $"{streetNumber} {streetName}, {city}, {state} {zipCode}";

            var customerType = rndCust.namestyle == true ? "Company" : "Person";

            var dimCustomerToInsert = new dimcustomer
            {
                customerkey = customerKeyMax + i,
                customerlabel = rndCust.customerlabel + i,
                title = title,
                firstname = firstName,
                lastname = lastName,
                middlename = middleName,
                namestyle = rndCust.namestyle,
                birthdate = rndCust.birthdate,
                maritalstatus = rndCust.maritalstatus,
                suffix = rndCust.suffix,
                gender = generatedGender,
                emailaddress = generatedEmail,
                yearlyincome = generetaedYearlyIncome,
                totalchildren = (byte)generetedTotalChld,
                numberchildrenathome = (byte)generetedTotalChldInHome,
                education = generetedEducation,
                occupation = generetedOccupation,
                houseownerflag = generetedHouseOwner.ToString(),
                numbercarsowned = (byte)generetedCarsOwned,
                addressline1 = generatedAddress,
                addressline2 = null,
                phone = rndCust.namestyle == true ? null : GeneratePhoneNumber(random),
                datefirstpurchase = null,
                customertype = customerType,
                companyname = generatedCompanyName
            };

            dimCustomers.Add(dimCustomerToInsert);
        }

        var subjects = CsvUtils.LoadOneDimensionalCsv(pathToFatString);

        for (var i = 0; i < dimCustomers.Count(); i++)
        {
            dimCustomers[i].inn = GenerateInn();
            dimCustomers[i].fat_string = subjects[i];
        }
        subjects.Clear();
        GC.Collect();
    }

    public static void FillDimProduct(IEnumerable<dimproduct> dimProducts)
    {
        var random = new Random();

        var numericBrandName = dimProducts
            .Select(x => x.brandname)
            .Distinct()
            .OrderBy(brandName => brandName)
            .Select((brandName, index) => new
            {
                BrandName = brandName,
                BrandName_Id = index + 1
            });

        var numericClassName = dimProducts
            .Select(x => x.classname)
            .Distinct()
            .OrderBy(className => className)
            .Select((className, index) => new
            {
                className = className,
                className_Id = index + 1
            });

        foreach (var dimProduct in dimProducts)
        {
            dimProduct.brandname_id = numericBrandName.Where(x => x.BrandName == dimProduct.brandname)
                .Select(x => x.BrandName_Id).First();
            dimProduct.brandname_id_nullable = dimProduct.brandname == "Contoso"
                ? null
                : numericBrandName.Where(x => x.BrandName == dimProduct.brandname)
                    .Select(x => x.BrandName_Id).First();


            dimProduct.classname_id = numericClassName.Where(x => x.className == dimProduct.classname)
                .Select(x => x.className_Id).First();
            dimProduct.classname_id_nullable = dimProduct.classname == "Regular"
                ? null
                : numericClassName.Where(x => x.className == dimProduct.classname)
                    .Select(x => x.className_Id).First();

            dimProduct.brandname_string_nullable = dimProduct.brandname == "Contoso" ? null : dimProduct.brandname;

            dimProduct.classname_string_nullable = dimProduct.classname == "Regular" ? null : dimProduct.classname;

            dimProduct.status_bool = dimProduct.status == "On";

            dimProduct.status_bool_nullable = dimProduct.status == "On" ? true : null;

            //Вероятность 10%
            if (random.Next(1, 11) == 1)
            {
                // Список возможных значений
                string[] options = { "", null, " " };

                // Выбираем случайное значение из списка
                var newValue = options[random.Next(options.Length)];

                // Присваиваем новое значение строке
                dimProduct.productdescription = newValue;
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
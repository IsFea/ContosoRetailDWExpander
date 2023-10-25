﻿// <auto-generated />
using System;
using ContosoRetailDwExpander.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ContosoRetailDwExpander.Migrations
{
    [DbContext(typeof(ContosoRetailDwContext))]
    partial class ContosoRetailDwContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimcurrency", b =>
                {
                    b.Property<string>("currencykey")
                        .HasColumnType("text");

                    b.Property<string>("currencydescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("currencylabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("currencyname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.HasKey("currencykey")
                        .HasName("PK_DimCurrency_CurrencyKey");

                    b.HasIndex(new[] { "currencylabel" }, "AK_DimCurrency_CurrencyLabel")
                        .IsUnique();

                    b.ToTable("DimCurrency", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimcustomer", b =>
                {
                    b.Property<int>("customerkey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("customerkey"));

                    b.Property<string>("addressline1")
                        .HasColumnType("text");

                    b.Property<string>("addressline2")
                        .HasColumnType("text");

                    b.Property<DateTime?>("birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("companyname")
                        .HasColumnType("text");

                    b.Property<string>("customerlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customertype")
                        .HasColumnType("text");

                    b.Property<DateTime?>("datefirstpurchase")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("education")
                        .HasColumnType("text");

                    b.Property<string>("emailaddress")
                        .HasColumnType("text");

                    b.Property<string>("fat_string")
                        .HasColumnType("text");

                    b.Property<string>("firstname")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .HasColumnType("text");

                    b.Property<string>("houseownerflag")
                        .HasColumnType("text");

                    b.Property<string>("inn")
                        .HasColumnType("text");

                    b.Property<string>("lastname")
                        .HasColumnType("text");

                    b.Property<string>("maritalstatus")
                        .HasColumnType("text");

                    b.Property<string>("middlename")
                        .HasColumnType("text");

                    b.Property<bool?>("namestyle")
                        .HasColumnType("boolean");

                    b.Property<byte?>("numbercarsowned")
                        .HasColumnType("smallint");

                    b.Property<byte?>("numberchildrenathome")
                        .HasColumnType("smallint");

                    b.Property<string>("occupation")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<string>("suffix")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<byte?>("totalchildren")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("yearlyincome")
                        .HasColumnType("numeric");

                    b.HasKey("customerkey")
                        .HasName("PK_DimCustomer_CustomerKey");

                    b.HasIndex(new[] { "customerlabel" }, "IX_DimCustomer_CustomerLabel")
                        .IsUnique();

                    b.ToTable("DimCustomer", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimdate", b =>
                {
                    b.Property<DateTime>("datekey")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("asiaseason")
                        .HasColumnType("text");

                    b.Property<int?>("calendardaynumber")
                        .HasColumnType("integer");

                    b.Property<int>("calendardayofweek")
                        .HasColumnType("integer");

                    b.Property<string>("calendardayofweeklabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("calendardayofweeklabelru")
                        .HasColumnType("text");

                    b.Property<int>("calendarhalfyear")
                        .HasColumnType("integer");

                    b.Property<string>("calendarhalfyearlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("calendarmonth")
                        .HasColumnType("integer");

                    b.Property<string>("calendarmonthlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("calendarmonthlabelru")
                        .HasColumnType("text");

                    b.Property<int?>("calendarmonthnumber")
                        .HasColumnType("integer");

                    b.Property<int>("calendarquarter")
                        .HasColumnType("integer");

                    b.Property<string>("calendarquarterlabel")
                        .HasColumnType("text");

                    b.Property<int?>("calendarquarternumber")
                        .HasColumnType("integer");

                    b.Property<int>("calendarweek")
                        .HasColumnType("integer");

                    b.Property<string>("calendarweeklabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("calendarweeklabelru")
                        .HasColumnType("text");

                    b.Property<int?>("calendarweeknumberofmonth")
                        .HasColumnType("integer");

                    b.Property<int?>("calendarweeknumberofyear")
                        .HasColumnType("integer");

                    b.Property<int>("calendaryear")
                        .HasColumnType("integer");

                    b.Property<string>("calendaryearlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("calendaryearlabelru")
                        .HasColumnType("text");

                    b.Property<string>("datedescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("europeseason")
                        .HasColumnType("text");

                    b.Property<int>("fiscalhalfyear")
                        .HasColumnType("integer");

                    b.Property<string>("fiscalhalfyearlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("fiscalmonth")
                        .HasColumnType("integer");

                    b.Property<string>("fiscalmonthlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fiscalmonthlabelru")
                        .HasColumnType("text");

                    b.Property<int>("fiscalquarter")
                        .HasColumnType("integer");

                    b.Property<string>("fiscalquarterlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("fiscalyear")
                        .HasColumnType("integer");

                    b.Property<string>("fiscalyearlabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fiscalyearlabelru")
                        .HasColumnType("text");

                    b.Property<string>("fulldatelabel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("holidayname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("isholiday")
                        .HasColumnType("integer");

                    b.Property<string>("isworkday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("isworkdayru")
                        .HasColumnType("text");

                    b.Property<string>("northamericaseason")
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.HasKey("datekey")
                        .HasName("PK_DimDate_DateKey");

                    b.ToTable("DimDate", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimproduct", b =>
                {
                    b.Property<int>("productkey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("productkey"));

                    b.Property<DateTime?>("availableforsaledate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("brandname")
                        .HasColumnType("text");

                    b.Property<int?>("brandname_id")
                        .HasColumnType("integer");

                    b.Property<int?>("brandname_id_nullable")
                        .HasColumnType("integer");

                    b.Property<string>("brandname_string_nullable")
                        .HasColumnType("text");

                    b.Property<string>("classid")
                        .HasColumnType("text");

                    b.Property<string>("classname")
                        .HasColumnType("text");

                    b.Property<int?>("classname_id")
                        .HasColumnType("integer");

                    b.Property<int?>("classname_id_nullable")
                        .HasColumnType("integer");

                    b.Property<string>("classname_string_nullable")
                        .HasColumnType("text");

                    b.Property<string>("colorid")
                        .HasColumnType("text");

                    b.Property<string>("colorname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("productdescription")
                        .HasColumnType("text");

                    b.Property<string>("productlabel")
                        .HasColumnType("text");

                    b.Property<string>("productname")
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<string>("size")
                        .HasColumnType("text");

                    b.Property<string>("sizerange")
                        .HasColumnType("text");

                    b.Property<string>("sizeunitmeasureid")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<bool?>("status_bool")
                        .HasColumnType("boolean");

                    b.Property<bool?>("status_bool_nullable")
                        .HasColumnType("boolean");

                    b.Property<string>("stocktypeid")
                        .HasColumnType("text");

                    b.Property<string>("stocktypename")
                        .HasColumnType("text");

                    b.Property<DateTime?>("stopsaledate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("styleid")
                        .HasColumnType("text");

                    b.Property<string>("stylename")
                        .HasColumnType("text");

                    b.Property<decimal?>("unitcost")
                        .HasColumnType("numeric");

                    b.Property<string>("unitofmeasureid")
                        .HasColumnType("text");

                    b.Property<string>("unitofmeasurename")
                        .HasColumnType("text");

                    b.Property<decimal?>("unitprice")
                        .HasColumnType("numeric");

                    b.Property<double?>("weight")
                        .HasColumnType("double precision");

                    b.Property<string>("weightunitmeasureid")
                        .HasColumnType("text");

                    b.HasKey("productkey")
                        .HasName("PK_DimProduct_ProductKey");

                    b.ToTable("DimProduct", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimpromotion", b =>
                {
                    b.Property<int?>("promotionkey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("promotionkey"));

                    b.Property<double?>("discountpercent")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("enddate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("maxquantity")
                        .HasColumnType("integer");

                    b.Property<int?>("minquantity")
                        .HasColumnType("integer");

                    b.Property<string>("promotioncategory")
                        .HasColumnType("text");

                    b.Property<string>("promotiondescription")
                        .HasColumnType("text");

                    b.Property<string>("promotionlabel")
                        .HasColumnType("text");

                    b.Property<string>("promotionname")
                        .HasColumnType("text");

                    b.Property<string>("promotiontype")
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("promotionkey")
                        .HasName("PK_DimPromotion_PromotionKey");

                    b.HasIndex(new[] { "promotionlabel" }, "AK_DimPromotion_PromotionLabel")
                        .IsUnique();

                    b.ToTable("DimPromotion", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimpromotionnullablekey", b =>
                {
                    b.Property<double?>("discountpercent")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("enddate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("maxquantity")
                        .HasColumnType("integer");

                    b.Property<int?>("minquantity")
                        .HasColumnType("integer");

                    b.Property<string>("promotioncategory")
                        .HasColumnType("text");

                    b.Property<string>("promotiondescription")
                        .HasColumnType("text");

                    b.Property<int?>("promotionkeynullable")
                        .HasColumnType("integer");

                    b.Property<string>("promotionlabel")
                        .HasColumnType("text");

                    b.Property<string>("promotionname")
                        .HasColumnType("text");

                    b.Property<string>("promotiontype")
                        .HasColumnType("text");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("timestamp with time zone");

                    b.ToTable("DimPromotionNullableKey", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimstore", b =>
                {
                    b.Property<int>("storekey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("storekey"));

                    b.Property<string>("addressline1")
                        .HasColumnType("text");

                    b.Property<string>("addressline2")
                        .HasColumnType("text");

                    b.Property<DateTime?>("closedate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("closereason")
                        .HasColumnType("text");

                    b.Property<int?>("employeecount")
                        .HasColumnType("integer");

                    b.Property<int?>("entitykey")
                        .HasColumnType("integer");

                    b.Property<int>("geographykey")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("lastremodeldate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("opendate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("sellingareasize")
                        .HasColumnType("double precision");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("storedescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("storefax")
                        .HasColumnType("text");

                    b.Property<int?>("storemanager")
                        .HasColumnType("integer");

                    b.Property<string>("storename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("storephone")
                        .HasColumnType("text");

                    b.Property<string>("storetype")
                        .HasColumnType("text");

                    b.Property<string>("zipcode")
                        .HasColumnType("text");

                    b.Property<string>("zipcodeextension")
                        .HasColumnType("text");

                    b.HasKey("storekey")
                        .HasName("PK_DimStore_StoreKey");

                    b.ToTable("DimStore", (string)null);
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.factofflinesale", b =>
                {
                    b.Property<int>("offlinesaleskey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("offlinesaleskey"));

                    b.Property<string>("currencykey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("customerkey")
                        .HasColumnType("integer");

                    b.Property<DateTime>("datekey")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("discountamount")
                        .HasColumnType("numeric");

                    b.Property<int?>("discountquantity")
                        .HasColumnType("integer");

                    b.Property<int>("productkey")
                        .HasColumnType("integer");

                    b.Property<int>("promotionkey")
                        .HasColumnType("integer");

                    b.Property<int?>("promotionkeynullable")
                        .HasColumnType("integer");

                    b.Property<decimal?>("returnamount")
                        .HasColumnType("numeric");

                    b.Property<int>("returnquantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("salesamount")
                        .HasColumnType("numeric");

                    b.Property<int?>("salesorderlinenumber")
                        .HasColumnType("integer");

                    b.Property<string>("salesordernumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("salesquantity")
                        .HasColumnType("integer");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<int>("storekey")
                        .HasColumnType("integer");

                    b.Property<decimal>("totalcost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("unitcost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("unitprice")
                        .HasColumnType("numeric");

                    b.HasKey("offlinesaleskey")
                        .HasName("PK_FactOfflineSales_SalesKey");

                    b.HasIndex("currencykey");

                    b.HasIndex("customerkey");

                    b.HasIndex("datekey");

                    b.HasIndex("productkey");

                    b.HasIndex("promotionkey");

                    b.HasIndex("storekey");

                    b.ToTable("FactOfflineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.factonlinesale", b =>
                {
                    b.Property<int>("onlinesaleskey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("onlinesaleskey"));

                    b.Property<string>("currencykey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("customerkey")
                        .HasColumnType("integer");

                    b.Property<DateTime>("datekey")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("discountamount")
                        .HasColumnType("numeric");

                    b.Property<int?>("discountquantity")
                        .HasColumnType("integer");

                    b.Property<int>("productkey")
                        .HasColumnType("integer");

                    b.Property<int>("promotionkey")
                        .HasColumnType("integer");

                    b.Property<int?>("promotionkeynullable")
                        .HasColumnType("integer");

                    b.Property<decimal?>("returnamount")
                        .HasColumnType("numeric");

                    b.Property<int>("returnquantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("salesamount")
                        .HasColumnType("numeric");

                    b.Property<int?>("salesorderlinenumber")
                        .HasColumnType("integer");

                    b.Property<string>("salesordernumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("salesquantity")
                        .HasColumnType("integer");

                    b.Property<string>("simple_string_nullable")
                        .HasColumnType("text");

                    b.Property<int>("storekey")
                        .HasColumnType("integer");

                    b.Property<decimal>("totalcost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("unitcost")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("unitprice")
                        .HasColumnType("numeric");

                    b.HasKey("onlinesaleskey")
                        .HasName("PK_FactOnlineSales_SalesKey");

                    b.HasIndex("currencykey");

                    b.HasIndex("customerkey");

                    b.HasIndex("datekey");

                    b.HasIndex("productkey");

                    b.HasIndex("promotionkey");

                    b.HasIndex("storekey");

                    b.ToTable("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.factofflinesale", b =>
                {
                    b.HasOne("ContosoRetailDwExpander.Model.dimcurrency", "CurrencyKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("currencykey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimCurrency");

                    b.HasOne("ContosoRetailDwExpander.Model.dimcustomer", "CustomerKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("customerkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimCustomer");

                    b.HasOne("ContosoRetailDwExpander.Model.dimdate", "DateKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("datekey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimDate");

                    b.HasOne("ContosoRetailDwExpander.Model.dimproduct", "ProductKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("productkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimProduct");

                    b.HasOne("ContosoRetailDwExpander.Model.dimpromotion", "PromotionKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("promotionkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimPromotion");

                    b.HasOne("ContosoRetailDwExpander.Model.dimstore", "StoreKeyNavigation")
                        .WithMany("FactOfflineSales")
                        .HasForeignKey("storekey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOfflineSales_DimStore");

                    b.Navigation("CurrencyKeyNavigation");

                    b.Navigation("CustomerKeyNavigation");

                    b.Navigation("DateKeyNavigation");

                    b.Navigation("ProductKeyNavigation");

                    b.Navigation("PromotionKeyNavigation");

                    b.Navigation("StoreKeyNavigation");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.factonlinesale", b =>
                {
                    b.HasOne("ContosoRetailDwExpander.Model.dimcurrency", "CurrencyKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("currencykey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimCurrency");

                    b.HasOne("ContosoRetailDwExpander.Model.dimcustomer", "CustomerKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("customerkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimCustomer");

                    b.HasOne("ContosoRetailDwExpander.Model.dimdate", "DateKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("datekey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimDate");

                    b.HasOne("ContosoRetailDwExpander.Model.dimproduct", "ProductKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("productkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimProduct");

                    b.HasOne("ContosoRetailDwExpander.Model.dimpromotion", "PromotionKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("promotionkey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimPromotion");

                    b.HasOne("ContosoRetailDwExpander.Model.dimstore", "StoreKeyNavigation")
                        .WithMany("FactOnlineSales")
                        .HasForeignKey("storekey")
                        .IsRequired()
                        .HasConstraintName("FK_FactOnlineSales_DimStore");

                    b.Navigation("CurrencyKeyNavigation");

                    b.Navigation("CustomerKeyNavigation");

                    b.Navigation("DateKeyNavigation");

                    b.Navigation("ProductKeyNavigation");

                    b.Navigation("PromotionKeyNavigation");

                    b.Navigation("StoreKeyNavigation");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimcurrency", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimcustomer", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimdate", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimproduct", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimpromotion", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });

            modelBuilder.Entity("ContosoRetailDwExpander.Model.dimstore", b =>
                {
                    b.Navigation("FactOfflineSales");

                    b.Navigation("FactOnlineSales");
                });
#pragma warning restore 612, 618
        }
    }
}

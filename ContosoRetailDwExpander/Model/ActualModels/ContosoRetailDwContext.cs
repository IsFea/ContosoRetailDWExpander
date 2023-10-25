using Microsoft.EntityFrameworkCore;

namespace ContosoRetailDwExpander.Model;

public partial class ContosoRetailDwContext : DbContext
{
    public ContosoRetailDwContext()
    {
    }

    public ContosoRetailDwContext(DbContextOptions<ContosoRetailDwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<dimcurrency> DimCurrencies { get; set; }

    public virtual DbSet<dimcustomer> DimCustomers { get; set; }

    public virtual DbSet<dimdate> DimDates { get; set; }

    public virtual DbSet<dimproduct> DimProducts { get; set; }

    public virtual DbSet<dimpromotion> DimPromotions { get; set; }
    
    public virtual DbSet<dimpromotionnullablekey> DimPromotionNullableKeys { get; set; }

    public virtual DbSet<dimstore> DimStores { get; set; }

    public virtual DbSet<factonlinesale> FactOnlineSales { get; set; }
    
    public virtual DbSet<factofflinesale> FactOfflineSales { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        
        modelBuilder.Entity<dimcurrency>(entity =>
        {
            entity.HasKey(e => e.currencykey).HasName("PK_DimCurrency_CurrencyKey");

            entity.ToTable("DimCurrency");

            entity.HasIndex(e => e.currencylabel, "AK_DimCurrency_CurrencyLabel").IsUnique();
        });

        modelBuilder.Entity<dimcustomer>(entity =>
        {
            entity.HasKey(e => e.customerkey).HasName("PK_DimCustomer_CustomerKey");

            entity.ToTable("DimCustomer");

            entity.HasIndex(e => e.customerlabel, "IX_DimCustomer_CustomerLabel").IsUnique();
        });

        modelBuilder.Entity<dimdate>(entity =>
        {
            entity.HasKey(e => e.datekey).HasName("PK_DimDate_DateKey");

            entity.ToTable("DimDate");
        });

        modelBuilder.Entity<dimproduct>(entity =>
        {
            entity.HasKey(e => e.productkey).HasName("PK_DimProduct_ProductKey");

            entity.ToTable("DimProduct");
        });
        
        modelBuilder.Entity<dimpromotion>(entity =>
        {
            entity.HasKey(e => e.promotionkey).HasName("PK_DimPromotion_PromotionKey");

            entity.ToTable("DimPromotion");

            entity.HasIndex(e => e.promotionlabel, "AK_DimPromotion_PromotionLabel").IsUnique();
            
        });

        modelBuilder.Entity<dimpromotionnullablekey>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("DimPromotionNullableKey");

        });
        
        modelBuilder.Entity<dimstore>(entity =>
        {
            entity.HasKey(e => e.storekey).HasName("PK_DimStore_StoreKey");

            entity.ToTable("DimStore");
            
        });

        modelBuilder.Entity<factonlinesale>(entity =>
        {
            entity.HasKey(e => e.onlinesaleskey).HasName("PK_FactOnlineSales_SalesKey");
            

            entity.HasOne(d => d.CurrencyKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.currencykey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimCurrency");

            entity.HasOne(d => d.CustomerKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.customerkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimCustomer");

            entity.HasOne(d => d.DateKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.datekey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimDate");

            entity.HasOne(d => d.ProductKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.productkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimProduct");

            entity.HasOne(d => d.PromotionKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.promotionkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimPromotion");

            entity.HasOne(d => d.StoreKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.storekey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimStore");
        });
        
        modelBuilder.Entity<factofflinesale>(entity =>
        {
            entity.HasKey(e => e.offlinesaleskey).HasName("PK_FactOfflineSales_SalesKey");
            

            entity.HasOne(d => d.CurrencyKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.currencykey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimCurrency");

            entity.HasOne(d => d.CustomerKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.customerkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimCustomer");

            entity.HasOne(d => d.DateKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.datekey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimDate");

            entity.HasOne(d => d.ProductKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.productkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimProduct");

            entity.HasOne(d => d.PromotionKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.promotionkey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimPromotion");

            entity.HasOne(d => d.StoreKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.storekey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimStore");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
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

    public virtual DbSet<DimCurrency> DimCurrencies { get; set; }

    public virtual DbSet<DimCustomer> DimCustomers { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimProduct> DimProducts { get; set; }

    public virtual DbSet<DimPromotion> DimPromotions { get; set; }
    
    public virtual DbSet<DimPromotionNullableKey> DimPromotionNullableKeys { get; set; }

    public virtual DbSet<DimStore> DimStores { get; set; }

    public virtual DbSet<FactOnlineSale> FactOnlineSales { get; set; }
    
    public virtual DbSet<FactOfflineSale> FactOfflineSales { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(
            "Host=127.0.0.1;Username=postgres;Password=;Database=MyContoso");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        
        modelBuilder.Entity<DimCurrency>(entity =>
        {
            entity.HasKey(e => e.CurrencyKey).HasName("PK_DimCurrency_CurrencyKey");

            entity.ToTable("DimCurrency");

            entity.HasIndex(e => e.CurrencyLabel, "AK_DimCurrency_CurrencyLabel").IsUnique();
        });

        modelBuilder.Entity<DimCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerKey).HasName("PK_DimCustomer_CustomerKey");

            entity.ToTable("DimCustomer");

            entity.HasIndex(e => e.CustomerLabel, "IX_DimCustomer_CustomerLabel").IsUnique();
        });

        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.HasKey(e => e.Datekey).HasName("PK_DimDate_DateKey");

            entity.ToTable("DimDate");
        });

        modelBuilder.Entity<DimProduct>(entity =>
        {
            entity.HasKey(e => e.ProductKey).HasName("PK_DimProduct_ProductKey");

            entity.ToTable("DimProduct");
        });
        
        modelBuilder.Entity<DimPromotion>(entity =>
        {
            entity.HasKey(e => e.PromotionKey).HasName("PK_DimPromotion_PromotionKey");

            entity.ToTable("DimPromotion");

            entity.HasIndex(e => e.PromotionLabel, "AK_DimPromotion_PromotionLabel").IsUnique();
            
        });

        modelBuilder.Entity<DimPromotionNullableKey>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("DimPromotionNullableKey");

        });
        
        modelBuilder.Entity<DimStore>(entity =>
        {
            entity.HasKey(e => e.StoreKey).HasName("PK_DimStore_StoreKey");

            entity.ToTable("DimStore");
            
        });

        modelBuilder.Entity<FactOnlineSale>(entity =>
        {
            entity.HasKey(e => e.OnlineSalesKey).HasName("PK_FactOnlineSales_SalesKey");
            

            entity.HasOne(d => d.CurrencyKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.CurrencyKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimCurrency");

            entity.HasOne(d => d.CustomerKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.CustomerKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimCustomer");

            entity.HasOne(d => d.DateKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.DateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimDate");

            entity.HasOne(d => d.ProductKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.ProductKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimProduct");

            entity.HasOne(d => d.PromotionKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.PromotionKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimPromotion");

            entity.HasOne(d => d.StoreKeyNavigation).WithMany(p => p.FactOnlineSales)
                .HasForeignKey(d => d.StoreKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOnlineSales_DimStore");
        });
        
        modelBuilder.Entity<FactOfflineSale>(entity =>
        {
            entity.HasKey(e => e.OnlineSalesKey).HasName("PK_FactOfflineSales_SalesKey");
            

            entity.HasOne(d => d.CurrencyKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.CurrencyKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimCurrency");

            entity.HasOne(d => d.CustomerKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.CustomerKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimCustomer");

            entity.HasOne(d => d.DateKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.DateKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimDate");

            entity.HasOne(d => d.ProductKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.ProductKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimProduct");

            entity.HasOne(d => d.PromotionKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.PromotionKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimPromotion");

            entity.HasOne(d => d.StoreKeyNavigation).WithMany(p => p.FactOfflineSales)
                .HasForeignKey(d => d.StoreKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactOfflineSales_DimStore");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
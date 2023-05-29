using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VSA.Domain;

namespace VSA.DamainServices;

public partial class VapeShopContext : DbContext
{
    private readonly string _context;

   
/*    public VapeShopContext(IConfiguration configuration)
    {
        _context = configuration.GetConnectionString("DefaultConnection")!;
    }*/

    public VapeShopContext(DbContextOptions<VapeShopContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<PriceChange> PriceChanges { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
         => optionsBuilder.UseSqlServer("Data Source=WIN-FPAHVGS7QRO;Initial Catalog=VapeShop;Integrated Security=True;TrustServerCertificate=false;Trusted_Connection=true;Encrypt=false;");
 */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B459040B89");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB8584C2FAB9");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerFname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_fname");
            entity.Property(e => e.CustomerLname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_lname");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("deliveries");

            entity.Property(e => e.DeliveryDate)
                .HasColumnType("date")
                .HasColumnName("delivery_date");
            entity.Property(e => e.ProductCount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("product_count");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__deliverie__produ__1332DBDC");

            entity.HasOne(d => d.Store).WithMany()
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__deliverie__store__14270015");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__manufact__163F69B0ADE6EF5D");

            entity.ToTable("manufacturers");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<PriceChange>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.DatePriceChange }).HasName("PK_PRICE_CHANGE");

            entity.ToTable("price_change");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.DatePriceChange)
                .HasColumnType("date")
                .HasColumnName("date_price_change");
            entity.Property(e => e.NewPrice)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("new_price");

            entity.HasOne(d => d.Product).WithMany(p => p.PriceChanges)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__price_cha__produ__0F624AF8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5DE6A0697");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__products__catego__0B91BA14");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__products__manufa__0C85DE4D");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__purchase__87071CB9B3BD078A");

            entity.ToTable("purchases");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchases__custo__18EBB532");

            entity.HasOne(d => d.Store).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchases__store__19DFD96B");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseId, e.ProductId }).HasName("PK_PURCHASE_ITEMS");

            entity.ToTable("purchase_items");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductCount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("product_count");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("product_price");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchase___produ__1CBC4616");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchase___purch__1DB06A4F");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C7FB3E645");

            entity.ToTable("stores");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.StoreName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("store_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206A9DF886F20113");

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("User_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

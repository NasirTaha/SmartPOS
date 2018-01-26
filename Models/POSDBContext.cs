using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebUI.Models
{
    public partial class POSDBContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceSaleInvoice> DeviceSaleInvoice { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<InvoicePayType> InvoicePayType { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<Manufactory> Manufactory { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<SaleInvoice> SaleInvoice { get; set; }
        public virtual DbSet<SaleInvoiceDetail> SaleInvoiceDetail { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreSetting> StoreSetting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=50.3.75.39;Database=POSDB;uid=sa;pwd=Qaz!user;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DeviceTypeId).HasColumnName("DeviceTypeID");

                entity.Property(e => e.ManufactoryId).HasColumnName("ManufactoryID");

                entity.Property(e => e.SerialNo).HasMaxLength(80);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .HasConstraintName("FK_Device_DeviceType");

                entity.HasOne(d => d.Manufactory)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.ManufactoryId)
                    .HasConstraintName("FK_Device_Manufactory");
            });

            modelBuilder.Entity<DeviceSaleInvoice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("CustomerID")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DevicId).HasColumnName("DevicID");

                entity.Property(e => e.DeviceDesciption).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Devic)
                    .WithMany(p => p.DeviceSaleInvoice)
                    .HasForeignKey(d => d.DevicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceSaleInvoice_Device");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeviceSaleInvoice)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DeviceSaleInvoice_AspNetUsers");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<InvoicePayType>(entity =>
            {
                entity.HasKey(e => new { e.SaleInvoiceId, e.PaymentModeId });

                entity.HasOne(d => d.PaymentMode)
                    .WithMany(p => p.InvoicePayType)
                    .HasForeignKey(d => d.PaymentModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicePayType_PaymentMode");

                entity.HasOne(d => d.SaleInvoice)
                    .WithMany(p => p.InvoicePayType)
                    .HasForeignKey(d => d.SaleInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicePayType_SaleInvoice");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.ImagePath).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_ItemCategory");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Color).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.ImagePath).HasMaxLength(100);

                entity.Property(e => e.PrinterName).HasMaxLength(100);
            });

            modelBuilder.Entity<Manufactory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufactoryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.Property(e => e.Mode)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SaleInvoice>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.SaleInvoice)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_SaleInvoice_Currency");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SaleInvoice)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_SaleInvoice_Customer");
            });

            modelBuilder.Entity<SaleInvoiceDetail>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SaleInvoiceDetail)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleInvoiceDetail_Item");

                entity.HasOne(d => d.SaleInvoice)
                    .WithMany(p => p.SaleInvoiceDetail)
                    .HasForeignKey(d => d.SaleInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleInvoiceDetail_SaleInvoice");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(40);

                entity.Property(e => e.StockOwner).HasMaxLength(20);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StoreSetting>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.Signature).HasMaxLength(100);

                entity.HasOne(d => d.DefaultCurrency)
                    .WithMany(p => p.StoreSetting)
                    .HasForeignKey(d => d.DefaultCurrencyId)
                    .HasConstraintName("FK_StoreSetting_Currency");
            });
        }
    }
}

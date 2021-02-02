using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MarketAPI.Models
{
    public partial class MarketManagementContext : DbContext
    {
        public MarketManagementContext()
        {
        }

        public MarketManagementContext(DbContextOptions<MarketManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleConcept> SaleConcepts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B50KN9UE;Database=MarketManagement;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Client_Address");

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Client_Email");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Client_Name");

                entity.Property(e => e.ClientPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Client_Phone");

                entity.Property(e => e.ClientStatus).HasColumnName("Client_Status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductFinalCost)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Product_FinalCost");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductStatus).HasColumnName("Product_Status");

                entity.Property(e => e.ProductStock).HasColumnName("Product_Stock");

                entity.Property(e => e.ProductUnitValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Product_UnitValue");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Sale_Date");

                entity.Property(e => e.SaleStatus).HasColumnName("Sale_Status");

                entity.Property(e => e.SaleTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Sale_Total");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_Client");
            });

            modelBuilder.Entity<SaleConcept>(entity =>
            {
                entity.ToTable("SaleConcept");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.SaleConceptCost)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SaleConcept_Cost");

                entity.Property(e => e.SaleConceptQuantity).HasColumnName("SaleConcept_Quantity");

                entity.Property(e => e.SaleConceptStatus).HasColumnName("SaleConcept_Status");

                entity.Property(e => e.SaleConceptUnitValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SaleConcept_UnitValue");

                entity.Property(e => e.SaleId).HasColumnName("Sale_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleConcepts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleConcept_Product");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleConcepts)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleConcept_Sale");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserMail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

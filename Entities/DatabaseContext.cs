using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIWebApp.Entities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerUsername> CustomerUsernames { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSerial> ProductSerials { get; set; } = null!;
        public virtual DbSet<Transfer> Transfers { get; set; } = null!;
        public virtual DbSet<UpdateCustomer> UpdateCustomers { get; set; } = null!;
        public virtual DbSet<UpdateOrder> UpdateOrders { get; set; } = null!;
        public virtual DbSet<UpdateProduct> UpdateProducts { get; set; } = null!;
        public virtual DbSet<UpdateTransfer> UpdateTransfers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_100_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Admin");

                entity.HasOne(d => d.CustomerUsernameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Customer_Username");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Product");

                entity.HasOne(d => d.Transfer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Transfer");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Admin");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.ProductSerialnumberNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSerialnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Product_Serial");
            });

            modelBuilder.Entity<UpdateCustomer>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UpdateCustomers)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Customer_Admin");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UpdateCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Customer_Customer");
            });

            modelBuilder.Entity<UpdateOrder>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UpdateOrders)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Order_Admin");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UpdateOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Order_Order");
            });

            modelBuilder.Entity<UpdateProduct>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UpdateProducts)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Product_Admin");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UpdateProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Product_Product");
            });

            modelBuilder.Entity<UpdateTransfer>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UpdateTransfers)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Transfer_Admin");

                entity.HasOne(d => d.Transfer)
                    .WithMany(p => p.UpdateTransfers)
                    .HasForeignKey(d => d.TransferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Transfer_Transfer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

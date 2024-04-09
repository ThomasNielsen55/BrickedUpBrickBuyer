using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BrickedUpBrickBuyer.Data;

public partial class BrickContext : DbContext
{
    public BrickContext()
    {
    }

    public BrickContext(DbContextOptions<BrickContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("DataSource=sucky2.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_ID");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.CountryOfResidence).HasColumnName("country_of_residence");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName).HasColumnName("last_name");
        });

        modelBuilder.Entity<LineItem>(entity =>
        {
            entity.Property(e => e.LineItemId)
                .ValueGeneratedNever()
                .HasColumnName("line_item_ID");
            entity.Property(e => e.ProductId).HasColumnName("product_ID");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.LineItems).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Transaction).WithMany(p => p.LineItems).HasForeignKey(d => d.TransactionId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Bank).HasColumnName("bank");
            entity.Property(e => e.CountryOfTransaction).HasColumnName("country_of_transaction");
            entity.Property(e => e.CustomerId).HasColumnName("customer_ID");
            entity.Property(e => e.Date)
                .HasColumnType("DATETIME")
                .HasColumnName("date");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.EntryMode).HasColumnName("entry_mode");
            entity.Property(e => e.Fraud).HasColumnName("fraud");
            entity.Property(e => e.ShippingAddress).HasColumnName("shipping_address");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TypeOfCard).HasColumnName("type_of_card");
            entity.Property(e => e.TypeOfTransaction).HasColumnName("type_of_transaction");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_ID");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImgLink).HasColumnName("img_link");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NumParts).HasColumnName("num_parts");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PrimaryColor).HasColumnName("primary_color");
            entity.Property(e => e.SecondaryColor).HasColumnName("secondary_color");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("Products")
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder
            .Property(p => p.CategoryId)
            .HasColumnName("CategoryId");

        builder
            .Property(p => p.ProductName)
            .HasColumnName("ProductName")
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(p => p.UnitsInStock)
            .HasColumnName("UnitsInStock")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.UnitPrice)
            .HasColumnName("UnitPrice");

        builder
            .Property(p => p.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();

        builder
            .Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy");


        builder
            .Property(p => p.LastModified)
            .HasColumnName("LastModified")
            .IsRequired();

        builder
            .Property(p => p.LastModifiedBy)
            .HasColumnName("LastModifiedBy");


        builder
            .HasIndex(indexExpression: p => p.ProductName, name: "UK_Products_Name")
            .IsUnique();

        builder
            .HasOne(p => p.Category);

    }
}

